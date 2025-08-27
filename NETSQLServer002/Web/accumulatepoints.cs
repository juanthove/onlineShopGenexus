using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class accumulatepoints : GXProcedure
   {
      public accumulatepoints( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public accumulatepoints( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_CustomerId ,
                           decimal aP1_ShoppingCartTotalCost )
      {
         this.AV9CustomerId = aP0_CustomerId;
         this.AV8ShoppingCartTotalCost = aP1_ShoppingCartTotalCost;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( short aP0_CustomerId ,
                                 decimal aP1_ShoppingCartTotalCost )
      {
         this.AV9CustomerId = aP0_CustomerId;
         this.AV8ShoppingCartTotalCost = aP1_ShoppingCartTotalCost;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P000Q2 */
         pr_default.execute(0, new Object[] {AV9CustomerId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A15CustomerId = P000Q2_A15CustomerId[0];
            A20PointCardId = P000Q2_A20PointCardId[0];
            A23PointCardVIP = P000Q2_A23PointCardVIP[0];
            AV10PointCard.Load(A20PointCardId);
            AV11Points = (short)((AV8ShoppingCartTotalCost/ (decimal)(1000)));
            NumberUtil.Trunc( (decimal)(AV11Points), 0) ;
            AV11Points = (short)(AV11Points*50);
            AV10PointCard.gxTpr_Pointcardpoints = (int)(AV10PointCard.gxTpr_Pointcardpoints+AV11Points);
            if ( AV10PointCard.gxTpr_Pointcardpoints >= 1000 )
            {
               A23PointCardVIP = true;
            }
            AV10PointCard.Update();
            /* Using cursor P000Q3 */
            pr_default.execute(1, new Object[] {A23PointCardVIP, A20PointCardId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("PointCard");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         context.CommitDataStores("accumulatepoints",pr_default);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("accumulatepoints",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P000Q2_A15CustomerId = new short[1] ;
         P000Q2_A20PointCardId = new short[1] ;
         P000Q2_A23PointCardVIP = new bool[] {false} ;
         AV10PointCard = new SdtPointCard(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.accumulatepoints__default(),
            new Object[][] {
                new Object[] {
               P000Q2_A15CustomerId, P000Q2_A20PointCardId, P000Q2_A23PointCardVIP
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9CustomerId ;
      private short A15CustomerId ;
      private short A20PointCardId ;
      private short AV11Points ;
      private decimal AV8ShoppingCartTotalCost ;
      private bool A23PointCardVIP ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000Q2_A15CustomerId ;
      private short[] P000Q2_A20PointCardId ;
      private bool[] P000Q2_A23PointCardVIP ;
      private SdtPointCard AV10PointCard ;
   }

   public class accumulatepoints__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000Q2;
          prmP000Q2 = new Object[] {
          new ParDef("@AV9CustomerId",GXType.Int16,4,0)
          };
          Object[] prmP000Q3;
          prmP000Q3 = new Object[] {
          new ParDef("@PointCardVIP",GXType.Boolean,4,0) ,
          new ParDef("@PointCardId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000Q2", "SELECT [CustomerId], [PointCardId], [PointCardVIP] FROM [PointCard] WITH (UPDLOCK) WHERE [CustomerId] = @AV9CustomerId ORDER BY [CustomerId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Q2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000Q3", "UPDATE [PointCard] SET [PointCardVIP]=@PointCardVIP  WHERE [PointCardId] = @PointCardId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000Q3)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
       }
    }

 }

}
