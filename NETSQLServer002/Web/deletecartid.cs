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
   public class deletecartid : GXProcedure
   {
      public deletecartid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public deletecartid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_ShoppingCartId )
      {
         this.AV8ShoppingCartId = aP0_ShoppingCartId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( short aP0_ShoppingCartId )
      {
         this.AV8ShoppingCartId = aP0_ShoppingCartId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P000L2 */
         pr_default.execute(0, new Object[] {AV8ShoppingCartId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A31ShoppingCartId = P000L2_A31ShoppingCartId[0];
            /* Using cursor P000L3 */
            pr_default.execute(1, new Object[] {A31ShoppingCartId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("ShoppingCart");
            GX_msglist.addItem("Carrito eliminado");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("deletecartid",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P000L2_A31ShoppingCartId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.deletecartid__default(),
            new Object[][] {
                new Object[] {
               P000L2_A31ShoppingCartId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8ShoppingCartId ;
      private short A31ShoppingCartId ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000L2_A31ShoppingCartId ;
   }

   public class deletecartid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000L2;
          prmP000L2 = new Object[] {
          new ParDef("@AV8ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmP000L3;
          prmP000L3 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000L2", "SELECT [ShoppingCartId] FROM [ShoppingCart] WITH (UPDLOCK) WHERE [ShoppingCartId] = @AV8ShoppingCartId ORDER BY [ShoppingCartId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000L2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000L3", "DELETE FROM [ShoppingCart]  WHERE [ShoppingCartId] = @ShoppingCartId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000L3)
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
                return;
       }
    }

 }

}
