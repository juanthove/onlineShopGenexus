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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class product_bc : GxSilentTrn, IGxSilentTrn
   {
      public product_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public product_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow044( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey044( ) ;
         standaloneModal( ) ;
         AddRow044( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z10ProductId = A10ProductId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_040( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls044( ) ;
            }
            else
            {
               CheckExtendedTable044( ) ;
               if ( AnyError == 0 )
               {
                  ZM044( 5) ;
                  ZM044( 6) ;
                  ZM044( 7) ;
                  ZM044( 8) ;
               }
               CloseExtendedTableCursors044( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12042( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11042( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z11ProductName = A11ProductName;
            Z12ProductDescription = A12ProductDescription;
            Z13ProductPrice = A13ProductPrice;
            Z6SellerId = A6SellerId;
            Z24SupplierId = A24SupplierId;
            Z4CategoryId = A4CategoryId;
            Z41ProductCountryId = A41ProductCountryId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z7SellerName = A7SellerName;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z25SupplierName = A25SupplierName;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z5CategoryName = A5CategoryName;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z42ProductCountryName = A42ProductCountryName;
         }
         if ( GX_JID == -3 )
         {
            Z10ProductId = A10ProductId;
            Z11ProductName = A11ProductName;
            Z12ProductDescription = A12ProductDescription;
            Z13ProductPrice = A13ProductPrice;
            Z14ProductImage = A14ProductImage;
            Z40000ProductImage_GXI = A40000ProductImage_GXI;
            Z6SellerId = A6SellerId;
            Z24SupplierId = A24SupplierId;
            Z4CategoryId = A4CategoryId;
            Z41ProductCountryId = A41ProductCountryId;
            Z7SellerName = A7SellerName;
            Z42ProductCountryName = A42ProductCountryName;
            Z43ProductCountryFlag = A43ProductCountryFlag;
            Z40001ProductCountryFlag_GXI = A40001ProductCountryFlag_GXI;
            Z25SupplierName = A25SupplierName;
            Z5CategoryName = A5CategoryName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load044( )
      {
         /* Using cursor BC00048 */
         pr_default.execute(6, new Object[] {A10ProductId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound4 = 1;
            A11ProductName = BC00048_A11ProductName[0];
            A12ProductDescription = BC00048_A12ProductDescription[0];
            A13ProductPrice = BC00048_A13ProductPrice[0];
            A40000ProductImage_GXI = BC00048_A40000ProductImage_GXI[0];
            A7SellerName = BC00048_A7SellerName[0];
            A42ProductCountryName = BC00048_A42ProductCountryName[0];
            A40001ProductCountryFlag_GXI = BC00048_A40001ProductCountryFlag_GXI[0];
            n40001ProductCountryFlag_GXI = BC00048_n40001ProductCountryFlag_GXI[0];
            A25SupplierName = BC00048_A25SupplierName[0];
            A5CategoryName = BC00048_A5CategoryName[0];
            A6SellerId = BC00048_A6SellerId[0];
            A24SupplierId = BC00048_A24SupplierId[0];
            A4CategoryId = BC00048_A4CategoryId[0];
            A41ProductCountryId = BC00048_A41ProductCountryId[0];
            A14ProductImage = BC00048_A14ProductImage[0];
            A43ProductCountryFlag = BC00048_A43ProductCountryFlag[0];
            ZM044( -3) ;
         }
         pr_default.close(6);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
      }

      protected void CheckExtendedTable044( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00049 */
         pr_default.execute(7, new Object[] {A11ProductName, A10ProductId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Product Name"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(7);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A11ProductName)) )
         {
            GX_msglist.addItem("El nombre no puede estar vacio", 1, "");
            AnyError = 1;
         }
         if ( (Convert.ToDecimal(0)==A13ProductPrice) )
         {
            GX_msglist.addItem("El precio no puede estar vacio", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00044 */
         pr_default.execute(2, new Object[] {A6SellerId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Seller'.", "ForeignKeyNotFound", 1, "SELLERID");
            AnyError = 1;
         }
         A7SellerName = BC00044_A7SellerName[0];
         pr_default.close(2);
         /* Using cursor BC00047 */
         pr_default.execute(5, new Object[] {A41ProductCountryId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Product Country'.", "ForeignKeyNotFound", 1, "PRODUCTCOUNTRYID");
            AnyError = 1;
         }
         A42ProductCountryName = BC00047_A42ProductCountryName[0];
         A40001ProductCountryFlag_GXI = BC00047_A40001ProductCountryFlag_GXI[0];
         n40001ProductCountryFlag_GXI = BC00047_n40001ProductCountryFlag_GXI[0];
         A43ProductCountryFlag = BC00047_A43ProductCountryFlag[0];
         pr_default.close(5);
         /* Using cursor BC00045 */
         pr_default.execute(3, new Object[] {A24SupplierId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
         }
         A25SupplierName = BC00045_A25SupplierName[0];
         pr_default.close(3);
         /* Using cursor BC00046 */
         pr_default.execute(4, new Object[] {A4CategoryId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
         }
         A5CategoryName = BC00046_A5CategoryName[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors044( )
      {
         pr_default.close(2);
         pr_default.close(5);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey044( )
      {
         /* Using cursor BC000410 */
         pr_default.execute(8, new Object[] {A10ProductId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00043 */
         pr_default.execute(1, new Object[] {A10ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 3) ;
            RcdFound4 = 1;
            A10ProductId = BC00043_A10ProductId[0];
            A11ProductName = BC00043_A11ProductName[0];
            A12ProductDescription = BC00043_A12ProductDescription[0];
            A13ProductPrice = BC00043_A13ProductPrice[0];
            A40000ProductImage_GXI = BC00043_A40000ProductImage_GXI[0];
            A6SellerId = BC00043_A6SellerId[0];
            A24SupplierId = BC00043_A24SupplierId[0];
            A4CategoryId = BC00043_A4CategoryId[0];
            A41ProductCountryId = BC00043_A41ProductCountryId[0];
            A14ProductImage = BC00043_A14ProductImage[0];
            Z10ProductId = A10ProductId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode4;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_040( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00042 */
            pr_default.execute(0, new Object[] {A10ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z11ProductName, BC00042_A11ProductName[0]) != 0 ) || ( StringUtil.StrCmp(Z12ProductDescription, BC00042_A12ProductDescription[0]) != 0 ) || ( Z13ProductPrice != BC00042_A13ProductPrice[0] ) || ( Z6SellerId != BC00042_A6SellerId[0] ) || ( Z24SupplierId != BC00042_A24SupplierId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z4CategoryId != BC00042_A4CategoryId[0] ) || ( Z41ProductCountryId != BC00042_A41ProductCountryId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Product"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000411 */
                     pr_default.execute(9, new Object[] {A11ProductName, A12ProductDescription, A13ProductPrice, A14ProductImage, A40000ProductImage_GXI, A6SellerId, A24SupplierId, A4CategoryId, A41ProductCountryId});
                     A10ProductId = BC000411_A10ProductId[0];
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Product");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000412 */
                     pr_default.execute(10, new Object[] {A11ProductName, A12ProductDescription, A13ProductPrice, A6SellerId, A24SupplierId, A4CategoryId, A41ProductCountryId, A10ProductId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Product");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000413 */
            pr_default.execute(11, new Object[] {A14ProductImage, A40000ProductImage_GXI, A10ProductId});
            pr_default.close(11);
            pr_default.SmartCacheProvider.SetUpdated("Product");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000414 */
                  pr_default.execute(12, new Object[] {A10ProductId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Product");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel044( ) ;
         Gx_mode = sMode4;
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000415 */
            pr_default.execute(13, new Object[] {A6SellerId});
            A7SellerName = BC000415_A7SellerName[0];
            pr_default.close(13);
            /* Using cursor BC000416 */
            pr_default.execute(14, new Object[] {A41ProductCountryId});
            A42ProductCountryName = BC000416_A42ProductCountryName[0];
            A40001ProductCountryFlag_GXI = BC000416_A40001ProductCountryFlag_GXI[0];
            n40001ProductCountryFlag_GXI = BC000416_n40001ProductCountryFlag_GXI[0];
            A43ProductCountryFlag = BC000416_A43ProductCountryFlag[0];
            pr_default.close(14);
            /* Using cursor BC000417 */
            pr_default.execute(15, new Object[] {A24SupplierId});
            A25SupplierName = BC000417_A25SupplierName[0];
            pr_default.close(15);
            /* Using cursor BC000418 */
            pr_default.execute(16, new Object[] {A4CategoryId});
            A5CategoryName = BC000418_A5CategoryName[0];
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000419 */
            pr_default.execute(17, new Object[] {A10ProductId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor BC000420 */
            pr_default.execute(18, new Object[] {A10ProductId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Products"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart044( )
      {
         /* Scan By routine */
         /* Using cursor BC000421 */
         pr_default.execute(19, new Object[] {A10ProductId});
         RcdFound4 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound4 = 1;
            A10ProductId = BC000421_A10ProductId[0];
            A11ProductName = BC000421_A11ProductName[0];
            A12ProductDescription = BC000421_A12ProductDescription[0];
            A13ProductPrice = BC000421_A13ProductPrice[0];
            A40000ProductImage_GXI = BC000421_A40000ProductImage_GXI[0];
            A7SellerName = BC000421_A7SellerName[0];
            A42ProductCountryName = BC000421_A42ProductCountryName[0];
            A40001ProductCountryFlag_GXI = BC000421_A40001ProductCountryFlag_GXI[0];
            n40001ProductCountryFlag_GXI = BC000421_n40001ProductCountryFlag_GXI[0];
            A25SupplierName = BC000421_A25SupplierName[0];
            A5CategoryName = BC000421_A5CategoryName[0];
            A6SellerId = BC000421_A6SellerId[0];
            A24SupplierId = BC000421_A24SupplierId[0];
            A4CategoryId = BC000421_A4CategoryId[0];
            A41ProductCountryId = BC000421_A41ProductCountryId[0];
            A14ProductImage = BC000421_A14ProductImage[0];
            A43ProductCountryFlag = BC000421_A43ProductCountryFlag[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound4 = 0;
         ScanKeyLoad044( ) ;
      }

      protected void ScanKeyLoad044( )
      {
         sMode4 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound4 = 1;
            A10ProductId = BC000421_A10ProductId[0];
            A11ProductName = BC000421_A11ProductName[0];
            A12ProductDescription = BC000421_A12ProductDescription[0];
            A13ProductPrice = BC000421_A13ProductPrice[0];
            A40000ProductImage_GXI = BC000421_A40000ProductImage_GXI[0];
            A7SellerName = BC000421_A7SellerName[0];
            A42ProductCountryName = BC000421_A42ProductCountryName[0];
            A40001ProductCountryFlag_GXI = BC000421_A40001ProductCountryFlag_GXI[0];
            n40001ProductCountryFlag_GXI = BC000421_n40001ProductCountryFlag_GXI[0];
            A25SupplierName = BC000421_A25SupplierName[0];
            A5CategoryName = BC000421_A5CategoryName[0];
            A6SellerId = BC000421_A6SellerId[0];
            A24SupplierId = BC000421_A24SupplierId[0];
            A4CategoryId = BC000421_A4CategoryId[0];
            A41ProductCountryId = BC000421_A41ProductCountryId[0];
            A14ProductImage = BC000421_A14ProductImage[0];
            A43ProductCountryFlag = BC000421_A43ProductCountryFlag[0];
         }
         Gx_mode = sMode4;
      }

      protected void ScanKeyEnd044( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void AddRow044( )
      {
         VarsToRow4( bcProduct) ;
      }

      protected void ReadRow044( )
      {
         RowToVars4( bcProduct, 1) ;
      }

      protected void InitializeNonKey044( )
      {
         A11ProductName = "";
         A12ProductDescription = "";
         A13ProductPrice = 0;
         A14ProductImage = "";
         A40000ProductImage_GXI = "";
         A6SellerId = 0;
         A7SellerName = "";
         A41ProductCountryId = 0;
         A42ProductCountryName = "";
         A43ProductCountryFlag = "";
         A40001ProductCountryFlag_GXI = "";
         n40001ProductCountryFlag_GXI = false;
         A24SupplierId = 0;
         A25SupplierName = "";
         A4CategoryId = 0;
         A5CategoryName = "";
         Z11ProductName = "";
         Z12ProductDescription = "";
         Z13ProductPrice = 0;
         Z6SellerId = 0;
         Z24SupplierId = 0;
         Z4CategoryId = 0;
         Z41ProductCountryId = 0;
      }

      protected void InitAll044( )
      {
         A10ProductId = 0;
         InitializeNonKey044( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow4( SdtProduct obj4 )
      {
         obj4.gxTpr_Mode = Gx_mode;
         obj4.gxTpr_Productname = A11ProductName;
         obj4.gxTpr_Productdescription = A12ProductDescription;
         obj4.gxTpr_Productprice = A13ProductPrice;
         obj4.gxTpr_Productimage = A14ProductImage;
         obj4.gxTpr_Productimage_gxi = A40000ProductImage_GXI;
         obj4.gxTpr_Sellerid = A6SellerId;
         obj4.gxTpr_Sellername = A7SellerName;
         obj4.gxTpr_Productcountryid = A41ProductCountryId;
         obj4.gxTpr_Productcountryname = A42ProductCountryName;
         obj4.gxTpr_Productcountryflag = A43ProductCountryFlag;
         obj4.gxTpr_Productcountryflag_gxi = A40001ProductCountryFlag_GXI;
         obj4.gxTpr_Supplierid = A24SupplierId;
         obj4.gxTpr_Suppliername = A25SupplierName;
         obj4.gxTpr_Categoryid = A4CategoryId;
         obj4.gxTpr_Categoryname = A5CategoryName;
         obj4.gxTpr_Productid = A10ProductId;
         obj4.gxTpr_Productid_Z = Z10ProductId;
         obj4.gxTpr_Productname_Z = Z11ProductName;
         obj4.gxTpr_Productdescription_Z = Z12ProductDescription;
         obj4.gxTpr_Productprice_Z = Z13ProductPrice;
         obj4.gxTpr_Sellerid_Z = Z6SellerId;
         obj4.gxTpr_Sellername_Z = Z7SellerName;
         obj4.gxTpr_Productcountryid_Z = Z41ProductCountryId;
         obj4.gxTpr_Productcountryname_Z = Z42ProductCountryName;
         obj4.gxTpr_Supplierid_Z = Z24SupplierId;
         obj4.gxTpr_Suppliername_Z = Z25SupplierName;
         obj4.gxTpr_Categoryid_Z = Z4CategoryId;
         obj4.gxTpr_Categoryname_Z = Z5CategoryName;
         obj4.gxTpr_Productimage_gxi_Z = Z40000ProductImage_GXI;
         obj4.gxTpr_Productcountryflag_gxi_Z = Z40001ProductCountryFlag_GXI;
         obj4.gxTpr_Productcountryflag_gxi_N = (short)(Convert.ToInt16(n40001ProductCountryFlag_GXI));
         obj4.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow4( SdtProduct obj4 )
      {
         obj4.gxTpr_Productid = A10ProductId;
         return  ;
      }

      public void RowToVars4( SdtProduct obj4 ,
                              int forceLoad )
      {
         Gx_mode = obj4.gxTpr_Mode;
         A11ProductName = obj4.gxTpr_Productname;
         A12ProductDescription = obj4.gxTpr_Productdescription;
         A13ProductPrice = obj4.gxTpr_Productprice;
         A14ProductImage = obj4.gxTpr_Productimage;
         A40000ProductImage_GXI = obj4.gxTpr_Productimage_gxi;
         A6SellerId = obj4.gxTpr_Sellerid;
         A7SellerName = obj4.gxTpr_Sellername;
         A41ProductCountryId = obj4.gxTpr_Productcountryid;
         A42ProductCountryName = obj4.gxTpr_Productcountryname;
         A43ProductCountryFlag = obj4.gxTpr_Productcountryflag;
         A40001ProductCountryFlag_GXI = obj4.gxTpr_Productcountryflag_gxi;
         n40001ProductCountryFlag_GXI = false;
         A24SupplierId = obj4.gxTpr_Supplierid;
         A25SupplierName = obj4.gxTpr_Suppliername;
         A4CategoryId = obj4.gxTpr_Categoryid;
         A5CategoryName = obj4.gxTpr_Categoryname;
         A10ProductId = obj4.gxTpr_Productid;
         Z10ProductId = obj4.gxTpr_Productid_Z;
         Z11ProductName = obj4.gxTpr_Productname_Z;
         Z12ProductDescription = obj4.gxTpr_Productdescription_Z;
         Z13ProductPrice = obj4.gxTpr_Productprice_Z;
         Z6SellerId = obj4.gxTpr_Sellerid_Z;
         Z7SellerName = obj4.gxTpr_Sellername_Z;
         Z41ProductCountryId = obj4.gxTpr_Productcountryid_Z;
         Z42ProductCountryName = obj4.gxTpr_Productcountryname_Z;
         Z24SupplierId = obj4.gxTpr_Supplierid_Z;
         Z25SupplierName = obj4.gxTpr_Suppliername_Z;
         Z4CategoryId = obj4.gxTpr_Categoryid_Z;
         Z5CategoryName = obj4.gxTpr_Categoryname_Z;
         Z40000ProductImage_GXI = obj4.gxTpr_Productimage_gxi_Z;
         Z40001ProductCountryFlag_GXI = obj4.gxTpr_Productcountryflag_gxi_Z;
         n40001ProductCountryFlag_GXI = (bool)(Convert.ToBoolean(obj4.gxTpr_Productcountryflag_gxi_N));
         Gx_mode = obj4.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A10ProductId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey044( ) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z10ProductId = A10ProductId;
         }
         ZM044( -3) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars4( bcProduct, 0) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z10ProductId = A10ProductId;
         }
         ZM044( -3) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert044( ) ;
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A10ProductId != Z10ProductId )
               {
                  A10ProductId = Z10ProductId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update044( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A10ProductId != Z10ProductId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert044( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert044( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcProduct, 1) ;
         SaveImpl( ) ;
         VarsToRow4( bcProduct) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcProduct, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
         AfterTrn( ) ;
         VarsToRow4( bcProduct) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow4( bcProduct) ;
         }
         else
         {
            SdtProduct auxBC = new SdtProduct(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A10ProductId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcProduct);
               auxBC.Save();
               bcProduct.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcProduct, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcProduct, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow4( bcProduct) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow4( bcProduct) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcProduct, 0) ;
         GetKey044( ) ;
         if ( RcdFound4 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A10ProductId != Z10ProductId )
            {
               A10ProductId = Z10ProductId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A10ProductId != Z10ProductId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         pr_default.close(13);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(14);
         context.RollbackDataStores("product_bc",pr_default);
         VarsToRow4( bcProduct) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcProduct.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcProduct.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcProduct )
         {
            bcProduct = (SdtProduct)(sdt);
            if ( StringUtil.StrCmp(bcProduct.gxTpr_Mode, "") == 0 )
            {
               bcProduct.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow4( bcProduct) ;
            }
            else
            {
               RowToVars4( bcProduct, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcProduct.gxTpr_Mode, "") == 0 )
            {
               bcProduct.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars4( bcProduct, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtProduct Product_BC
      {
         get {
            return bcProduct ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(13);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z11ProductName = "";
         A11ProductName = "";
         Z12ProductDescription = "";
         A12ProductDescription = "";
         Z7SellerName = "";
         A7SellerName = "";
         Z25SupplierName = "";
         A25SupplierName = "";
         Z5CategoryName = "";
         A5CategoryName = "";
         Z42ProductCountryName = "";
         A42ProductCountryName = "";
         Z14ProductImage = "";
         A14ProductImage = "";
         Z40000ProductImage_GXI = "";
         A40000ProductImage_GXI = "";
         Z43ProductCountryFlag = "";
         A43ProductCountryFlag = "";
         Z40001ProductCountryFlag_GXI = "";
         A40001ProductCountryFlag_GXI = "";
         BC00048_A10ProductId = new short[1] ;
         BC00048_A11ProductName = new string[] {""} ;
         BC00048_A12ProductDescription = new string[] {""} ;
         BC00048_A13ProductPrice = new decimal[1] ;
         BC00048_A40000ProductImage_GXI = new string[] {""} ;
         BC00048_A7SellerName = new string[] {""} ;
         BC00048_A42ProductCountryName = new string[] {""} ;
         BC00048_A40001ProductCountryFlag_GXI = new string[] {""} ;
         BC00048_n40001ProductCountryFlag_GXI = new bool[] {false} ;
         BC00048_A25SupplierName = new string[] {""} ;
         BC00048_A5CategoryName = new string[] {""} ;
         BC00048_A6SellerId = new short[1] ;
         BC00048_A24SupplierId = new short[1] ;
         BC00048_A4CategoryId = new short[1] ;
         BC00048_A41ProductCountryId = new short[1] ;
         BC00048_A14ProductImage = new string[] {""} ;
         BC00048_A43ProductCountryFlag = new string[] {""} ;
         BC00049_A11ProductName = new string[] {""} ;
         BC00044_A7SellerName = new string[] {""} ;
         BC00047_A42ProductCountryName = new string[] {""} ;
         BC00047_A40001ProductCountryFlag_GXI = new string[] {""} ;
         BC00047_n40001ProductCountryFlag_GXI = new bool[] {false} ;
         BC00047_A43ProductCountryFlag = new string[] {""} ;
         BC00045_A25SupplierName = new string[] {""} ;
         BC00046_A5CategoryName = new string[] {""} ;
         BC000410_A10ProductId = new short[1] ;
         BC00043_A10ProductId = new short[1] ;
         BC00043_A11ProductName = new string[] {""} ;
         BC00043_A12ProductDescription = new string[] {""} ;
         BC00043_A13ProductPrice = new decimal[1] ;
         BC00043_A40000ProductImage_GXI = new string[] {""} ;
         BC00043_A6SellerId = new short[1] ;
         BC00043_A24SupplierId = new short[1] ;
         BC00043_A4CategoryId = new short[1] ;
         BC00043_A41ProductCountryId = new short[1] ;
         BC00043_A14ProductImage = new string[] {""} ;
         sMode4 = "";
         BC00042_A10ProductId = new short[1] ;
         BC00042_A11ProductName = new string[] {""} ;
         BC00042_A12ProductDescription = new string[] {""} ;
         BC00042_A13ProductPrice = new decimal[1] ;
         BC00042_A40000ProductImage_GXI = new string[] {""} ;
         BC00042_A6SellerId = new short[1] ;
         BC00042_A24SupplierId = new short[1] ;
         BC00042_A4CategoryId = new short[1] ;
         BC00042_A41ProductCountryId = new short[1] ;
         BC00042_A14ProductImage = new string[] {""} ;
         BC000411_A10ProductId = new short[1] ;
         BC000415_A7SellerName = new string[] {""} ;
         BC000416_A42ProductCountryName = new string[] {""} ;
         BC000416_A40001ProductCountryFlag_GXI = new string[] {""} ;
         BC000416_n40001ProductCountryFlag_GXI = new bool[] {false} ;
         BC000416_A43ProductCountryFlag = new string[] {""} ;
         BC000417_A25SupplierName = new string[] {""} ;
         BC000418_A5CategoryName = new string[] {""} ;
         BC000419_A26PromotionId = new short[1] ;
         BC000419_A10ProductId = new short[1] ;
         BC000420_A31ShoppingCartId = new short[1] ;
         BC000420_A10ProductId = new short[1] ;
         BC000421_A10ProductId = new short[1] ;
         BC000421_A11ProductName = new string[] {""} ;
         BC000421_A12ProductDescription = new string[] {""} ;
         BC000421_A13ProductPrice = new decimal[1] ;
         BC000421_A40000ProductImage_GXI = new string[] {""} ;
         BC000421_A7SellerName = new string[] {""} ;
         BC000421_A42ProductCountryName = new string[] {""} ;
         BC000421_A40001ProductCountryFlag_GXI = new string[] {""} ;
         BC000421_n40001ProductCountryFlag_GXI = new bool[] {false} ;
         BC000421_A25SupplierName = new string[] {""} ;
         BC000421_A5CategoryName = new string[] {""} ;
         BC000421_A6SellerId = new short[1] ;
         BC000421_A24SupplierId = new short[1] ;
         BC000421_A4CategoryId = new short[1] ;
         BC000421_A41ProductCountryId = new short[1] ;
         BC000421_A14ProductImage = new string[] {""} ;
         BC000421_A43ProductCountryFlag = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.product_bc__default(),
            new Object[][] {
                new Object[] {
               BC00042_A10ProductId, BC00042_A11ProductName, BC00042_A12ProductDescription, BC00042_A13ProductPrice, BC00042_A40000ProductImage_GXI, BC00042_A6SellerId, BC00042_A24SupplierId, BC00042_A4CategoryId, BC00042_A41ProductCountryId, BC00042_A14ProductImage
               }
               , new Object[] {
               BC00043_A10ProductId, BC00043_A11ProductName, BC00043_A12ProductDescription, BC00043_A13ProductPrice, BC00043_A40000ProductImage_GXI, BC00043_A6SellerId, BC00043_A24SupplierId, BC00043_A4CategoryId, BC00043_A41ProductCountryId, BC00043_A14ProductImage
               }
               , new Object[] {
               BC00044_A7SellerName
               }
               , new Object[] {
               BC00045_A25SupplierName
               }
               , new Object[] {
               BC00046_A5CategoryName
               }
               , new Object[] {
               BC00047_A42ProductCountryName, BC00047_A40001ProductCountryFlag_GXI, BC00047_n40001ProductCountryFlag_GXI, BC00047_A43ProductCountryFlag
               }
               , new Object[] {
               BC00048_A10ProductId, BC00048_A11ProductName, BC00048_A12ProductDescription, BC00048_A13ProductPrice, BC00048_A40000ProductImage_GXI, BC00048_A7SellerName, BC00048_A42ProductCountryName, BC00048_A40001ProductCountryFlag_GXI, BC00048_n40001ProductCountryFlag_GXI, BC00048_A25SupplierName,
               BC00048_A5CategoryName, BC00048_A6SellerId, BC00048_A24SupplierId, BC00048_A4CategoryId, BC00048_A41ProductCountryId, BC00048_A14ProductImage, BC00048_A43ProductCountryFlag
               }
               , new Object[] {
               BC00049_A11ProductName
               }
               , new Object[] {
               BC000410_A10ProductId
               }
               , new Object[] {
               BC000411_A10ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000415_A7SellerName
               }
               , new Object[] {
               BC000416_A42ProductCountryName, BC000416_A40001ProductCountryFlag_GXI, BC000416_n40001ProductCountryFlag_GXI, BC000416_A43ProductCountryFlag
               }
               , new Object[] {
               BC000417_A25SupplierName
               }
               , new Object[] {
               BC000418_A5CategoryName
               }
               , new Object[] {
               BC000419_A26PromotionId, BC000419_A10ProductId
               }
               , new Object[] {
               BC000420_A31ShoppingCartId, BC000420_A10ProductId
               }
               , new Object[] {
               BC000421_A10ProductId, BC000421_A11ProductName, BC000421_A12ProductDescription, BC000421_A13ProductPrice, BC000421_A40000ProductImage_GXI, BC000421_A7SellerName, BC000421_A42ProductCountryName, BC000421_A40001ProductCountryFlag_GXI, BC000421_n40001ProductCountryFlag_GXI, BC000421_A25SupplierName,
               BC000421_A5CategoryName, BC000421_A6SellerId, BC000421_A24SupplierId, BC000421_A4CategoryId, BC000421_A41ProductCountryId, BC000421_A14ProductImage, BC000421_A43ProductCountryFlag
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12042 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z10ProductId ;
      private short A10ProductId ;
      private short Z6SellerId ;
      private short A6SellerId ;
      private short Z24SupplierId ;
      private short A24SupplierId ;
      private short Z4CategoryId ;
      private short A4CategoryId ;
      private short Z41ProductCountryId ;
      private short A41ProductCountryId ;
      private short RcdFound4 ;
      private int trnEnded ;
      private decimal Z13ProductPrice ;
      private decimal A13ProductPrice ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode4 ;
      private bool returnInSub ;
      private bool n40001ProductCountryFlag_GXI ;
      private bool Gx_longc ;
      private string Z11ProductName ;
      private string A11ProductName ;
      private string Z12ProductDescription ;
      private string A12ProductDescription ;
      private string Z7SellerName ;
      private string A7SellerName ;
      private string Z25SupplierName ;
      private string A25SupplierName ;
      private string Z5CategoryName ;
      private string A5CategoryName ;
      private string Z42ProductCountryName ;
      private string A42ProductCountryName ;
      private string Z40000ProductImage_GXI ;
      private string A40000ProductImage_GXI ;
      private string Z40001ProductCountryFlag_GXI ;
      private string A40001ProductCountryFlag_GXI ;
      private string Z14ProductImage ;
      private string A14ProductImage ;
      private string Z43ProductCountryFlag ;
      private string A43ProductCountryFlag ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00048_A10ProductId ;
      private string[] BC00048_A11ProductName ;
      private string[] BC00048_A12ProductDescription ;
      private decimal[] BC00048_A13ProductPrice ;
      private string[] BC00048_A40000ProductImage_GXI ;
      private string[] BC00048_A7SellerName ;
      private string[] BC00048_A42ProductCountryName ;
      private string[] BC00048_A40001ProductCountryFlag_GXI ;
      private bool[] BC00048_n40001ProductCountryFlag_GXI ;
      private string[] BC00048_A25SupplierName ;
      private string[] BC00048_A5CategoryName ;
      private short[] BC00048_A6SellerId ;
      private short[] BC00048_A24SupplierId ;
      private short[] BC00048_A4CategoryId ;
      private short[] BC00048_A41ProductCountryId ;
      private string[] BC00048_A14ProductImage ;
      private string[] BC00048_A43ProductCountryFlag ;
      private string[] BC00049_A11ProductName ;
      private string[] BC00044_A7SellerName ;
      private string[] BC00047_A42ProductCountryName ;
      private string[] BC00047_A40001ProductCountryFlag_GXI ;
      private bool[] BC00047_n40001ProductCountryFlag_GXI ;
      private string[] BC00047_A43ProductCountryFlag ;
      private string[] BC00045_A25SupplierName ;
      private string[] BC00046_A5CategoryName ;
      private short[] BC000410_A10ProductId ;
      private short[] BC00043_A10ProductId ;
      private string[] BC00043_A11ProductName ;
      private string[] BC00043_A12ProductDescription ;
      private decimal[] BC00043_A13ProductPrice ;
      private string[] BC00043_A40000ProductImage_GXI ;
      private short[] BC00043_A6SellerId ;
      private short[] BC00043_A24SupplierId ;
      private short[] BC00043_A4CategoryId ;
      private short[] BC00043_A41ProductCountryId ;
      private string[] BC00043_A14ProductImage ;
      private short[] BC00042_A10ProductId ;
      private string[] BC00042_A11ProductName ;
      private string[] BC00042_A12ProductDescription ;
      private decimal[] BC00042_A13ProductPrice ;
      private string[] BC00042_A40000ProductImage_GXI ;
      private short[] BC00042_A6SellerId ;
      private short[] BC00042_A24SupplierId ;
      private short[] BC00042_A4CategoryId ;
      private short[] BC00042_A41ProductCountryId ;
      private string[] BC00042_A14ProductImage ;
      private short[] BC000411_A10ProductId ;
      private string[] BC000415_A7SellerName ;
      private string[] BC000416_A42ProductCountryName ;
      private string[] BC000416_A40001ProductCountryFlag_GXI ;
      private bool[] BC000416_n40001ProductCountryFlag_GXI ;
      private string[] BC000416_A43ProductCountryFlag ;
      private string[] BC000417_A25SupplierName ;
      private string[] BC000418_A5CategoryName ;
      private short[] BC000419_A26PromotionId ;
      private short[] BC000419_A10ProductId ;
      private short[] BC000420_A31ShoppingCartId ;
      private short[] BC000420_A10ProductId ;
      private short[] BC000421_A10ProductId ;
      private string[] BC000421_A11ProductName ;
      private string[] BC000421_A12ProductDescription ;
      private decimal[] BC000421_A13ProductPrice ;
      private string[] BC000421_A40000ProductImage_GXI ;
      private string[] BC000421_A7SellerName ;
      private string[] BC000421_A42ProductCountryName ;
      private string[] BC000421_A40001ProductCountryFlag_GXI ;
      private bool[] BC000421_n40001ProductCountryFlag_GXI ;
      private string[] BC000421_A25SupplierName ;
      private string[] BC000421_A5CategoryName ;
      private short[] BC000421_A6SellerId ;
      private short[] BC000421_A24SupplierId ;
      private short[] BC000421_A4CategoryId ;
      private short[] BC000421_A41ProductCountryId ;
      private string[] BC000421_A14ProductImage ;
      private string[] BC000421_A43ProductCountryFlag ;
      private SdtProduct bcProduct ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class product_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00042;
          prmBC00042 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00043;
          prmBC00043 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00044;
          prmBC00044 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmBC00045;
          prmBC00045 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0)
          };
          Object[] prmBC00046;
          prmBC00046 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmBC00047;
          prmBC00047 = new Object[] {
          new ParDef("@ProductCountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00048;
          prmBC00048 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00049;
          prmBC00049 = new Object[] {
          new ParDef("@ProductName",GXType.NVarChar,40,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000410;
          prmBC000410 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000411;
          prmBC000411 = new Object[] {
          new ParDef("@ProductName",GXType.NVarChar,40,0) ,
          new ParDef("@ProductDescription",GXType.NVarChar,200,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,18,2) ,
          new ParDef("@ProductImage",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="Product", Fld="ProductImage"} ,
          new ParDef("@SellerId",GXType.Int16,4,0) ,
          new ParDef("@SupplierId",GXType.Int16,4,0) ,
          new ParDef("@CategoryId",GXType.Int16,4,0) ,
          new ParDef("@ProductCountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000412;
          prmBC000412 = new Object[] {
          new ParDef("@ProductName",GXType.NVarChar,40,0) ,
          new ParDef("@ProductDescription",GXType.NVarChar,200,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,18,2) ,
          new ParDef("@SellerId",GXType.Int16,4,0) ,
          new ParDef("@SupplierId",GXType.Int16,4,0) ,
          new ParDef("@CategoryId",GXType.Int16,4,0) ,
          new ParDef("@ProductCountryId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000413;
          prmBC000413 = new Object[] {
          new ParDef("@ProductImage",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Product", Fld="ProductImage"} ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000414;
          prmBC000414 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000415;
          prmBC000415 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmBC000416;
          prmBC000416 = new Object[] {
          new ParDef("@ProductCountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000417;
          prmBC000417 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0)
          };
          Object[] prmBC000418;
          prmBC000418 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmBC000419;
          prmBC000419 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000420;
          prmBC000420 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000421;
          prmBC000421 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00042", "SELECT [ProductId], [ProductName], [ProductDescription], [ProductPrice], [ProductImage_GXI], [SellerId], [SupplierId], [CategoryId], [ProductCountryId] AS ProductCountryId, [ProductImage] FROM [Product] WITH (UPDLOCK) WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00043", "SELECT [ProductId], [ProductName], [ProductDescription], [ProductPrice], [ProductImage_GXI], [SellerId], [SupplierId], [CategoryId], [ProductCountryId] AS ProductCountryId, [ProductImage] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00044", "SELECT [SellerName] FROM [Seller] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00044,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00045", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00045,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00046", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00046,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00047", "SELECT [CountryName] AS ProductCountryName, [CountryFlag_GXI] AS ProductCountryFlag_GXI, [CountryFlag] AS ProductCountryFlag FROM [Country] WHERE [CountryId] = @ProductCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00047,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00048", "SELECT TM1.[ProductId], TM1.[ProductName], TM1.[ProductDescription], TM1.[ProductPrice], TM1.[ProductImage_GXI], T2.[SellerName], T3.[CountryName] AS ProductCountryName, T3.[CountryFlag_GXI] AS ProductCountryFlag_GXI, T4.[SupplierName], T5.[CategoryName], TM1.[SellerId], TM1.[SupplierId], TM1.[CategoryId], TM1.[ProductCountryId] AS ProductCountryId, TM1.[ProductImage], T3.[CountryFlag] AS ProductCountryFlag FROM (((([Product] TM1 INNER JOIN [Seller] T2 ON T2.[SellerId] = TM1.[SellerId]) INNER JOIN [Country] T3 ON T3.[CountryId] = TM1.[ProductCountryId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = TM1.[SupplierId]) INNER JOIN [Category] T5 ON T5.[CategoryId] = TM1.[CategoryId]) WHERE TM1.[ProductId] = @ProductId ORDER BY TM1.[ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00048,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00049", "SELECT [ProductName] FROM [Product] WHERE ([ProductName] = @ProductName) AND (Not ( [ProductId] = @ProductId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00049,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000410", "SELECT [ProductId] FROM [Product] WHERE [ProductId] = @ProductId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000410,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000411", "INSERT INTO [Product]([ProductName], [ProductDescription], [ProductPrice], [ProductImage], [ProductImage_GXI], [SellerId], [SupplierId], [CategoryId], [ProductCountryId]) VALUES(@ProductName, @ProductDescription, @ProductPrice, @ProductImage, @ProductImage_GXI, @SellerId, @SupplierId, @CategoryId, @ProductCountryId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000411,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000412", "UPDATE [Product] SET [ProductName]=@ProductName, [ProductDescription]=@ProductDescription, [ProductPrice]=@ProductPrice, [SellerId]=@SellerId, [SupplierId]=@SupplierId, [CategoryId]=@CategoryId, [ProductCountryId]=@ProductCountryId  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000412)
             ,new CursorDef("BC000413", "UPDATE [Product] SET [ProductImage]=@ProductImage, [ProductImage_GXI]=@ProductImage_GXI  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000413)
             ,new CursorDef("BC000414", "DELETE FROM [Product]  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000414)
             ,new CursorDef("BC000415", "SELECT [SellerName] FROM [Seller] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000415,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000416", "SELECT [CountryName] AS ProductCountryName, [CountryFlag_GXI] AS ProductCountryFlag_GXI, [CountryFlag] AS ProductCountryFlag FROM [Country] WHERE [CountryId] = @ProductCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000416,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000417", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000417,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000418", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000418,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000419", "SELECT TOP 1 [PromotionId], [ProductId] FROM [PromotionProduct] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000419,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000420", "SELECT TOP 1 [ShoppingCartId], [ProductId] FROM [ShoppingCartProducts] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000420,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000421", "SELECT TM1.[ProductId], TM1.[ProductName], TM1.[ProductDescription], TM1.[ProductPrice], TM1.[ProductImage_GXI], T2.[SellerName], T3.[CountryName] AS ProductCountryName, T3.[CountryFlag_GXI] AS ProductCountryFlag_GXI, T4.[SupplierName], T5.[CategoryName], TM1.[SellerId], TM1.[SupplierId], TM1.[CategoryId], TM1.[ProductCountryId] AS ProductCountryId, TM1.[ProductImage], T3.[CountryFlag] AS ProductCountryFlag FROM (((([Product] TM1 INNER JOIN [Seller] T2 ON T2.[SellerId] = TM1.[SellerId]) INNER JOIN [Country] T3 ON T3.[CountryId] = TM1.[ProductCountryId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = TM1.[SupplierId]) INNER JOIN [Category] T5 ON T5.[CategoryId] = TM1.[CategoryId]) WHERE TM1.[ProductId] = @ProductId ORDER BY TM1.[ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000421,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                ((short[]) buf[12])[0] = rslt.getShort(12);
                ((short[]) buf[13])[0] = rslt.getShort(13);
                ((short[]) buf[14])[0] = rslt.getShort(14);
                ((string[]) buf[15])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(5));
                ((string[]) buf[16])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(8));
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                ((short[]) buf[12])[0] = rslt.getShort(12);
                ((short[]) buf[13])[0] = rslt.getShort(13);
                ((short[]) buf[14])[0] = rslt.getShort(14);
                ((string[]) buf[15])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(5));
                ((string[]) buf[16])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(8));
                return;
       }
    }

 }

}
