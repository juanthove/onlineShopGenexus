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
   public class ashoppingcartreport : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "ShoppingCartId");
            if ( ! entryPointCalled )
            {
               AV8ShoppingCartId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public ashoppingcartreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public ashoppingcartreport( IGxContext context )
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
            /* Using cursor P000F8 */
            pr_default.execute(0, new Object[] {AV8ShoppingCartId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A10ProductId = P000F8_A10ProductId[0];
               A31ShoppingCartId = P000F8_A31ShoppingCartId[0];
               A40000ProductImage_GXI = P000F8_A40000ProductImage_GXI[0];
               A37ProductQuantity = P000F8_A37ProductQuantity[0];
               A13ProductPrice = P000F8_A13ProductPrice[0];
               A11ProductName = P000F8_A11ProductName[0];
               A36ProductTotalCost = P000F8_A36ProductTotalCost[0];
               n36ProductTotalCost = P000F8_n36ProductTotalCost[0];
               A14ProductImage = P000F8_A14ProductImage[0];
               A40000ProductImage_GXI = P000F8_A40000ProductImage_GXI[0];
               A13ProductPrice = P000F8_A13ProductPrice[0];
               A11ProductName = P000F8_A11ProductName[0];
               A14ProductImage = P000F8_A14ProductImage[0];
               A36ProductTotalCost = P000F8_A36ProductTotalCost[0];
               n36ProductTotalCost = P000F8_n36ProductTotalCost[0];
               H0F0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 11, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A11ProductName, "")), 100, Gx_line+17, 242, Gx_line+37, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage)) ? A40000ProductImage_GXI : A14ProductImage);
               getPrinter().GxDrawBitMap(sImgUrl, 25, Gx_line+17, 75, Gx_line+50) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A13ProductPrice, "ZZZZZZZZZZZZZZ9.99")), 275, Gx_line+17, 426, Gx_line+37, 1+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A37ProductQuantity), "ZZZZZZZZZ9")), 500, Gx_line+17, 584, Gx_line+37, 1+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A36ProductTotalCost, "ZZZZZZZZZZZZZZ9.99")), 658, Gx_line+17, 809, Gx_line+37, 1+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0F0( true, 0) ;
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

      protected void H0F0( bool bFoot ,
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
               getPrinter().GxAttris("Microsoft Sans Serif", 16, false, false, false, false, 0, 139, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("My Shopping Cart", 300, Gx_line+33, 575, Gx_line+60, 0, 0, 0, 0) ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "6650585c-d7d5-4e70-a5d3-b2ff5a69034e", "", context.GetTheme( )), 175, Gx_line+0, 267, Gx_line+83) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+111);
               /* Using cursor P000F16 */
               pr_default.execute(1, new Object[] {AV8ShoppingCartId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A15CustomerId = P000F16_A15CustomerId[0];
                  A1CountryId = P000F16_A1CountryId[0];
                  A31ShoppingCartId = P000F16_A31ShoppingCartId[0];
                  A2CountryName = P000F16_A2CountryName[0];
                  A17CustomerDirectionDestination = P000F16_A17CustomerDirectionDestination[0];
                  A16CustomerName = P000F16_A16CustomerName[0];
                  A33ShoppingCartTotalCost = P000F16_A33ShoppingCartTotalCost[0];
                  n33ShoppingCartTotalCost = P000F16_n33ShoppingCartTotalCost[0];
                  A34ShoppingCartDate = P000F16_A34ShoppingCartDate[0];
                  A1CountryId = P000F16_A1CountryId[0];
                  A17CustomerDirectionDestination = P000F16_A17CustomerDirectionDestination[0];
                  A16CustomerName = P000F16_A16CustomerName[0];
                  A2CountryName = P000F16_A2CountryName[0];
                  A33ShoppingCartTotalCost = P000F16_A33ShoppingCartTotalCost[0];
                  n33ShoppingCartTotalCost = P000F16_n33ShoppingCartTotalCost[0];
                  A35ShoppingCartDeliveryDate = DateTimeUtil.DAdd(A34ShoppingCartDate,+((int)(5)));
                  getPrinter().GxAttris("Microsoft Sans Serif", 11, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A31ShoppingCartId), "ZZZ9")), 183, Gx_line+17, 241, Gx_line+37, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 11, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Shopping Cart:", 58, Gx_line+17, 176, Gx_line+36, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Date:", 333, Gx_line+17, 376, Gx_line+36, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Delivery Date:", 542, Gx_line+17, 652, Gx_line+36, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 11, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A34ShoppingCartDate, "99/99/99"), 400, Gx_line+17, 459, Gx_line+37, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A35ShoppingCartDeliveryDate, "99/99/99"), 667, Gx_line+17, 726, Gx_line+37, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A16CustomerName, "")), 183, Gx_line+50, 476, Gx_line+70, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 11, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Customer:", 58, Gx_line+50, 141, Gx_line+69, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 11, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A17CustomerDirectionDestination, "")), 517, Gx_line+50, 810, Gx_line+70, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 11, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2CountryName, "")), 58, Gx_line+83, 392, Gx_line+103, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A33ShoppingCartTotalCost, "ZZZZZZZZZZZZZZ9.99")), 617, Gx_line+100, 806, Gx_line+122, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Total:", 542, Gx_line+100, 590, Gx_line+121, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(17, Gx_line+133, 817, Gx_line+133, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+144);
                  getPrinter().GxAttris("Microsoft Sans Serif", 11, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Product", 75, Gx_line+17, 137, Gx_line+36, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Price", 325, Gx_line+17, 367, Gx_line+36, 1+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Quantity", 500, Gx_line+17, 566, Gx_line+36, 1+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Total", 717, Gx_line+17, 758, Gx_line+36, 1+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+45);
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
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
         P000F8_A10ProductId = new short[1] ;
         P000F8_A31ShoppingCartId = new short[1] ;
         P000F8_A40000ProductImage_GXI = new string[] {""} ;
         P000F8_A37ProductQuantity = new long[1] ;
         P000F8_A13ProductPrice = new decimal[1] ;
         P000F8_A11ProductName = new string[] {""} ;
         P000F8_A36ProductTotalCost = new decimal[1] ;
         P000F8_n36ProductTotalCost = new bool[] {false} ;
         P000F8_A14ProductImage = new string[] {""} ;
         A40000ProductImage_GXI = "";
         A11ProductName = "";
         A14ProductImage = "";
         sImgUrl = "";
         P000F16_A15CustomerId = new short[1] ;
         P000F16_A1CountryId = new short[1] ;
         P000F16_A31ShoppingCartId = new short[1] ;
         P000F16_A2CountryName = new string[] {""} ;
         P000F16_A17CustomerDirectionDestination = new string[] {""} ;
         P000F16_A16CustomerName = new string[] {""} ;
         P000F16_A33ShoppingCartTotalCost = new decimal[1] ;
         P000F16_n33ShoppingCartTotalCost = new bool[] {false} ;
         P000F16_A34ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         A2CountryName = "";
         A17CustomerDirectionDestination = "";
         A16CustomerName = "";
         A34ShoppingCartDate = DateTime.MinValue;
         A35ShoppingCartDeliveryDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ashoppingcartreport__default(),
            new Object[][] {
                new Object[] {
               P000F8_A10ProductId, P000F8_A31ShoppingCartId, P000F8_A40000ProductImage_GXI, P000F8_A37ProductQuantity, P000F8_A13ProductPrice, P000F8_A11ProductName, P000F8_A36ProductTotalCost, P000F8_n36ProductTotalCost, P000F8_A14ProductImage
               }
               , new Object[] {
               P000F16_A15CustomerId, P000F16_A1CountryId, P000F16_A31ShoppingCartId, P000F16_A2CountryName, P000F16_A17CustomerDirectionDestination, P000F16_A16CustomerName, P000F16_A33ShoppingCartTotalCost, P000F16_n33ShoppingCartTotalCost, P000F16_A34ShoppingCartDate
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV8ShoppingCartId ;
      private short GxWebError ;
      private short A10ProductId ;
      private short A31ShoppingCartId ;
      private short A15CustomerId ;
      private short A1CountryId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long A37ProductQuantity ;
      private decimal A13ProductPrice ;
      private decimal A36ProductTotalCost ;
      private decimal A33ShoppingCartTotalCost ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string sImgUrl ;
      private DateTime A34ShoppingCartDate ;
      private DateTime A35ShoppingCartDeliveryDate ;
      private bool entryPointCalled ;
      private bool n36ProductTotalCost ;
      private bool n33ShoppingCartTotalCost ;
      private string A40000ProductImage_GXI ;
      private string A11ProductName ;
      private string A2CountryName ;
      private string A17CustomerDirectionDestination ;
      private string A16CustomerName ;
      private string A14ProductImage ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000F8_A10ProductId ;
      private short[] P000F8_A31ShoppingCartId ;
      private string[] P000F8_A40000ProductImage_GXI ;
      private long[] P000F8_A37ProductQuantity ;
      private decimal[] P000F8_A13ProductPrice ;
      private string[] P000F8_A11ProductName ;
      private decimal[] P000F8_A36ProductTotalCost ;
      private bool[] P000F8_n36ProductTotalCost ;
      private string[] P000F8_A14ProductImage ;
      private short[] P000F16_A15CustomerId ;
      private short[] P000F16_A1CountryId ;
      private short[] P000F16_A31ShoppingCartId ;
      private string[] P000F16_A2CountryName ;
      private string[] P000F16_A17CustomerDirectionDestination ;
      private string[] P000F16_A16CustomerName ;
      private decimal[] P000F16_A33ShoppingCartTotalCost ;
      private bool[] P000F16_n33ShoppingCartTotalCost ;
      private DateTime[] P000F16_A34ShoppingCartDate ;
   }

   public class ashoppingcartreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000F8;
          prmP000F8 = new Object[] {
          new ParDef("@AV8ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmP000F16;
          prmP000F16 = new Object[] {
          new ParDef("@AV8ShoppingCartId",GXType.Int16,4,0)
          };
          string cmdBufferP000F16;
          cmdBufferP000F16=" SELECT T1.[CustomerId], T2.[CountryId], T1.[ShoppingCartId], T3.[CountryName], T2.[CustomerDirectionDestination], T2.[CustomerName], COALESCE( T4.[ShoppingCartTotalCost], 0) AS ShoppingCartTotalCost, T1.[ShoppingCartDate] FROM ((([ShoppingCart] T1 INNER JOIN [Customer] T2 ON T2.[CustomerId] = T1.[CustomerId]) INNER JOIN [Country] T3 ON T3.[CountryId] = T2.[CountryId]) LEFT JOIN (SELECT SUM(COALESCE( T6.[ProductTotalCost], 0)) AS ShoppingCartTotalCost, T5.[ShoppingCartId] FROM ([ShoppingCartProducts] T5 INNER JOIN (SELECT ( COALESCE( T8.[ProductFinalPrice], 0)) * CAST(T7.[ProductQuantity] AS decimal( 28, 10)) AS ProductTotalCost, T7.[ShoppingCartId], T7.[ProductId] FROM ([ShoppingCartProducts] T7 INNER JOIN (SELECT CASE  WHEN T12.[CategoryId] = COALESCE( T11.[CategoryId], 0) THEN T12.[ProductPrice] + ( T12.[ProductPrice] * CAST(0.05 AS decimal( 28, 10))) WHEN T12.[CategoryId] = COALESCE( T10.[CategoryId], 0) THEN T12.[ProductPrice] - ( T12.[ProductPrice] * CAST(0.1 AS decimal( 28, 10))) ELSE T12.[ProductPrice] END AS ProductFinalPrice, T9.[ShoppingCartId], T9.[ProductId] FROM ((([ShoppingCartProducts] T9 INNER JOIN [Product] T12 ON T12.[ProductId] = T9.[ProductId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Entretenimiento' ) T10 ON T10.[CategoryId] = T12.[CategoryId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Joyeria' ) T11 ON T11.[CategoryId] = T12.[CategoryId]) ) T8 ON T8.[ShoppingCartId] = T7.[ShoppingCartId] AND T8.[ProductId] = T7.[ProductId]) ) T6 ON T6.[ShoppingCartId] = T5.[ShoppingCartId] AND T6.[ProductId] = T5.[ProductId]) GROUP BY T5.[ShoppingCartId] ) T4 ON T4.[ShoppingCartId] = T1.[ShoppingCartId]) WHERE T1.[ShoppingCartId] = @AV8ShoppingCartId "
          + " ORDER BY T1.[ShoppingCartId]" ;
          def= new CursorDef[] {
              new CursorDef("P000F8", "SELECT T1.[ProductId], T1.[ShoppingCartId], T2.[ProductImage_GXI], T1.[ProductQuantity], T2.[ProductPrice], T2.[ProductName], COALESCE( T3.[ProductTotalCost], 0) AS ProductTotalCost, T2.[ProductImage] FROM (([ShoppingCartProducts] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) INNER JOIN (SELECT ( COALESCE( T5.[ProductFinalPrice], 0)) * CAST(T4.[ProductQuantity] AS decimal( 28, 10)) AS ProductTotalCost, T4.[ShoppingCartId], T4.[ProductId] FROM ([ShoppingCartProducts] T4 INNER JOIN (SELECT CASE  WHEN T9.[CategoryId] = COALESCE( T8.[CategoryId], 0) THEN T9.[ProductPrice] + ( T9.[ProductPrice] * CAST(0.05 AS decimal( 28, 10))) WHEN T9.[CategoryId] = COALESCE( T7.[CategoryId], 0) THEN T9.[ProductPrice] - ( T9.[ProductPrice] * CAST(0.1 AS decimal( 28, 10))) ELSE T9.[ProductPrice] END AS ProductFinalPrice, T6.[ShoppingCartId], T6.[ProductId] FROM ((([ShoppingCartProducts] T6 INNER JOIN [Product] T9 ON T9.[ProductId] = T6.[ProductId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Entretenimiento' ) T7 ON T7.[CategoryId] = T9.[CategoryId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Joyeria' ) T8 ON T8.[CategoryId] = T9.[CategoryId]) ) T5 ON T5.[ShoppingCartId] = T4.[ShoppingCartId] AND T5.[ProductId] = T4.[ProductId]) ) T3 ON T3.[ShoppingCartId] = T1.[ShoppingCartId] AND T3.[ProductId] = T1.[ProductId]) WHERE T1.[ShoppingCartId] = @AV8ShoppingCartId ORDER BY T1.[ShoppingCartId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000F16", cmdBufferP000F16,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F16,1, GxCacheFrequency.OFF ,true,true )
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
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                return;
       }
    }

 }

}
