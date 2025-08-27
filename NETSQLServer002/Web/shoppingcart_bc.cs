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
   public class shoppingcart_bc : GxSilentTrn, IGxSilentTrn
   {
      public shoppingcart_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public shoppingcart_bc( IGxContext context )
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
         ReadRow099( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey099( ) ;
         standaloneModal( ) ;
         AddRow099( ) ;
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
            E11092 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z31ShoppingCartId = A31ShoppingCartId;
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

      protected void CONFIRM_090( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls099( ) ;
            }
            else
            {
               CheckExtendedTable099( ) ;
               if ( AnyError == 0 )
               {
                  ZM099( 12) ;
                  ZM099( 13) ;
                  ZM099( 14) ;
               }
               CloseExtendedTableCursors099( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode9 = Gx_mode;
            CONFIRM_0910( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode9;
            }
            /* Restore parent mode. */
            Gx_mode = sMode9;
         }
      }

      protected void CONFIRM_0910( )
      {
         s33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
         n33ShoppingCartTotalCost = false;
         nGXsfl_10_idx = 0;
         while ( nGXsfl_10_idx < bcShoppingCart.gxTpr_Product.Count )
         {
            ReadRow0910( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound10 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_10 != 0 ) )
            {
               GetKey0910( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound10 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0910( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0910( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0910( 16) ;
                           ZM0910( 17) ;
                        }
                        CloseExtendedTableCursors0910( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        O33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
                        n33ShoppingCartTotalCost = false;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound10 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0910( ) ;
                        Load0910( ) ;
                        BeforeValidate0910( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0910( ) ;
                           O33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
                           n33ShoppingCartTotalCost = false;
                        }
                     }
                     else
                     {
                        if ( nIsMod_10 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0910( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0910( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0910( 16) ;
                                 ZM0910( 17) ;
                              }
                              CloseExtendedTableCursors0910( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              O33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
                              n33ShoppingCartTotalCost = false;
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow10( ((SdtShoppingCart_Product)bcShoppingCart.gxTpr_Product.Item(nGXsfl_10_idx))) ;
            }
         }
         O33ShoppingCartTotalCost = s33ShoppingCartTotalCost;
         n33ShoppingCartTotalCost = false;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E12092( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11092( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            if ( ( A33ShoppingCartTotalCost >= Convert.ToDecimal( 1000 )) )
            {
               new accumulatepoints(context ).execute(  A15CustomerId,  A33ShoppingCartTotalCost) ;
            }
            context.PopUp(formatLink("ashoppingcartreport.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A31ShoppingCartId,4,0))}, new string[] {"ShoppingCartId"}) , new Object[] {});
         }
      }

      protected void ZM099( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z34ShoppingCartDate = A34ShoppingCartDate;
            Z15CustomerId = A15CustomerId;
            Z33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
            Z35ShoppingCartDeliveryDate = A35ShoppingCartDeliveryDate;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z16CustomerName = A16CustomerName;
            Z17CustomerDirectionDestination = A17CustomerDirectionDestination;
            Z1CountryId = A1CountryId;
            Z33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
            Z35ShoppingCartDeliveryDate = A35ShoppingCartDeliveryDate;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z2CountryName = A2CountryName;
            Z33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
            Z35ShoppingCartDeliveryDate = A35ShoppingCartDeliveryDate;
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
            Z35ShoppingCartDeliveryDate = A35ShoppingCartDeliveryDate;
         }
         if ( GX_JID == -11 )
         {
            Z31ShoppingCartId = A31ShoppingCartId;
            Z34ShoppingCartDate = A34ShoppingCartDate;
            Z15CustomerId = A15CustomerId;
            Z33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
            Z16CustomerName = A16CustomerName;
            Z17CustomerDirectionDestination = A17CustomerDirectionDestination;
            Z1CountryId = A1CountryId;
            Z2CountryName = A2CountryName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A34ShoppingCartDate) && ( Gx_BScreen == 0 ) )
         {
            A34ShoppingCartDate = Gx_date;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            A35ShoppingCartDeliveryDate = DateTimeUtil.DAdd(A34ShoppingCartDate,+((int)(5)));
         }
      }

      protected void Load099( )
      {
         /* Using cursor BC000925 */
         pr_default.execute(9, new Object[] {A31ShoppingCartId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound9 = 1;
            A34ShoppingCartDate = BC000925_A34ShoppingCartDate[0];
            A16CustomerName = BC000925_A16CustomerName[0];
            A17CustomerDirectionDestination = BC000925_A17CustomerDirectionDestination[0];
            A2CountryName = BC000925_A2CountryName[0];
            A15CustomerId = BC000925_A15CustomerId[0];
            A1CountryId = BC000925_A1CountryId[0];
            A33ShoppingCartTotalCost = BC000925_A33ShoppingCartTotalCost[0];
            n33ShoppingCartTotalCost = BC000925_n33ShoppingCartTotalCost[0];
            ZM099( -11) ;
         }
         pr_default.close(9);
         OnLoadActions099( ) ;
      }

      protected void OnLoadActions099( )
      {
         O33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
         n33ShoppingCartTotalCost = false;
         A35ShoppingCartDeliveryDate = DateTimeUtil.DAdd(A34ShoppingCartDate,+((int)(5)));
      }

      protected void CheckExtendedTable099( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000917 */
         pr_default.execute(8, new Object[] {A31ShoppingCartId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A33ShoppingCartTotalCost = BC000917_A33ShoppingCartTotalCost[0];
            n33ShoppingCartTotalCost = BC000917_n33ShoppingCartTotalCost[0];
         }
         else
         {
            A33ShoppingCartTotalCost = 0;
            n33ShoppingCartTotalCost = false;
         }
         pr_default.close(8);
         if ( ! ( (DateTime.MinValue==A34ShoppingCartDate) || ( DateTimeUtil.ResetTime ( A34ShoppingCartDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Shopping Cart Date fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         A35ShoppingCartDeliveryDate = DateTimeUtil.DAdd(A34ShoppingCartDate,+((int)(5)));
         /* Using cursor BC00098 */
         pr_default.execute(6, new Object[] {A15CustomerId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Customer'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
         }
         A16CustomerName = BC00098_A16CustomerName[0];
         A17CustomerDirectionDestination = BC00098_A17CustomerDirectionDestination[0];
         A1CountryId = BC00098_A1CountryId[0];
         pr_default.close(6);
         /* Using cursor BC00099 */
         pr_default.execute(7, new Object[] {A1CountryId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A2CountryName = BC00099_A2CountryName[0];
         pr_default.close(7);
         if ( (0==A15CustomerId) )
         {
            GX_msglist.addItem("Debe seleccionar un cliente", 1, "");
            AnyError = 1;
         }
         if ( DateTimeUtil.ResetTime ( A34ShoppingCartDate ) > DateTimeUtil.ResetTime ( Gx_date ) )
         {
            GX_msglist.addItem("El carrito debe ser de una fecha anterior a hoy", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors099( )
      {
         pr_default.close(8);
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey099( )
      {
         /* Using cursor BC000926 */
         pr_default.execute(10, new Object[] {A31ShoppingCartId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00097 */
         pr_default.execute(5, new Object[] {A31ShoppingCartId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM099( 11) ;
            RcdFound9 = 1;
            A31ShoppingCartId = BC00097_A31ShoppingCartId[0];
            A34ShoppingCartDate = BC00097_A34ShoppingCartDate[0];
            A15CustomerId = BC00097_A15CustomerId[0];
            Z31ShoppingCartId = A31ShoppingCartId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load099( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey099( ) ;
            }
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey099( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode9;
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey099( ) ;
         if ( RcdFound9 == 0 )
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
         CONFIRM_090( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency099( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00096 */
            pr_default.execute(4, new Object[] {A31ShoppingCartId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCart"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( DateTimeUtil.ResetTime ( Z34ShoppingCartDate ) != DateTimeUtil.ResetTime ( BC00096_A34ShoppingCartDate[0] ) ) || ( Z15CustomerId != BC00096_A15CustomerId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ShoppingCart"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM099( 0) ;
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000927 */
                     pr_default.execute(11, new Object[] {A34ShoppingCartDate, A15CustomerId});
                     A31ShoppingCartId = BC000927_A31ShoppingCartId[0];
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("ShoppingCart");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel099( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load099( ) ;
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void Update099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000928 */
                     pr_default.execute(12, new Object[] {A34ShoppingCartDate, A15CustomerId, A31ShoppingCartId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("ShoppingCart");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCart"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate099( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel099( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void DeferredUpdate099( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls099( ) ;
            AfterConfirm099( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete099( ) ;
               if ( AnyError == 0 )
               {
                  A33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
                  n33ShoppingCartTotalCost = false;
                  ScanKeyStart0910( ) ;
                  while ( RcdFound10 != 0 )
                  {
                     getByPrimaryKey0910( ) ;
                     Delete0910( ) ;
                     ScanKeyNext0910( ) ;
                     O33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
                     n33ShoppingCartTotalCost = false;
                  }
                  ScanKeyEnd0910( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000929 */
                     pr_default.execute(13, new Object[] {A31ShoppingCartId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("ShoppingCart");
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
         }
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel099( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls099( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000937 */
            pr_default.execute(14, new Object[] {A31ShoppingCartId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               A33ShoppingCartTotalCost = BC000937_A33ShoppingCartTotalCost[0];
               n33ShoppingCartTotalCost = BC000937_n33ShoppingCartTotalCost[0];
            }
            else
            {
               A33ShoppingCartTotalCost = 0;
               n33ShoppingCartTotalCost = false;
            }
            pr_default.close(14);
            A35ShoppingCartDeliveryDate = DateTimeUtil.DAdd(A34ShoppingCartDate,+((int)(5)));
            /* Using cursor BC000938 */
            pr_default.execute(15, new Object[] {A15CustomerId});
            A16CustomerName = BC000938_A16CustomerName[0];
            A17CustomerDirectionDestination = BC000938_A17CustomerDirectionDestination[0];
            A1CountryId = BC000938_A1CountryId[0];
            pr_default.close(15);
            /* Using cursor BC000939 */
            pr_default.execute(16, new Object[] {A1CountryId});
            A2CountryName = BC000939_A2CountryName[0];
            pr_default.close(16);
         }
      }

      protected void ProcessNestedLevel0910( )
      {
         s33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
         n33ShoppingCartTotalCost = false;
         nGXsfl_10_idx = 0;
         while ( nGXsfl_10_idx < bcShoppingCart.gxTpr_Product.Count )
         {
            ReadRow0910( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound10 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_10 != 0 ) )
            {
               standaloneNotModal0910( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0910( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0910( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0910( ) ;
                  }
               }
               O33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
               n33ShoppingCartTotalCost = false;
            }
            KeyVarsToRow10( ((SdtShoppingCart_Product)bcShoppingCart.gxTpr_Product.Item(nGXsfl_10_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_10_idx = 0;
            while ( nGXsfl_10_idx < bcShoppingCart.gxTpr_Product.Count )
            {
               ReadRow0910( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound10 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcShoppingCart.gxTpr_Product.RemoveElement(nGXsfl_10_idx);
                  nGXsfl_10_idx = (int)(nGXsfl_10_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0910( ) ;
                  VarsToRow10( ((SdtShoppingCart_Product)bcShoppingCart.gxTpr_Product.Item(nGXsfl_10_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0910( ) ;
         if ( AnyError != 0 )
         {
            O33ShoppingCartTotalCost = s33ShoppingCartTotalCost;
            n33ShoppingCartTotalCost = false;
         }
         nRcdExists_10 = 0;
         nIsMod_10 = 0;
      }

      protected void ProcessLevel099( )
      {
         /* Save parent mode. */
         sMode9 = Gx_mode;
         ProcessNestedLevel0910( ) ;
         if ( AnyError != 0 )
         {
            O33ShoppingCartTotalCost = s33ShoppingCartTotalCost;
            n33ShoppingCartTotalCost = false;
         }
         /* Restore parent mode. */
         Gx_mode = sMode9;
         /* ' Update level parameters */
      }

      protected void EndLevel099( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete099( ) ;
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

      public void ScanKeyStart099( )
      {
         /* Scan By routine */
         /* Using cursor BC000947 */
         pr_default.execute(17, new Object[] {A31ShoppingCartId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound9 = 1;
            A31ShoppingCartId = BC000947_A31ShoppingCartId[0];
            A34ShoppingCartDate = BC000947_A34ShoppingCartDate[0];
            A16CustomerName = BC000947_A16CustomerName[0];
            A17CustomerDirectionDestination = BC000947_A17CustomerDirectionDestination[0];
            A2CountryName = BC000947_A2CountryName[0];
            A15CustomerId = BC000947_A15CustomerId[0];
            A1CountryId = BC000947_A1CountryId[0];
            A33ShoppingCartTotalCost = BC000947_A33ShoppingCartTotalCost[0];
            n33ShoppingCartTotalCost = BC000947_n33ShoppingCartTotalCost[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext099( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound9 = 0;
         ScanKeyLoad099( ) ;
      }

      protected void ScanKeyLoad099( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound9 = 1;
            A31ShoppingCartId = BC000947_A31ShoppingCartId[0];
            A34ShoppingCartDate = BC000947_A34ShoppingCartDate[0];
            A16CustomerName = BC000947_A16CustomerName[0];
            A17CustomerDirectionDestination = BC000947_A17CustomerDirectionDestination[0];
            A2CountryName = BC000947_A2CountryName[0];
            A15CustomerId = BC000947_A15CustomerId[0];
            A1CountryId = BC000947_A1CountryId[0];
            A33ShoppingCartTotalCost = BC000947_A33ShoppingCartTotalCost[0];
            n33ShoppingCartTotalCost = BC000947_n33ShoppingCartTotalCost[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd099( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm099( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert099( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate099( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete099( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete099( )
      {
         /* Before Complete Rules */
         if ( ( DateTimeUtil.ResetTime ( A34ShoppingCartDate ) == DateTimeUtil.ResetTime ( Gx_date ) ) && ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            GX_msglist.addItem("No se puede eliminar carritos del día de hoy", 1, "");
            AnyError = 1;
         }
         if ( ( A33ShoppingCartTotalCost == Convert.ToDecimal( 0 )) && ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            GX_msglist.addItem("El carrito no puede estar vacio", 1, "");
            AnyError = 1;
         }
      }

      protected void BeforeValidate099( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes099( )
      {
      }

      protected void ZM0910( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z37ProductQuantity = A37ProductQuantity;
            Z39ProductFinalPrice = A39ProductFinalPrice;
            Z36ProductTotalCost = A36ProductTotalCost;
         }
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z11ProductName = A11ProductName;
            Z12ProductDescription = A12ProductDescription;
            Z13ProductPrice = A13ProductPrice;
            Z4CategoryId = A4CategoryId;
            Z39ProductFinalPrice = A39ProductFinalPrice;
            Z36ProductTotalCost = A36ProductTotalCost;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z5CategoryName = A5CategoryName;
            Z39ProductFinalPrice = A39ProductFinalPrice;
            Z36ProductTotalCost = A36ProductTotalCost;
         }
         if ( GX_JID == -15 )
         {
            Z31ShoppingCartId = A31ShoppingCartId;
            Z37ProductQuantity = A37ProductQuantity;
            Z10ProductId = A10ProductId;
            Z11ProductName = A11ProductName;
            Z12ProductDescription = A12ProductDescription;
            Z13ProductPrice = A13ProductPrice;
            Z4CategoryId = A4CategoryId;
            Z5CategoryName = A5CategoryName;
         }
      }

      protected void standaloneNotModal0910( )
      {
      }

      protected void standaloneModal0910( )
      {
      }

      protected void Load0910( )
      {
         /* Using cursor BC000948 */
         pr_default.execute(18, new Object[] {A31ShoppingCartId, A10ProductId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound10 = 1;
            A11ProductName = BC000948_A11ProductName[0];
            A12ProductDescription = BC000948_A12ProductDescription[0];
            A13ProductPrice = BC000948_A13ProductPrice[0];
            A5CategoryName = BC000948_A5CategoryName[0];
            A37ProductQuantity = BC000948_A37ProductQuantity[0];
            A4CategoryId = BC000948_A4CategoryId[0];
            ZM0910( -15) ;
         }
         pr_default.close(18);
         OnLoadActions0910( ) ;
      }

      protected void OnLoadActions0910( )
      {
         if ( A4CategoryId == GetProductFinalPrice0( ) )
         {
            A39ProductFinalPrice = (decimal)(A13ProductPrice+(A13ProductPrice*0.05m));
            n39ProductFinalPrice = false;
         }
         else
         {
            if ( A4CategoryId == GetProductFinalPrice1( ) )
            {
               A39ProductFinalPrice = (decimal)(A13ProductPrice-(A13ProductPrice*0.1m));
               n39ProductFinalPrice = false;
            }
            else
            {
               A39ProductFinalPrice = A13ProductPrice;
               n39ProductFinalPrice = false;
            }
         }
         A36ProductTotalCost = (decimal)(A39ProductFinalPrice*A37ProductQuantity);
         n36ProductTotalCost = false;
         O36ProductTotalCost = A36ProductTotalCost;
         n36ProductTotalCost = false;
         if ( IsIns( )  )
         {
            A33ShoppingCartTotalCost = (decimal)(O33ShoppingCartTotalCost+A36ProductTotalCost);
            n33ShoppingCartTotalCost = false;
         }
         else
         {
            if ( IsUpd( )  )
            {
               A33ShoppingCartTotalCost = (decimal)(O33ShoppingCartTotalCost+A36ProductTotalCost-O36ProductTotalCost);
               n33ShoppingCartTotalCost = false;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A33ShoppingCartTotalCost = (decimal)(O33ShoppingCartTotalCost-O36ProductTotalCost);
                  n33ShoppingCartTotalCost = false;
               }
            }
         }
      }

      protected void CheckExtendedTable0910( )
      {
         Gx_BScreen = 1;
         standaloneModal0910( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC00094 */
         pr_default.execute(2, new Object[] {A10ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
         }
         A11ProductName = BC00094_A11ProductName[0];
         A12ProductDescription = BC00094_A12ProductDescription[0];
         A13ProductPrice = BC00094_A13ProductPrice[0];
         A4CategoryId = BC00094_A4CategoryId[0];
         pr_default.close(2);
         /* Using cursor BC00095 */
         pr_default.execute(3, new Object[] {A4CategoryId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
         }
         A5CategoryName = BC00095_A5CategoryName[0];
         pr_default.close(3);
         if ( A4CategoryId == GetProductFinalPrice0( ) )
         {
            A39ProductFinalPrice = (decimal)(A13ProductPrice+(A13ProductPrice*0.05m));
            n39ProductFinalPrice = false;
         }
         else
         {
            if ( A4CategoryId == GetProductFinalPrice1( ) )
            {
               A39ProductFinalPrice = (decimal)(A13ProductPrice-(A13ProductPrice*0.1m));
               n39ProductFinalPrice = false;
            }
            else
            {
               A39ProductFinalPrice = A13ProductPrice;
               n39ProductFinalPrice = false;
            }
         }
         A36ProductTotalCost = (decimal)(A39ProductFinalPrice*A37ProductQuantity);
         n36ProductTotalCost = false;
         if ( IsIns( )  )
         {
            A33ShoppingCartTotalCost = (decimal)(O33ShoppingCartTotalCost+A36ProductTotalCost);
            n33ShoppingCartTotalCost = false;
         }
         else
         {
            if ( IsUpd( )  )
            {
               A33ShoppingCartTotalCost = (decimal)(O33ShoppingCartTotalCost+A36ProductTotalCost-O36ProductTotalCost);
               n33ShoppingCartTotalCost = false;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A33ShoppingCartTotalCost = (decimal)(O33ShoppingCartTotalCost-O36ProductTotalCost);
                  n33ShoppingCartTotalCost = false;
               }
            }
         }
      }

      protected void CloseExtendedTableCursors0910( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0910( )
      {
      }

      protected void GetKey0910( )
      {
         /* Using cursor BC000949 */
         pr_default.execute(19, new Object[] {A31ShoppingCartId, A10ProductId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey0910( )
      {
         /* Using cursor BC00093 */
         pr_default.execute(1, new Object[] {A31ShoppingCartId, A10ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0910( 15) ;
            RcdFound10 = 1;
            InitializeNonKey0910( ) ;
            A37ProductQuantity = BC00093_A37ProductQuantity[0];
            A10ProductId = BC00093_A10ProductId[0];
            Z31ShoppingCartId = A31ShoppingCartId;
            Z10ProductId = A10ProductId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0910( ) ;
            Load0910( ) ;
            Gx_mode = sMode10;
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0910( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0910( ) ;
            Gx_mode = sMode10;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0910( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0910( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00092 */
            pr_default.execute(0, new Object[] {A31ShoppingCartId, A10ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCartProducts"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z37ProductQuantity != BC00092_A37ProductQuantity[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ShoppingCartProducts"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0910( )
      {
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0910( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0910( 0) ;
            CheckOptimisticConcurrency0910( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0910( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0910( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000950 */
                     pr_default.execute(20, new Object[] {A31ShoppingCartId, A37ProductQuantity, A10ProductId});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("ShoppingCartProducts");
                     if ( (pr_default.getStatus(20) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load0910( ) ;
            }
            EndLevel0910( ) ;
         }
         CloseExtendedTableCursors0910( ) ;
      }

      protected void Update0910( )
      {
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0910( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0910( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0910( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0910( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000951 */
                     pr_default.execute(21, new Object[] {A37ProductQuantity, A31ShoppingCartId, A10ProductId});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("ShoppingCartProducts");
                     if ( (pr_default.getStatus(21) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCartProducts"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0910( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0910( ) ;
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
            EndLevel0910( ) ;
         }
         CloseExtendedTableCursors0910( ) ;
      }

      protected void DeferredUpdate0910( )
      {
      }

      protected void Delete0910( )
      {
         Gx_mode = "DLT";
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0910( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0910( ) ;
            AfterConfirm0910( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0910( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000952 */
                  pr_default.execute(22, new Object[] {A31ShoppingCartId, A10ProductId});
                  pr_default.close(22);
                  pr_default.SmartCacheProvider.SetUpdated("ShoppingCartProducts");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0910( ) ;
         Gx_mode = sMode10;
      }

      protected void OnDeleteControls0910( )
      {
         standaloneModal0910( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000953 */
            pr_default.execute(23, new Object[] {A10ProductId});
            A11ProductName = BC000953_A11ProductName[0];
            A12ProductDescription = BC000953_A12ProductDescription[0];
            A13ProductPrice = BC000953_A13ProductPrice[0];
            A4CategoryId = BC000953_A4CategoryId[0];
            pr_default.close(23);
            /* Using cursor BC000954 */
            pr_default.execute(24, new Object[] {A4CategoryId});
            A5CategoryName = BC000954_A5CategoryName[0];
            pr_default.close(24);
            if ( A4CategoryId == GetProductFinalPrice0( ) )
            {
               A39ProductFinalPrice = (decimal)(A13ProductPrice+(A13ProductPrice*0.05m));
               n39ProductFinalPrice = false;
            }
            else
            {
               if ( A4CategoryId == GetProductFinalPrice1( ) )
               {
                  A39ProductFinalPrice = (decimal)(A13ProductPrice-(A13ProductPrice*0.1m));
                  n39ProductFinalPrice = false;
               }
               else
               {
                  A39ProductFinalPrice = A13ProductPrice;
                  n39ProductFinalPrice = false;
               }
            }
            A36ProductTotalCost = (decimal)(A39ProductFinalPrice*A37ProductQuantity);
            n36ProductTotalCost = false;
            if ( IsIns( )  )
            {
               A33ShoppingCartTotalCost = (decimal)(O33ShoppingCartTotalCost+A36ProductTotalCost);
               n33ShoppingCartTotalCost = false;
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A33ShoppingCartTotalCost = (decimal)(O33ShoppingCartTotalCost+A36ProductTotalCost-O36ProductTotalCost);
                  n33ShoppingCartTotalCost = false;
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A33ShoppingCartTotalCost = (decimal)(O33ShoppingCartTotalCost-O36ProductTotalCost);
                     n33ShoppingCartTotalCost = false;
                  }
               }
            }
         }
      }

      protected void EndLevel0910( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0910( )
      {
         /* Scan By routine */
         /* Using cursor BC000955 */
         pr_default.execute(25, new Object[] {A31ShoppingCartId});
         RcdFound10 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound10 = 1;
            A11ProductName = BC000955_A11ProductName[0];
            A12ProductDescription = BC000955_A12ProductDescription[0];
            A13ProductPrice = BC000955_A13ProductPrice[0];
            A5CategoryName = BC000955_A5CategoryName[0];
            A37ProductQuantity = BC000955_A37ProductQuantity[0];
            A10ProductId = BC000955_A10ProductId[0];
            A4CategoryId = BC000955_A4CategoryId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0910( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound10 = 0;
         ScanKeyLoad0910( ) ;
      }

      protected void ScanKeyLoad0910( )
      {
         sMode10 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound10 = 1;
            A11ProductName = BC000955_A11ProductName[0];
            A12ProductDescription = BC000955_A12ProductDescription[0];
            A13ProductPrice = BC000955_A13ProductPrice[0];
            A5CategoryName = BC000955_A5CategoryName[0];
            A37ProductQuantity = BC000955_A37ProductQuantity[0];
            A10ProductId = BC000955_A10ProductId[0];
            A4CategoryId = BC000955_A4CategoryId[0];
         }
         Gx_mode = sMode10;
      }

      protected void ScanKeyEnd0910( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm0910( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0910( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0910( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0910( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0910( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0910( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0910( )
      {
      }

      protected void send_integrity_lvl_hashes0910( )
      {
      }

      protected void send_integrity_lvl_hashes099( )
      {
      }

      protected void AddRow099( )
      {
         VarsToRow9( bcShoppingCart) ;
      }

      protected void ReadRow099( )
      {
         RowToVars9( bcShoppingCart, 1) ;
      }

      protected void AddRow0910( )
      {
         SdtShoppingCart_Product obj10;
         obj10 = new SdtShoppingCart_Product(context);
         VarsToRow10( obj10) ;
         bcShoppingCart.gxTpr_Product.Add(obj10, 0);
         obj10.gxTpr_Mode = "UPD";
         obj10.gxTpr_Modified = 0;
      }

      protected void ReadRow0910( )
      {
         nGXsfl_10_idx = (int)(nGXsfl_10_idx+1);
         RowToVars10( ((SdtShoppingCart_Product)bcShoppingCart.gxTpr_Product.Item(nGXsfl_10_idx)), 1) ;
      }

      protected void InitializeNonKey099( )
      {
         A35ShoppingCartDeliveryDate = DateTime.MinValue;
         A15CustomerId = 0;
         A16CustomerName = "";
         A17CustomerDirectionDestination = "";
         A1CountryId = 0;
         A2CountryName = "";
         A33ShoppingCartTotalCost = 0;
         n33ShoppingCartTotalCost = false;
         A34ShoppingCartDate = Gx_date;
         O33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
         n33ShoppingCartTotalCost = false;
         Z34ShoppingCartDate = DateTime.MinValue;
         Z15CustomerId = 0;
      }

      protected void InitAll099( )
      {
         A31ShoppingCartId = 0;
         InitializeNonKey099( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A34ShoppingCartDate = i34ShoppingCartDate;
      }

      protected void InitializeNonKey0910( )
      {
         A11ProductName = "";
         A12ProductDescription = "";
         A13ProductPrice = 0;
         A4CategoryId = 0;
         A5CategoryName = "";
         A37ProductQuantity = 0;
         A39ProductFinalPrice = 0;
         n39ProductFinalPrice = false;
         A36ProductTotalCost = 0;
         n36ProductTotalCost = false;
         O36ProductTotalCost = A36ProductTotalCost;
         n36ProductTotalCost = false;
         Z37ProductQuantity = 0;
      }

      protected void InitAll0910( )
      {
         A10ProductId = 0;
         InitializeNonKey0910( ) ;
      }

      protected void StandaloneModalInsert0910( )
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

      public void VarsToRow9( SdtShoppingCart obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Shoppingcartdeliverydate = A35ShoppingCartDeliveryDate;
         obj9.gxTpr_Customerid = A15CustomerId;
         obj9.gxTpr_Customername = A16CustomerName;
         obj9.gxTpr_Customerdirectiondestination = A17CustomerDirectionDestination;
         obj9.gxTpr_Countryid = A1CountryId;
         obj9.gxTpr_Countryname = A2CountryName;
         obj9.gxTpr_Shoppingcarttotalcost = A33ShoppingCartTotalCost;
         obj9.gxTpr_Shoppingcartdate = A34ShoppingCartDate;
         obj9.gxTpr_Shoppingcartid = A31ShoppingCartId;
         obj9.gxTpr_Shoppingcartid_Z = Z31ShoppingCartId;
         obj9.gxTpr_Shoppingcartdate_Z = Z34ShoppingCartDate;
         obj9.gxTpr_Customerid_Z = Z15CustomerId;
         obj9.gxTpr_Customername_Z = Z16CustomerName;
         obj9.gxTpr_Customerdirectiondestination_Z = Z17CustomerDirectionDestination;
         obj9.gxTpr_Countryid_Z = Z1CountryId;
         obj9.gxTpr_Countryname_Z = Z2CountryName;
         obj9.gxTpr_Shoppingcarttotalcost_Z = Z33ShoppingCartTotalCost;
         obj9.gxTpr_Shoppingcartdeliverydate_Z = Z35ShoppingCartDeliveryDate;
         obj9.gxTpr_Shoppingcarttotalcost_N = (short)(Convert.ToInt16(n33ShoppingCartTotalCost));
         obj9.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow9( SdtShoppingCart obj9 )
      {
         obj9.gxTpr_Shoppingcartid = A31ShoppingCartId;
         return  ;
      }

      public void RowToVars9( SdtShoppingCart obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A35ShoppingCartDeliveryDate = obj9.gxTpr_Shoppingcartdeliverydate;
         A15CustomerId = obj9.gxTpr_Customerid;
         A16CustomerName = obj9.gxTpr_Customername;
         A17CustomerDirectionDestination = obj9.gxTpr_Customerdirectiondestination;
         A1CountryId = obj9.gxTpr_Countryid;
         A2CountryName = obj9.gxTpr_Countryname;
         A33ShoppingCartTotalCost = obj9.gxTpr_Shoppingcarttotalcost;
         n33ShoppingCartTotalCost = false;
         A34ShoppingCartDate = obj9.gxTpr_Shoppingcartdate;
         A31ShoppingCartId = obj9.gxTpr_Shoppingcartid;
         Z31ShoppingCartId = obj9.gxTpr_Shoppingcartid_Z;
         Z34ShoppingCartDate = obj9.gxTpr_Shoppingcartdate_Z;
         Z15CustomerId = obj9.gxTpr_Customerid_Z;
         Z16CustomerName = obj9.gxTpr_Customername_Z;
         Z17CustomerDirectionDestination = obj9.gxTpr_Customerdirectiondestination_Z;
         Z1CountryId = obj9.gxTpr_Countryid_Z;
         Z2CountryName = obj9.gxTpr_Countryname_Z;
         Z33ShoppingCartTotalCost = obj9.gxTpr_Shoppingcarttotalcost_Z;
         O33ShoppingCartTotalCost = obj9.gxTpr_Shoppingcarttotalcost_Z;
         Z35ShoppingCartDeliveryDate = obj9.gxTpr_Shoppingcartdeliverydate_Z;
         n33ShoppingCartTotalCost = (bool)(Convert.ToBoolean(obj9.gxTpr_Shoppingcarttotalcost_N));
         Gx_mode = obj9.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow10( SdtShoppingCart_Product obj10 )
      {
         obj10.gxTpr_Mode = Gx_mode;
         obj10.gxTpr_Productname = A11ProductName;
         obj10.gxTpr_Productdescription = A12ProductDescription;
         obj10.gxTpr_Productprice = A13ProductPrice;
         obj10.gxTpr_Categoryid = A4CategoryId;
         obj10.gxTpr_Categoryname = A5CategoryName;
         obj10.gxTpr_Productquantity = A37ProductQuantity;
         obj10.gxTpr_Productfinalprice = A39ProductFinalPrice;
         obj10.gxTpr_Producttotalcost = A36ProductTotalCost;
         obj10.gxTpr_Productid = A10ProductId;
         obj10.gxTpr_Productid_Z = Z10ProductId;
         obj10.gxTpr_Productname_Z = Z11ProductName;
         obj10.gxTpr_Productdescription_Z = Z12ProductDescription;
         obj10.gxTpr_Productprice_Z = Z13ProductPrice;
         obj10.gxTpr_Categoryid_Z = Z4CategoryId;
         obj10.gxTpr_Categoryname_Z = Z5CategoryName;
         obj10.gxTpr_Productfinalprice_Z = Z39ProductFinalPrice;
         obj10.gxTpr_Productquantity_Z = Z37ProductQuantity;
         obj10.gxTpr_Producttotalcost_Z = Z36ProductTotalCost;
         obj10.gxTpr_Productfinalprice_N = (short)(Convert.ToInt16(n39ProductFinalPrice));
         obj10.gxTpr_Producttotalcost_N = (short)(Convert.ToInt16(n36ProductTotalCost));
         obj10.gxTpr_Modified = nIsMod_10;
         return  ;
      }

      public void KeyVarsToRow10( SdtShoppingCart_Product obj10 )
      {
         obj10.gxTpr_Productid = A10ProductId;
         return  ;
      }

      public void RowToVars10( SdtShoppingCart_Product obj10 ,
                               int forceLoad )
      {
         Gx_mode = obj10.gxTpr_Mode;
         A11ProductName = obj10.gxTpr_Productname;
         A12ProductDescription = obj10.gxTpr_Productdescription;
         A13ProductPrice = obj10.gxTpr_Productprice;
         A4CategoryId = obj10.gxTpr_Categoryid;
         A5CategoryName = obj10.gxTpr_Categoryname;
         A37ProductQuantity = obj10.gxTpr_Productquantity;
         A39ProductFinalPrice = obj10.gxTpr_Productfinalprice;
         n39ProductFinalPrice = false;
         A36ProductTotalCost = obj10.gxTpr_Producttotalcost;
         n36ProductTotalCost = false;
         A10ProductId = obj10.gxTpr_Productid;
         Z10ProductId = obj10.gxTpr_Productid_Z;
         Z11ProductName = obj10.gxTpr_Productname_Z;
         Z12ProductDescription = obj10.gxTpr_Productdescription_Z;
         Z13ProductPrice = obj10.gxTpr_Productprice_Z;
         Z4CategoryId = obj10.gxTpr_Categoryid_Z;
         Z5CategoryName = obj10.gxTpr_Categoryname_Z;
         Z39ProductFinalPrice = obj10.gxTpr_Productfinalprice_Z;
         Z37ProductQuantity = obj10.gxTpr_Productquantity_Z;
         Z36ProductTotalCost = obj10.gxTpr_Producttotalcost_Z;
         O36ProductTotalCost = obj10.gxTpr_Producttotalcost_Z;
         n39ProductFinalPrice = (bool)(Convert.ToBoolean(obj10.gxTpr_Productfinalprice_N));
         n36ProductTotalCost = (bool)(Convert.ToBoolean(obj10.gxTpr_Producttotalcost_N));
         nIsMod_10 = obj10.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A31ShoppingCartId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey099( ) ;
         ScanKeyStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z31ShoppingCartId = A31ShoppingCartId;
         }
         ZM099( -11) ;
         OnLoadActions099( ) ;
         AddRow099( ) ;
         bcShoppingCart.gxTpr_Product.ClearCollection();
         if ( RcdFound9 == 1 )
         {
            ScanKeyStart0910( ) ;
            nGXsfl_10_idx = 1;
            while ( RcdFound10 != 0 )
            {
               O36ProductTotalCost = A36ProductTotalCost;
               n36ProductTotalCost = false;
               Z31ShoppingCartId = A31ShoppingCartId;
               Z10ProductId = A10ProductId;
               ZM0910( -15) ;
               OnLoadActions0910( ) ;
               nRcdExists_10 = 1;
               nIsMod_10 = 0;
               Z36ProductTotalCost = A36ProductTotalCost;
               AddRow0910( ) ;
               nGXsfl_10_idx = (int)(nGXsfl_10_idx+1);
               ScanKeyNext0910( ) ;
            }
            ScanKeyEnd0910( ) ;
         }
         ScanKeyEnd099( ) ;
         if ( RcdFound9 == 0 )
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
         RowToVars9( bcShoppingCart, 0) ;
         ScanKeyStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z31ShoppingCartId = A31ShoppingCartId;
         }
         ZM099( -11) ;
         OnLoadActions099( ) ;
         AddRow099( ) ;
         bcShoppingCart.gxTpr_Product.ClearCollection();
         if ( RcdFound9 == 1 )
         {
            ScanKeyStart0910( ) ;
            nGXsfl_10_idx = 1;
            while ( RcdFound10 != 0 )
            {
               O36ProductTotalCost = A36ProductTotalCost;
               n36ProductTotalCost = false;
               Z31ShoppingCartId = A31ShoppingCartId;
               Z10ProductId = A10ProductId;
               ZM0910( -15) ;
               OnLoadActions0910( ) ;
               nRcdExists_10 = 1;
               nIsMod_10 = 0;
               Z36ProductTotalCost = A36ProductTotalCost;
               AddRow0910( ) ;
               nGXsfl_10_idx = (int)(nGXsfl_10_idx+1);
               ScanKeyNext0910( ) ;
            }
            ScanKeyEnd0910( ) ;
         }
         ScanKeyEnd099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey099( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
            n33ShoppingCartTotalCost = false;
            Insert099( ) ;
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A31ShoppingCartId != Z31ShoppingCartId )
               {
                  A31ShoppingCartId = Z31ShoppingCartId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
                  n33ShoppingCartTotalCost = false;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
                  n33ShoppingCartTotalCost = false;
                  Update099( ) ;
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
                  if ( A31ShoppingCartId != Z31ShoppingCartId )
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
                        A33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
                        n33ShoppingCartTotalCost = false;
                        Insert099( ) ;
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
                        A33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
                        n33ShoppingCartTotalCost = false;
                        Insert099( ) ;
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
         RowToVars9( bcShoppingCart, 1) ;
         SaveImpl( ) ;
         VarsToRow9( bcShoppingCart) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcShoppingCart, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
         n33ShoppingCartTotalCost = false;
         Insert099( ) ;
         AfterTrn( ) ;
         VarsToRow9( bcShoppingCart) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow9( bcShoppingCart) ;
         }
         else
         {
            SdtShoppingCart auxBC = new SdtShoppingCart(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A31ShoppingCartId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcShoppingCart);
               auxBC.Save();
               bcShoppingCart.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars9( bcShoppingCart, 1) ;
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
         RowToVars9( bcShoppingCart, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert099( ) ;
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
               VarsToRow9( bcShoppingCart) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow9( bcShoppingCart) ;
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
         RowToVars9( bcShoppingCart, 0) ;
         GetKey099( ) ;
         if ( RcdFound9 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A31ShoppingCartId != Z31ShoppingCartId )
            {
               A31ShoppingCartId = Z31ShoppingCartId;
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
            if ( A31ShoppingCartId != Z31ShoppingCartId )
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
         pr_default.close(5);
         pr_default.close(1);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(14);
         pr_default.close(23);
         pr_default.close(24);
         context.RollbackDataStores("shoppingcart_bc",pr_default);
         VarsToRow9( bcShoppingCart) ;
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
         Gx_mode = bcShoppingCart.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcShoppingCart.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcShoppingCart )
         {
            bcShoppingCart = (SdtShoppingCart)(sdt);
            if ( StringUtil.StrCmp(bcShoppingCart.gxTpr_Mode, "") == 0 )
            {
               bcShoppingCart.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow9( bcShoppingCart) ;
            }
            else
            {
               RowToVars9( bcShoppingCart, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcShoppingCart.gxTpr_Mode, "") == 0 )
            {
               bcShoppingCart.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars9( bcShoppingCart, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtShoppingCart ShoppingCart_BC
      {
         get {
            return bcShoppingCart ;
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

      protected short GetProductFinalPrice1( )
      {
         X4CategoryId = 0;
         Gx_first = true;
         /* Using cursor BC000956 */
         pr_default.execute(26);
         while ( (pr_default.getStatus(26) != 101) )
         {
            if ( StringUtil.StrCmp(BC000956_A5CategoryName[0], "Entretenimiento") == 0 )
            {
               X4CategoryId = (short)(BC000956_A4CategoryId[0]);
               if (true) break;
            }
            pr_default.readNext(26);
         }
         pr_default.close(26);
         return X4CategoryId ;
      }

      protected short GetProductFinalPrice0( )
      {
         X4CategoryId = 0;
         Gx_first = true;
         /* Using cursor BC000957 */
         pr_default.execute(27);
         while ( (pr_default.getStatus(27) != 101) )
         {
            if ( StringUtil.StrCmp(BC000957_A5CategoryName[0], "Joyeria") == 0 )
            {
               X4CategoryId = (short)(BC000957_A4CategoryId[0]);
               if (true) break;
            }
            pr_default.readNext(27);
         }
         pr_default.close(27);
         return X4CategoryId ;
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
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(5);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode9 = "";
         Z34ShoppingCartDate = DateTime.MinValue;
         A34ShoppingCartDate = DateTime.MinValue;
         Z35ShoppingCartDeliveryDate = DateTime.MinValue;
         A35ShoppingCartDeliveryDate = DateTime.MinValue;
         Z16CustomerName = "";
         A16CustomerName = "";
         Z17CustomerDirectionDestination = "";
         A17CustomerDirectionDestination = "";
         Z2CountryName = "";
         A2CountryName = "";
         Gx_date = DateTime.MinValue;
         BC000925_A31ShoppingCartId = new short[1] ;
         BC000925_A34ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         BC000925_A16CustomerName = new string[] {""} ;
         BC000925_A17CustomerDirectionDestination = new string[] {""} ;
         BC000925_A2CountryName = new string[] {""} ;
         BC000925_A15CustomerId = new short[1] ;
         BC000925_A1CountryId = new short[1] ;
         BC000925_A33ShoppingCartTotalCost = new decimal[1] ;
         BC000925_n33ShoppingCartTotalCost = new bool[] {false} ;
         BC000917_A33ShoppingCartTotalCost = new decimal[1] ;
         BC000917_n33ShoppingCartTotalCost = new bool[] {false} ;
         BC00098_A16CustomerName = new string[] {""} ;
         BC00098_A17CustomerDirectionDestination = new string[] {""} ;
         BC00098_A1CountryId = new short[1] ;
         BC00099_A2CountryName = new string[] {""} ;
         BC000926_A31ShoppingCartId = new short[1] ;
         BC00097_A31ShoppingCartId = new short[1] ;
         BC00097_A34ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         BC00097_A15CustomerId = new short[1] ;
         BC00096_A31ShoppingCartId = new short[1] ;
         BC00096_A34ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         BC00096_A15CustomerId = new short[1] ;
         BC000927_A31ShoppingCartId = new short[1] ;
         BC000937_A33ShoppingCartTotalCost = new decimal[1] ;
         BC000937_n33ShoppingCartTotalCost = new bool[] {false} ;
         BC000938_A16CustomerName = new string[] {""} ;
         BC000938_A17CustomerDirectionDestination = new string[] {""} ;
         BC000938_A1CountryId = new short[1] ;
         BC000939_A2CountryName = new string[] {""} ;
         BC000947_A31ShoppingCartId = new short[1] ;
         BC000947_A34ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         BC000947_A16CustomerName = new string[] {""} ;
         BC000947_A17CustomerDirectionDestination = new string[] {""} ;
         BC000947_A2CountryName = new string[] {""} ;
         BC000947_A15CustomerId = new short[1] ;
         BC000947_A1CountryId = new short[1] ;
         BC000947_A33ShoppingCartTotalCost = new decimal[1] ;
         BC000947_n33ShoppingCartTotalCost = new bool[] {false} ;
         Z11ProductName = "";
         A11ProductName = "";
         Z12ProductDescription = "";
         A12ProductDescription = "";
         Z5CategoryName = "";
         A5CategoryName = "";
         BC000948_A31ShoppingCartId = new short[1] ;
         BC000948_A11ProductName = new string[] {""} ;
         BC000948_A12ProductDescription = new string[] {""} ;
         BC000948_A13ProductPrice = new decimal[1] ;
         BC000948_A5CategoryName = new string[] {""} ;
         BC000948_A37ProductQuantity = new long[1] ;
         BC000948_A10ProductId = new short[1] ;
         BC000948_A4CategoryId = new short[1] ;
         BC00094_A11ProductName = new string[] {""} ;
         BC00094_A12ProductDescription = new string[] {""} ;
         BC00094_A13ProductPrice = new decimal[1] ;
         BC00094_A4CategoryId = new short[1] ;
         BC00095_A5CategoryName = new string[] {""} ;
         BC000949_A31ShoppingCartId = new short[1] ;
         BC000949_A10ProductId = new short[1] ;
         BC00093_A31ShoppingCartId = new short[1] ;
         BC00093_A37ProductQuantity = new long[1] ;
         BC00093_A10ProductId = new short[1] ;
         sMode10 = "";
         BC00092_A31ShoppingCartId = new short[1] ;
         BC00092_A37ProductQuantity = new long[1] ;
         BC00092_A10ProductId = new short[1] ;
         BC000953_A11ProductName = new string[] {""} ;
         BC000953_A12ProductDescription = new string[] {""} ;
         BC000953_A13ProductPrice = new decimal[1] ;
         BC000953_A4CategoryId = new short[1] ;
         BC000954_A5CategoryName = new string[] {""} ;
         BC000955_A31ShoppingCartId = new short[1] ;
         BC000955_A11ProductName = new string[] {""} ;
         BC000955_A12ProductDescription = new string[] {""} ;
         BC000955_A13ProductPrice = new decimal[1] ;
         BC000955_A5CategoryName = new string[] {""} ;
         BC000955_A37ProductQuantity = new long[1] ;
         BC000955_A10ProductId = new short[1] ;
         BC000955_A4CategoryId = new short[1] ;
         i34ShoppingCartDate = DateTime.MinValue;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000956_A5CategoryName = new string[] {""} ;
         BC000956_A4CategoryId = new short[1] ;
         BC000957_A5CategoryName = new string[] {""} ;
         BC000957_A4CategoryId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.shoppingcart_bc__default(),
            new Object[][] {
                new Object[] {
               BC00092_A31ShoppingCartId, BC00092_A37ProductQuantity, BC00092_A10ProductId
               }
               , new Object[] {
               BC00093_A31ShoppingCartId, BC00093_A37ProductQuantity, BC00093_A10ProductId
               }
               , new Object[] {
               BC00094_A11ProductName, BC00094_A12ProductDescription, BC00094_A13ProductPrice, BC00094_A4CategoryId
               }
               , new Object[] {
               BC00095_A5CategoryName
               }
               , new Object[] {
               BC00096_A31ShoppingCartId, BC00096_A34ShoppingCartDate, BC00096_A15CustomerId
               }
               , new Object[] {
               BC00097_A31ShoppingCartId, BC00097_A34ShoppingCartDate, BC00097_A15CustomerId
               }
               , new Object[] {
               BC00098_A16CustomerName, BC00098_A17CustomerDirectionDestination, BC00098_A1CountryId
               }
               , new Object[] {
               BC00099_A2CountryName
               }
               , new Object[] {
               BC000917_A33ShoppingCartTotalCost, BC000917_n33ShoppingCartTotalCost
               }
               , new Object[] {
               BC000925_A31ShoppingCartId, BC000925_A34ShoppingCartDate, BC000925_A16CustomerName, BC000925_A17CustomerDirectionDestination, BC000925_A2CountryName, BC000925_A15CustomerId, BC000925_A1CountryId, BC000925_A33ShoppingCartTotalCost, BC000925_n33ShoppingCartTotalCost
               }
               , new Object[] {
               BC000926_A31ShoppingCartId
               }
               , new Object[] {
               BC000927_A31ShoppingCartId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000937_A33ShoppingCartTotalCost, BC000937_n33ShoppingCartTotalCost
               }
               , new Object[] {
               BC000938_A16CustomerName, BC000938_A17CustomerDirectionDestination, BC000938_A1CountryId
               }
               , new Object[] {
               BC000939_A2CountryName
               }
               , new Object[] {
               BC000947_A31ShoppingCartId, BC000947_A34ShoppingCartDate, BC000947_A16CustomerName, BC000947_A17CustomerDirectionDestination, BC000947_A2CountryName, BC000947_A15CustomerId, BC000947_A1CountryId, BC000947_A33ShoppingCartTotalCost, BC000947_n33ShoppingCartTotalCost
               }
               , new Object[] {
               BC000948_A31ShoppingCartId, BC000948_A11ProductName, BC000948_A12ProductDescription, BC000948_A13ProductPrice, BC000948_A5CategoryName, BC000948_A37ProductQuantity, BC000948_A10ProductId, BC000948_A4CategoryId
               }
               , new Object[] {
               BC000949_A31ShoppingCartId, BC000949_A10ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000953_A11ProductName, BC000953_A12ProductDescription, BC000953_A13ProductPrice, BC000953_A4CategoryId
               }
               , new Object[] {
               BC000954_A5CategoryName
               }
               , new Object[] {
               BC000955_A31ShoppingCartId, BC000955_A11ProductName, BC000955_A12ProductDescription, BC000955_A13ProductPrice, BC000955_A5CategoryName, BC000955_A37ProductQuantity, BC000955_A10ProductId, BC000955_A4CategoryId
               }
               , new Object[] {
               BC000956_A5CategoryName, BC000956_A4CategoryId
               }
               , new Object[] {
               BC000957_A5CategoryName, BC000957_A4CategoryId
               }
            }
         );
         Z34ShoppingCartDate = DateTime.MinValue;
         A34ShoppingCartDate = DateTime.MinValue;
         i34ShoppingCartDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12092 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z31ShoppingCartId ;
      private short A31ShoppingCartId ;
      private short nIsMod_10 ;
      private short RcdFound10 ;
      private short A15CustomerId ;
      private short Z15CustomerId ;
      private short Z1CountryId ;
      private short A1CountryId ;
      private short Gx_BScreen ;
      private short RcdFound9 ;
      private short nRcdExists_10 ;
      private short Z4CategoryId ;
      private short A4CategoryId ;
      private short Z10ProductId ;
      private short A10ProductId ;
      private short Gxremove10 ;
      private short X4CategoryId ;
      private int trnEnded ;
      private int nGXsfl_10_idx=1 ;
      private long Z37ProductQuantity ;
      private long A37ProductQuantity ;
      private decimal s33ShoppingCartTotalCost ;
      private decimal O33ShoppingCartTotalCost ;
      private decimal A33ShoppingCartTotalCost ;
      private decimal Z33ShoppingCartTotalCost ;
      private decimal Z39ProductFinalPrice ;
      private decimal A39ProductFinalPrice ;
      private decimal Z36ProductTotalCost ;
      private decimal A36ProductTotalCost ;
      private decimal Z13ProductPrice ;
      private decimal A13ProductPrice ;
      private decimal O36ProductTotalCost ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode9 ;
      private string sMode10 ;
      private DateTime Z34ShoppingCartDate ;
      private DateTime A34ShoppingCartDate ;
      private DateTime Z35ShoppingCartDeliveryDate ;
      private DateTime A35ShoppingCartDeliveryDate ;
      private DateTime Gx_date ;
      private DateTime i34ShoppingCartDate ;
      private bool n33ShoppingCartTotalCost ;
      private bool returnInSub ;
      private bool n39ProductFinalPrice ;
      private bool n36ProductTotalCost ;
      private bool Gx_first ;
      private string Z16CustomerName ;
      private string A16CustomerName ;
      private string Z17CustomerDirectionDestination ;
      private string A17CustomerDirectionDestination ;
      private string Z2CountryName ;
      private string A2CountryName ;
      private string Z11ProductName ;
      private string A11ProductName ;
      private string Z12ProductDescription ;
      private string A12ProductDescription ;
      private string Z5CategoryName ;
      private string A5CategoryName ;
      private IGxDataStore dsDefault ;
      private SdtShoppingCart bcShoppingCart ;
      private IDataStoreProvider pr_default ;
      private short[] BC000925_A31ShoppingCartId ;
      private DateTime[] BC000925_A34ShoppingCartDate ;
      private string[] BC000925_A16CustomerName ;
      private string[] BC000925_A17CustomerDirectionDestination ;
      private string[] BC000925_A2CountryName ;
      private short[] BC000925_A15CustomerId ;
      private short[] BC000925_A1CountryId ;
      private decimal[] BC000925_A33ShoppingCartTotalCost ;
      private bool[] BC000925_n33ShoppingCartTotalCost ;
      private decimal[] BC000917_A33ShoppingCartTotalCost ;
      private bool[] BC000917_n33ShoppingCartTotalCost ;
      private string[] BC00098_A16CustomerName ;
      private string[] BC00098_A17CustomerDirectionDestination ;
      private short[] BC00098_A1CountryId ;
      private string[] BC00099_A2CountryName ;
      private short[] BC000926_A31ShoppingCartId ;
      private short[] BC00097_A31ShoppingCartId ;
      private DateTime[] BC00097_A34ShoppingCartDate ;
      private short[] BC00097_A15CustomerId ;
      private short[] BC00096_A31ShoppingCartId ;
      private DateTime[] BC00096_A34ShoppingCartDate ;
      private short[] BC00096_A15CustomerId ;
      private short[] BC000927_A31ShoppingCartId ;
      private decimal[] BC000937_A33ShoppingCartTotalCost ;
      private bool[] BC000937_n33ShoppingCartTotalCost ;
      private string[] BC000938_A16CustomerName ;
      private string[] BC000938_A17CustomerDirectionDestination ;
      private short[] BC000938_A1CountryId ;
      private string[] BC000939_A2CountryName ;
      private short[] BC000947_A31ShoppingCartId ;
      private DateTime[] BC000947_A34ShoppingCartDate ;
      private string[] BC000947_A16CustomerName ;
      private string[] BC000947_A17CustomerDirectionDestination ;
      private string[] BC000947_A2CountryName ;
      private short[] BC000947_A15CustomerId ;
      private short[] BC000947_A1CountryId ;
      private decimal[] BC000947_A33ShoppingCartTotalCost ;
      private bool[] BC000947_n33ShoppingCartTotalCost ;
      private short[] BC000948_A31ShoppingCartId ;
      private string[] BC000948_A11ProductName ;
      private string[] BC000948_A12ProductDescription ;
      private decimal[] BC000948_A13ProductPrice ;
      private string[] BC000948_A5CategoryName ;
      private long[] BC000948_A37ProductQuantity ;
      private short[] BC000948_A10ProductId ;
      private short[] BC000948_A4CategoryId ;
      private string[] BC00094_A11ProductName ;
      private string[] BC00094_A12ProductDescription ;
      private decimal[] BC00094_A13ProductPrice ;
      private short[] BC00094_A4CategoryId ;
      private string[] BC00095_A5CategoryName ;
      private short[] BC000949_A31ShoppingCartId ;
      private short[] BC000949_A10ProductId ;
      private short[] BC00093_A31ShoppingCartId ;
      private long[] BC00093_A37ProductQuantity ;
      private short[] BC00093_A10ProductId ;
      private short[] BC00092_A31ShoppingCartId ;
      private long[] BC00092_A37ProductQuantity ;
      private short[] BC00092_A10ProductId ;
      private string[] BC000953_A11ProductName ;
      private string[] BC000953_A12ProductDescription ;
      private decimal[] BC000953_A13ProductPrice ;
      private short[] BC000953_A4CategoryId ;
      private string[] BC000954_A5CategoryName ;
      private short[] BC000955_A31ShoppingCartId ;
      private string[] BC000955_A11ProductName ;
      private string[] BC000955_A12ProductDescription ;
      private decimal[] BC000955_A13ProductPrice ;
      private string[] BC000955_A5CategoryName ;
      private long[] BC000955_A37ProductQuantity ;
      private short[] BC000955_A10ProductId ;
      private short[] BC000955_A4CategoryId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string[] BC000956_A5CategoryName ;
      private short[] BC000956_A4CategoryId ;
      private string[] BC000957_A5CategoryName ;
      private short[] BC000957_A4CategoryId ;
   }

   public class shoppingcart_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new UpdateCursor(def[21])
         ,new UpdateCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00092;
          prmBC00092 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00093;
          prmBC00093 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00094;
          prmBC00094 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00095;
          prmBC00095 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmBC00096;
          prmBC00096 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC00097;
          prmBC00097 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC00098;
          prmBC00098 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC00099;
          prmBC00099 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000917;
          prmBC000917 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000925;
          prmBC000925 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          string cmdBufferBC000925;
          cmdBufferBC000925=" SELECT TM1.[ShoppingCartId], TM1.[ShoppingCartDate], T3.[CustomerName], T3.[CustomerDirectionDestination], T4.[CountryName], TM1.[CustomerId], T3.[CountryId], COALESCE( T2.[ShoppingCartTotalCost], 0) AS ShoppingCartTotalCost FROM ((([ShoppingCart] TM1 LEFT JOIN (SELECT SUM(COALESCE( T6.[ProductTotalCost], 0)) AS ShoppingCartTotalCost, T5.[ShoppingCartId] FROM ([ShoppingCartProducts] T5 INNER JOIN (SELECT ( COALESCE( T8.[ProductFinalPrice], 0)) * CAST(T7.[ProductQuantity] AS decimal( 28, 10)) AS ProductTotalCost, T7.[ShoppingCartId], T7.[ProductId] FROM ([ShoppingCartProducts] T7 INNER JOIN (SELECT CASE  WHEN T12.[CategoryId] = COALESCE( T11.[CategoryId], 0) THEN T12.[ProductPrice] + ( T12.[ProductPrice] * CAST(0.05 AS decimal( 28, 10))) WHEN T12.[CategoryId] = COALESCE( T10.[CategoryId], 0) THEN T12.[ProductPrice] - ( T12.[ProductPrice] * CAST(0.1 AS decimal( 28, 10))) ELSE T12.[ProductPrice] END AS ProductFinalPrice, T9.[ShoppingCartId], T9.[ProductId] FROM ((([ShoppingCartProducts] T9 INNER JOIN [Product] T12 ON T12.[ProductId] = T9.[ProductId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Entretenimiento' ) T10 ON T10.[CategoryId] = T12.[CategoryId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Joyeria' ) T11 ON T11.[CategoryId] = T12.[CategoryId]) ) T8 ON T8.[ShoppingCartId] = T7.[ShoppingCartId] AND T8.[ProductId] = T7.[ProductId]) ) T6 ON T6.[ShoppingCartId] = T5.[ShoppingCartId] AND T6.[ProductId] = T5.[ProductId]) GROUP BY T5.[ShoppingCartId] ) T2 ON T2.[ShoppingCartId] = TM1.[ShoppingCartId]) INNER JOIN [Customer] T3 ON T3.[CustomerId] = TM1.[CustomerId]) INNER JOIN [Country] T4 ON T4.[CountryId] = T3.[CountryId]) WHERE TM1.[ShoppingCartId] = @ShoppingCartId "
          + " ORDER BY TM1.[ShoppingCartId]  OPTION (FAST 100)" ;
          Object[] prmBC000926;
          prmBC000926 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000927;
          prmBC000927 = new Object[] {
          new ParDef("@ShoppingCartDate",GXType.Date,8,0) ,
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC000928;
          prmBC000928 = new Object[] {
          new ParDef("@ShoppingCartDate",GXType.Date,8,0) ,
          new ParDef("@CustomerId",GXType.Int16,4,0) ,
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000929;
          prmBC000929 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000937;
          prmBC000937 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000938;
          prmBC000938 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC000939;
          prmBC000939 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000947;
          prmBC000947 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          string cmdBufferBC000947;
          cmdBufferBC000947=" SELECT TM1.[ShoppingCartId], TM1.[ShoppingCartDate], T3.[CustomerName], T3.[CustomerDirectionDestination], T4.[CountryName], TM1.[CustomerId], T3.[CountryId], COALESCE( T2.[ShoppingCartTotalCost], 0) AS ShoppingCartTotalCost FROM ((([ShoppingCart] TM1 LEFT JOIN (SELECT SUM(COALESCE( T6.[ProductTotalCost], 0)) AS ShoppingCartTotalCost, T5.[ShoppingCartId] FROM ([ShoppingCartProducts] T5 INNER JOIN (SELECT ( COALESCE( T8.[ProductFinalPrice], 0)) * CAST(T7.[ProductQuantity] AS decimal( 28, 10)) AS ProductTotalCost, T7.[ShoppingCartId], T7.[ProductId] FROM ([ShoppingCartProducts] T7 INNER JOIN (SELECT CASE  WHEN T12.[CategoryId] = COALESCE( T11.[CategoryId], 0) THEN T12.[ProductPrice] + ( T12.[ProductPrice] * CAST(0.05 AS decimal( 28, 10))) WHEN T12.[CategoryId] = COALESCE( T10.[CategoryId], 0) THEN T12.[ProductPrice] - ( T12.[ProductPrice] * CAST(0.1 AS decimal( 28, 10))) ELSE T12.[ProductPrice] END AS ProductFinalPrice, T9.[ShoppingCartId], T9.[ProductId] FROM ((([ShoppingCartProducts] T9 INNER JOIN [Product] T12 ON T12.[ProductId] = T9.[ProductId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Entretenimiento' ) T10 ON T10.[CategoryId] = T12.[CategoryId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Joyeria' ) T11 ON T11.[CategoryId] = T12.[CategoryId]) ) T8 ON T8.[ShoppingCartId] = T7.[ShoppingCartId] AND T8.[ProductId] = T7.[ProductId]) ) T6 ON T6.[ShoppingCartId] = T5.[ShoppingCartId] AND T6.[ProductId] = T5.[ProductId]) GROUP BY T5.[ShoppingCartId] ) T2 ON T2.[ShoppingCartId] = TM1.[ShoppingCartId]) INNER JOIN [Customer] T3 ON T3.[CustomerId] = TM1.[CustomerId]) INNER JOIN [Country] T4 ON T4.[CountryId] = T3.[CountryId]) WHERE TM1.[ShoppingCartId] = @ShoppingCartId "
          + " ORDER BY TM1.[ShoppingCartId]  OPTION (FAST 100)" ;
          Object[] prmBC000948;
          prmBC000948 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000949;
          prmBC000949 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000950;
          prmBC000950 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductQuantity",GXType.Decimal,10,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000951;
          prmBC000951 = new Object[] {
          new ParDef("@ProductQuantity",GXType.Decimal,10,0) ,
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000952;
          prmBC000952 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000953;
          prmBC000953 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000954;
          prmBC000954 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmBC000955;
          prmBC000955 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000956;
          prmBC000956 = new Object[] {
          };
          Object[] prmBC000957;
          prmBC000957 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("BC00092", "SELECT [ShoppingCartId], [ProductQuantity], [ProductId] FROM [ShoppingCartProducts] WITH (UPDLOCK) WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00092,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00093", "SELECT [ShoppingCartId], [ProductQuantity], [ProductId] FROM [ShoppingCartProducts] WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00093,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00094", "SELECT [ProductName], [ProductDescription], [ProductPrice], [CategoryId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00094,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00095", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00095,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00096", "SELECT [ShoppingCartId], [ShoppingCartDate], [CustomerId] FROM [ShoppingCart] WITH (UPDLOCK) WHERE [ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00096,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00097", "SELECT [ShoppingCartId], [ShoppingCartDate], [CustomerId] FROM [ShoppingCart] WHERE [ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00097,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00098", "SELECT [CustomerName], [CustomerDirectionDestination], [CountryId] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00098,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00099", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00099,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000917", "SELECT COALESCE( T1.[ShoppingCartTotalCost], 0) AS ShoppingCartTotalCost FROM (SELECT SUM(COALESCE( T3.[ProductTotalCost], 0)) AS ShoppingCartTotalCost, T2.[ShoppingCartId] FROM ([ShoppingCartProducts] T2 WITH (UPDLOCK) INNER JOIN (SELECT ( COALESCE( T5.[ProductFinalPrice], 0)) * CAST(T4.[ProductQuantity] AS decimal( 28, 10)) AS ProductTotalCost, T4.[ShoppingCartId], T4.[ProductId] FROM ([ShoppingCartProducts] T4 WITH (UPDLOCK) INNER JOIN (SELECT CASE  WHEN T9.[CategoryId] = COALESCE( T8.[CategoryId], 0) THEN T9.[ProductPrice] + ( T9.[ProductPrice] * CAST(0.05 AS decimal( 28, 10))) WHEN T9.[CategoryId] = COALESCE( T7.[CategoryId], 0) THEN T9.[ProductPrice] - ( T9.[ProductPrice] * CAST(0.1 AS decimal( 28, 10))) ELSE T9.[ProductPrice] END AS ProductFinalPrice, T6.[ShoppingCartId], T6.[ProductId] FROM ((([ShoppingCartProducts] T6 WITH (UPDLOCK) INNER JOIN [Product] T9 ON T9.[ProductId] = T6.[ProductId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Entretenimiento' ) T7 ON T7.[CategoryId] = T9.[CategoryId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Joyeria' ) T8 ON T8.[CategoryId] = T9.[CategoryId]) ) T5 ON T5.[ShoppingCartId] = T4.[ShoppingCartId] AND T5.[ProductId] = T4.[ProductId]) ) T3 ON T3.[ShoppingCartId] = T2.[ShoppingCartId] AND T3.[ProductId] = T2.[ProductId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000917,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000925", cmdBufferBC000925,true, GxErrorMask.GX_NOMASK, false, this,prmBC000925,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000926", "SELECT [ShoppingCartId] FROM [ShoppingCart] WHERE [ShoppingCartId] = @ShoppingCartId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000926,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000927", "INSERT INTO [ShoppingCart]([ShoppingCartDate], [CustomerId]) VALUES(@ShoppingCartDate, @CustomerId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000927,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000928", "UPDATE [ShoppingCart] SET [ShoppingCartDate]=@ShoppingCartDate, [CustomerId]=@CustomerId  WHERE [ShoppingCartId] = @ShoppingCartId", GxErrorMask.GX_NOMASK,prmBC000928)
             ,new CursorDef("BC000929", "DELETE FROM [ShoppingCart]  WHERE [ShoppingCartId] = @ShoppingCartId", GxErrorMask.GX_NOMASK,prmBC000929)
             ,new CursorDef("BC000937", "SELECT COALESCE( T1.[ShoppingCartTotalCost], 0) AS ShoppingCartTotalCost FROM (SELECT SUM(COALESCE( T3.[ProductTotalCost], 0)) AS ShoppingCartTotalCost, T2.[ShoppingCartId] FROM ([ShoppingCartProducts] T2 WITH (UPDLOCK) INNER JOIN (SELECT ( COALESCE( T5.[ProductFinalPrice], 0)) * CAST(T4.[ProductQuantity] AS decimal( 28, 10)) AS ProductTotalCost, T4.[ShoppingCartId], T4.[ProductId] FROM ([ShoppingCartProducts] T4 WITH (UPDLOCK) INNER JOIN (SELECT CASE  WHEN T9.[CategoryId] = COALESCE( T8.[CategoryId], 0) THEN T9.[ProductPrice] + ( T9.[ProductPrice] * CAST(0.05 AS decimal( 28, 10))) WHEN T9.[CategoryId] = COALESCE( T7.[CategoryId], 0) THEN T9.[ProductPrice] - ( T9.[ProductPrice] * CAST(0.1 AS decimal( 28, 10))) ELSE T9.[ProductPrice] END AS ProductFinalPrice, T6.[ShoppingCartId], T6.[ProductId] FROM ((([ShoppingCartProducts] T6 WITH (UPDLOCK) INNER JOIN [Product] T9 ON T9.[ProductId] = T6.[ProductId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Entretenimiento' ) T7 ON T7.[CategoryId] = T9.[CategoryId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Joyeria' ) T8 ON T8.[CategoryId] = T9.[CategoryId]) ) T5 ON T5.[ShoppingCartId] = T4.[ShoppingCartId] AND T5.[ProductId] = T4.[ProductId]) ) T3 ON T3.[ShoppingCartId] = T2.[ShoppingCartId] AND T3.[ProductId] = T2.[ProductId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000937,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000938", "SELECT [CustomerName], [CustomerDirectionDestination], [CountryId] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000938,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000939", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000939,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000947", cmdBufferBC000947,true, GxErrorMask.GX_NOMASK, false, this,prmBC000947,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000948", "SELECT T1.[ShoppingCartId], T2.[ProductName], T2.[ProductDescription], T2.[ProductPrice], T3.[CategoryName], T1.[ProductQuantity], T1.[ProductId], T2.[CategoryId] FROM (([ShoppingCartProducts] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) INNER JOIN [Category] T3 ON T3.[CategoryId] = T2.[CategoryId]) WHERE T1.[ShoppingCartId] = @ShoppingCartId and T1.[ProductId] = @ProductId ORDER BY T1.[ShoppingCartId], T1.[ProductId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000948,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000949", "SELECT [ShoppingCartId], [ProductId] FROM [ShoppingCartProducts] WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000949,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000950", "INSERT INTO [ShoppingCartProducts]([ShoppingCartId], [ProductQuantity], [ProductId]) VALUES(@ShoppingCartId, @ProductQuantity, @ProductId)", GxErrorMask.GX_NOMASK,prmBC000950)
             ,new CursorDef("BC000951", "UPDATE [ShoppingCartProducts] SET [ProductQuantity]=@ProductQuantity  WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000951)
             ,new CursorDef("BC000952", "DELETE FROM [ShoppingCartProducts]  WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000952)
             ,new CursorDef("BC000953", "SELECT [ProductName], [ProductDescription], [ProductPrice], [CategoryId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000953,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000954", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000954,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000955", "SELECT T1.[ShoppingCartId], T2.[ProductName], T2.[ProductDescription], T2.[ProductPrice], T3.[CategoryName], T1.[ProductQuantity], T1.[ProductId], T2.[CategoryId] FROM (([ShoppingCartProducts] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) INNER JOIN [Category] T3 ON T3.[CategoryId] = T2.[CategoryId]) WHERE T1.[ShoppingCartId] = @ShoppingCartId ORDER BY T1.[ShoppingCartId], T1.[ProductId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000955,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000956", "SELECT [CategoryName], [CategoryId] FROM [Category] WHERE [CategoryName] = 'Entretenimiento' ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000956,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000957", "SELECT [CategoryName], [CategoryId] FROM [Category] WHERE [CategoryName] = 'Joyeria' ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000957,0, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 23 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 25 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 27 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
