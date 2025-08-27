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
   public class increaseprice : GXProcedure
   {
      public increaseprice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public increaseprice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_CategoryId ,
                           short aP1_Percentage )
      {
         this.AV8CategoryId = aP0_CategoryId;
         this.AV11Percentage = aP1_Percentage;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( short aP0_CategoryId ,
                                 short aP1_Percentage )
      {
         this.AV8CategoryId = aP0_CategoryId;
         this.AV11Percentage = aP1_Percentage;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8CategoryId ,
                                              A4CategoryId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P000N2 */
         pr_default.execute(0, new Object[] {AV8CategoryId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4CategoryId = P000N2_A4CategoryId[0];
            A10ProductId = P000N2_A10ProductId[0];
            A13ProductPrice = P000N2_A13ProductPrice[0];
            AV10Product.Load(A10ProductId);
            A13ProductPrice = (decimal)(A13ProductPrice*(1+AV11Percentage/ (decimal)(100)));
            AV10Product.Update();
            /* Using cursor P000N3 */
            pr_default.execute(1, new Object[] {A13ProductPrice, A10ProductId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Product");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         context.CommitDataStores("increaseprice",pr_default);
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P000N2_A4CategoryId = new short[1] ;
         P000N2_A10ProductId = new short[1] ;
         P000N2_A13ProductPrice = new decimal[1] ;
         AV10Product = new SdtProduct(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.increaseprice__default(),
            new Object[][] {
                new Object[] {
               P000N2_A4CategoryId, P000N2_A10ProductId, P000N2_A13ProductPrice
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8CategoryId ;
      private short AV11Percentage ;
      private short A4CategoryId ;
      private short A10ProductId ;
      private decimal A13ProductPrice ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000N2_A4CategoryId ;
      private short[] P000N2_A10ProductId ;
      private decimal[] P000N2_A13ProductPrice ;
      private SdtProduct AV10Product ;
   }

   public class increaseprice__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000N2( IGxContext context ,
                                             short AV8CategoryId ,
                                             short A4CategoryId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [CategoryId], [ProductId], [ProductPrice] FROM [Product] WITH (UPDLOCK)";
         if ( ! (0==AV8CategoryId) )
         {
            AddWhere(sWhereString, "([CategoryId] = @AV8CategoryId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProductId]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P000N2(context, (short)dynConstraints[0] , (short)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP000N3;
          prmP000N3 = new Object[] {
          new ParDef("@ProductPrice",GXType.Decimal,18,2) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmP000N2;
          prmP000N2 = new Object[] {
          new ParDef("@AV8CategoryId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000N2", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000N2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000N3", "UPDATE [Product] SET [ProductPrice]=@ProductPrice  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000N3)
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
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
       }
    }

 }

}
