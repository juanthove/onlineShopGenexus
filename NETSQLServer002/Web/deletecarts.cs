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
   public class deletecarts : GXProcedure
   {
      public deletecarts( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public deletecarts( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           out string aP2_Mensaje )
      {
         this.AV8FromDate = aP0_FromDate;
         this.AV9ToDate = aP1_ToDate;
         this.AV12Mensaje = "" ;
         initialize();
         ExecuteImpl();
         aP2_Mensaje=this.AV12Mensaje;
      }

      public string executeUdp( DateTime aP0_FromDate ,
                                DateTime aP1_ToDate )
      {
         execute(aP0_FromDate, aP1_ToDate, out aP2_Mensaje);
         return AV12Mensaje ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 out string aP2_Mensaje )
      {
         this.AV8FromDate = aP0_FromDate;
         this.AV9ToDate = aP1_ToDate;
         this.AV12Mensaje = "" ;
         SubmitImpl();
         aP2_Mensaje=this.AV12Mensaje;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P000K2 */
         pr_default.execute(0, new Object[] {AV8FromDate, AV9ToDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A34ShoppingCartDate = P000K2_A34ShoppingCartDate[0];
            A31ShoppingCartId = P000K2_A31ShoppingCartId[0];
            AV10ShoppingCart.Load(A31ShoppingCartId);
            if ( DateTimeUtil.ResetTime ( A34ShoppingCartDate ) != DateTimeUtil.ResetTime ( Gx_date ) )
            {
               AV10ShoppingCart.Delete();
               AV11cantElimino = (short)(AV11cantElimino+1);
            }
            context.CommitDataStores("deletecarts",pr_default);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV11cantElimino == 1 )
         {
            AV12Mensaje = "Se eliminó 1 carrito";
         }
         else
         {
            AV12Mensaje = "Se eliminaron " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11cantElimino), 4, 0)) + " carritos";
         }
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
         AV12Mensaje = "";
         P000K2_A34ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         P000K2_A31ShoppingCartId = new short[1] ;
         A34ShoppingCartDate = DateTime.MinValue;
         AV10ShoppingCart = new SdtShoppingCart(context);
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.deletecarts__default(),
            new Object[][] {
                new Object[] {
               P000K2_A34ShoppingCartDate, P000K2_A31ShoppingCartId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short A31ShoppingCartId ;
      private short AV11cantElimino ;
      private DateTime AV8FromDate ;
      private DateTime AV9ToDate ;
      private DateTime A34ShoppingCartDate ;
      private DateTime Gx_date ;
      private string AV12Mensaje ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P000K2_A34ShoppingCartDate ;
      private short[] P000K2_A31ShoppingCartId ;
      private SdtShoppingCart AV10ShoppingCart ;
      private string aP2_Mensaje ;
   }

   public class deletecarts__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000K2;
          prmP000K2 = new Object[] {
          new ParDef("@AV8FromDate",GXType.Date,8,0) ,
          new ParDef("@AV9ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000K2", "SELECT [ShoppingCartDate], [ShoppingCartId] FROM [ShoppingCart] WHERE [ShoppingCartDate] >= @AV8FromDate and [ShoppingCartDate] <= @AV9ToDate ORDER BY [ShoppingCartId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000K2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
