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
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aproductslistcategory : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("ObligatorioShop", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aproductslistcategory( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public aproductslistcategory( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("ShoppingCartReport.pdf");
         setOutputType("Pdf");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            /* Using cursor P000I2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK0I3 = false;
               A6SellerId = P000I2_A6SellerId[0];
               A4CategoryId = P000I2_A4CategoryId[0];
               A40000ProductImage_GXI = P000I2_A40000ProductImage_GXI[0];
               A40001SellerPhoto_GXI = P000I2_A40001SellerPhoto_GXI[0];
               A13ProductPrice = P000I2_A13ProductPrice[0];
               A11ProductName = P000I2_A11ProductName[0];
               A7SellerName = P000I2_A7SellerName[0];
               A5CategoryName = P000I2_A5CategoryName[0];
               A10ProductId = P000I2_A10ProductId[0];
               A14ProductImage = P000I2_A14ProductImage[0];
               A8SellerPhoto = P000I2_A8SellerPhoto[0];
               A40001SellerPhoto_GXI = P000I2_A40001SellerPhoto_GXI[0];
               A7SellerName = P000I2_A7SellerName[0];
               A8SellerPhoto = P000I2_A8SellerPhoto[0];
               A5CategoryName = P000I2_A5CategoryName[0];
               H0I0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 100, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A5CategoryName, "")), 50, Gx_line+33, 343, Gx_line+55, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               while ( (pr_default.getStatus(0) != 101) && ( P000I2_A4CategoryId[0] == A4CategoryId ) )
               {
                  BRK0I3 = false;
                  A6SellerId = P000I2_A6SellerId[0];
                  A40000ProductImage_GXI = P000I2_A40000ProductImage_GXI[0];
                  A40001SellerPhoto_GXI = P000I2_A40001SellerPhoto_GXI[0];
                  A13ProductPrice = P000I2_A13ProductPrice[0];
                  A11ProductName = P000I2_A11ProductName[0];
                  A7SellerName = P000I2_A7SellerName[0];
                  A10ProductId = P000I2_A10ProductId[0];
                  A14ProductImage = P000I2_A14ProductImage[0];
                  A8SellerPhoto = P000I2_A8SellerPhoto[0];
                  A40001SellerPhoto_GXI = P000I2_A40001SellerPhoto_GXI[0];
                  A7SellerName = P000I2_A7SellerName[0];
                  A8SellerPhoto = P000I2_A8SellerPhoto[0];
                  H0I0( false, 100) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A8SellerPhoto)) ? A40001SellerPhoto_GXI : A8SellerPhoto);
                  getPrinter().GxDrawBitMap(sImgUrl, 733, Gx_line+33, 800, Gx_line+83) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 11, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A7SellerName, "")), 500, Gx_line+33, 725, Gx_line+53, 1, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage)) ? A40000ProductImage_GXI : A14ProductImage);
                  getPrinter().GxDrawBitMap(sImgUrl, 92, Gx_line+33, 142, Gx_line+66) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A11ProductName, "")), 167, Gx_line+33, 309, Gx_line+53, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A13ProductPrice, "ZZZZZZZZZZZZZZ9.99")), 342, Gx_line+33, 493, Gx_line+53, 1+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+100);
                  BRK0I3 = true;
                  pr_default.readNext(0);
               }
               if ( ! BRK0I3 )
               {
                  BRK0I3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0I0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void H0I0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "82237a53-0702-4c99-9372-335a44e7524e", "", context.GetTheme( )), 150, Gx_line+0, 275, Gx_line+83) ;
               getPrinter().GxDrawLine(33, Gx_line+100, 791, Gx_line+100, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 16, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Catalogue", 358, Gx_line+33, 470, Gx_line+60, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+102);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         P000I2_A6SellerId = new short[1] ;
         P000I2_A4CategoryId = new short[1] ;
         P000I2_A40000ProductImage_GXI = new string[] {""} ;
         P000I2_A40001SellerPhoto_GXI = new string[] {""} ;
         P000I2_A13ProductPrice = new decimal[1] ;
         P000I2_A11ProductName = new string[] {""} ;
         P000I2_A7SellerName = new string[] {""} ;
         P000I2_A5CategoryName = new string[] {""} ;
         P000I2_A10ProductId = new short[1] ;
         P000I2_A14ProductImage = new string[] {""} ;
         P000I2_A8SellerPhoto = new string[] {""} ;
         A40000ProductImage_GXI = "";
         A40001SellerPhoto_GXI = "";
         A11ProductName = "";
         A7SellerName = "";
         A5CategoryName = "";
         A14ProductImage = "";
         A8SellerPhoto = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aproductslistcategory__default(),
            new Object[][] {
                new Object[] {
               P000I2_A6SellerId, P000I2_A4CategoryId, P000I2_A40000ProductImage_GXI, P000I2_A40001SellerPhoto_GXI, P000I2_A13ProductPrice, P000I2_A11ProductName, P000I2_A7SellerName, P000I2_A5CategoryName, P000I2_A10ProductId, P000I2_A14ProductImage,
               P000I2_A8SellerPhoto
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A6SellerId ;
      private short A4CategoryId ;
      private short A10ProductId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private decimal A13ProductPrice ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string sImgUrl ;
      private bool entryPointCalled ;
      private bool BRK0I3 ;
      private string A40000ProductImage_GXI ;
      private string A40001SellerPhoto_GXI ;
      private string A11ProductName ;
      private string A7SellerName ;
      private string A5CategoryName ;
      private string A14ProductImage ;
      private string A8SellerPhoto ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000I2_A6SellerId ;
      private short[] P000I2_A4CategoryId ;
      private string[] P000I2_A40000ProductImage_GXI ;
      private string[] P000I2_A40001SellerPhoto_GXI ;
      private decimal[] P000I2_A13ProductPrice ;
      private string[] P000I2_A11ProductName ;
      private string[] P000I2_A7SellerName ;
      private string[] P000I2_A5CategoryName ;
      private short[] P000I2_A10ProductId ;
      private string[] P000I2_A14ProductImage ;
      private string[] P000I2_A8SellerPhoto ;
   }

   public class aproductslistcategory__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000I2;
          prmP000I2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000I2", "SELECT T1.[SellerId], T1.[CategoryId], T1.[ProductImage_GXI], T2.[SellerPhoto_GXI], T1.[ProductPrice], T1.[ProductName], T2.[SellerName], T3.[CategoryName], T1.[ProductId], T1.[ProductImage], T2.[SellerPhoto] FROM (([Product] T1 INNER JOIN [Seller] T2 ON T2.[SellerId] = T1.[SellerId]) INNER JOIN [Category] T3 ON T3.[CategoryId] = T1.[CategoryId]) ORDER BY T1.[CategoryId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000I2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(3));
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
                return;
       }
    }

 }

}
