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
   public class shoppingcart : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel15"+"_"+"PRODUCTFINALPRICE") == 0 )
         {
            A13ProductPrice = NumberUtil.Val( GetPar( "ProductPrice"), ".");
            A4CategoryId = (short)(Math.Round(NumberUtil.Val( GetPar( "CategoryId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX15ASAPRODUCTFINALPRICE0910( A13ProductPrice, A4CategoryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A31ShoppingCartId = (short)(Math.Round(NumberUtil.Val( GetPar( "ShoppingCartId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A31ShoppingCartId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A15CustomerId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A15CustomerId", StringUtil.LTrimStr( (decimal)(A15CustomerId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A15CustomerId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A1CountryId = (short)(Math.Round(NumberUtil.Val( GetPar( "CountryId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1CountryId", StringUtil.LTrimStr( (decimal)(A1CountryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A1CountryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A10ProductId = (short)(Math.Round(NumberUtil.Val( GetPar( "ProductId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A10ProductId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A4CategoryId = (short)(Math.Round(NumberUtil.Val( GetPar( "CategoryId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A4CategoryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridshoppingcart_product") == 0 )
         {
            gxnrGridshoppingcart_product_newrow_invoke( ) ;
            return  ;
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7ShoppingCartId = (short)(Math.Round(NumberUtil.Val( GetPar( "ShoppingCartId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7ShoppingCartId", StringUtil.LTrimStr( (decimal)(AV7ShoppingCartId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vSHOPPINGCARTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ShoppingCartId), "ZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Shopping Cart", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtShoppingCartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("ObligatorioShop", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridshoppingcart_product_newrow_invoke( )
      {
         nRC_GXsfl_83 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_83"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_83_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_83_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_83_idx = GetPar( "sGXsfl_83_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridshoppingcart_product_newrow( ) ;
         /* End function gxnrGridshoppingcart_product_newrow_invoke */
      }

      public shoppingcart( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public shoppingcart( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_ShoppingCartId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ShoppingCartId = aP1_ShoppingCartId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Shopping Cart", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtShoppingCartId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtShoppingCartId_Internalname, "Cart Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtShoppingCartId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A31ShoppingCartId), 4, 0, ",", "")), StringUtil.LTrim( ((edtShoppingCartId_Enabled!=0) ? context.localUtil.Format( (decimal)(A31ShoppingCartId), "ZZZ9") : context.localUtil.Format( (decimal)(A31ShoppingCartId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtShoppingCartId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtShoppingCartDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtShoppingCartDate_Internalname, "Cart Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtShoppingCartDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtShoppingCartDate_Internalname, context.localUtil.Format(A34ShoppingCartDate, "99/99/99"), context.localUtil.Format( A34ShoppingCartDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtShoppingCartDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_bitmap( context, edtShoppingCartDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtShoppingCartDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ShoppingCart.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerId_Internalname, "Customer Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CustomerId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A15CustomerId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ShoppingCart.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_15_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_15_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_15_Internalname, sImgUrl, imgprompt_15_Link, "", "", context.GetTheme( ), imgprompt_15_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerName_Internalname, "Customer Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerName_Internalname, A16CustomerName, StringUtil.RTrim( context.localUtil.Format( A16CustomerName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerDirectionDestination_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerDirectionDestination_Internalname, "Customer Direction Destination", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerDirectionDestination_Internalname, A17CustomerDirectionDestination, StringUtil.RTrim( context.localUtil.Format( A17CustomerDirectionDestination, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerDirectionDestination_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerDirectionDestination_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCountryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCountryId_Internalname, "Country Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CountryId), 4, 0, ",", "")), StringUtil.LTrim( ((edtCountryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1CountryId), "ZZZ9") : context.localUtil.Format( (decimal)(A1CountryId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCountryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCountryName_Internalname, "Country Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCountryName_Internalname, A2CountryName, StringUtil.RTrim( context.localUtil.Format( A2CountryName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtShoppingCartTotalCost_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtShoppingCartTotalCost_Internalname, "Total Cost", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtShoppingCartTotalCost_Internalname, StringUtil.LTrim( StringUtil.NToC( A33ShoppingCartTotalCost, 18, 2, ",", "")), StringUtil.LTrim( ((edtShoppingCartTotalCost_Enabled!=0) ? context.localUtil.Format( A33ShoppingCartTotalCost, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A33ShoppingCartTotalCost, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartTotalCost_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtShoppingCartTotalCost_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtShoppingCartDeliveryDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtShoppingCartDeliveryDate_Internalname, "Delivery Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtShoppingCartDeliveryDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtShoppingCartDeliveryDate_Internalname, context.localUtil.Format(A35ShoppingCartDeliveryDate, "99/99/99"), context.localUtil.Format( A35ShoppingCartDeliveryDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartDeliveryDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtShoppingCartDeliveryDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_bitmap( context, edtShoppingCartDeliveryDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtShoppingCartDeliveryDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ShoppingCart.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divProducttable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleproduct_Internalname, "Product", "", "", lblTitleproduct_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridshoppingcart_product( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridshoppingcart_product( )
      {
         /*  Grid Control  */
         StartGridControl83( ) ;
         nGXsfl_83_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount10 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_10 = 1;
               ScanStart0910( ) ;
               while ( RcdFound10 != 0 )
               {
                  init_level_properties10( ) ;
                  getByPrimaryKey0910( ) ;
                  AddRow0910( ) ;
                  ScanNext0910( ) ;
               }
               ScanEnd0910( ) ;
               nBlankRcdCount10 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
            n33ShoppingCartTotalCost = false;
            AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
            standaloneNotModal0910( ) ;
            standaloneModal0910( ) ;
            sMode10 = Gx_mode;
            while ( nGXsfl_83_idx < nRC_GXsfl_83 )
            {
               bGXsfl_83_Refreshing = true;
               ReadRow0910( ) ;
               edtProductId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtProductName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtProductDescription_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTDESCRIPTION_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductDescription_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtProductPrice_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTPRICE_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtCategoryId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORYID_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtCategoryName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORYNAME_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCategoryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryName_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtProductFinalPrice_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTFINALPRICE_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductFinalPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductFinalPrice_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtProductQuantity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTQUANTITY_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductQuantity_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtProductTotalCost_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTTOTALCOST_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductTotalCost_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductTotalCost_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               imgprompt_15_Link = cgiGet( "PROMPT_10_"+sGXsfl_83_idx+"Link");
               if ( ( nRcdExists_10 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0910( ) ;
               }
               SendRow0910( ) ;
               bGXsfl_83_Refreshing = false;
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A33ShoppingCartTotalCost = B33ShoppingCartTotalCost;
            n33ShoppingCartTotalCost = false;
            AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount10 = 5;
            nRcdExists_10 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0910( ) ;
               while ( RcdFound10 != 0 )
               {
                  sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_8310( ) ;
                  init_level_properties10( ) ;
                  standaloneNotModal0910( ) ;
                  getByPrimaryKey0910( ) ;
                  standaloneModal0910( ) ;
                  AddRow0910( ) ;
                  ScanNext0910( ) ;
               }
               ScanEnd0910( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode10 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx+1), 4, 0), 4, "0");
            SubsflControlProps_8310( ) ;
            InitAll0910( ) ;
            init_level_properties10( ) ;
            B33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
            n33ShoppingCartTotalCost = false;
            AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
            nRcdExists_10 = 0;
            nIsMod_10 = 0;
            nRcdDeleted_10 = 0;
            nBlankRcdCount10 = (short)(nBlankRcdUsr10+nBlankRcdCount10);
            fRowAdded = 0;
            while ( nBlankRcdCount10 > 0 )
            {
               standaloneNotModal0910( ) ;
               standaloneModal0910( ) ;
               AddRow0910( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount10 = (short)(nBlankRcdCount10-1);
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A33ShoppingCartTotalCost = B33ShoppingCartTotalCost;
            n33ShoppingCartTotalCost = false;
            AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridshoppingcart_productContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridshoppingcart_product", Gridshoppingcart_productContainer, subGridshoppingcart_product_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridshoppingcart_productContainerData", Gridshoppingcart_productContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridshoppingcart_productContainerData"+"V", Gridshoppingcart_productContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridshoppingcart_productContainerData"+"V"+"\" value='"+Gridshoppingcart_productContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11092 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z31ShoppingCartId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z31ShoppingCartId"), ",", "."), 18, MidpointRounding.ToEven));
               Z34ShoppingCartDate = context.localUtil.CToD( cgiGet( "Z34ShoppingCartDate"), 0);
               Z15CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z15CustomerId"), ",", "."), 18, MidpointRounding.ToEven));
               O33ShoppingCartTotalCost = context.localUtil.CToN( cgiGet( "O33ShoppingCartTotalCost"), ",", ".");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_83 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_83"), ",", "."), 18, MidpointRounding.ToEven));
               N15CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N15CustomerId"), ",", "."), 18, MidpointRounding.ToEven));
               AV7ShoppingCartId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vSHOPPINGCARTID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CUSTOMERID"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "vMODE");
               AV16Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A31ShoppingCartId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtShoppingCartId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
               if ( context.localUtil.VCDate( cgiGet( edtShoppingCartDate_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Shopping Cart Date"}), 1, "SHOPPINGCARTDATE");
                  AnyError = 1;
                  GX_FocusControl = edtShoppingCartDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A34ShoppingCartDate = DateTime.MinValue;
                  AssignAttri("", false, "A34ShoppingCartDate", context.localUtil.Format(A34ShoppingCartDate, "99/99/99"));
               }
               else
               {
                  A34ShoppingCartDate = context.localUtil.CToD( cgiGet( edtShoppingCartDate_Internalname), 2);
                  AssignAttri("", false, "A34ShoppingCartDate", context.localUtil.Format(A34ShoppingCartDate, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUSTOMERID");
                  AnyError = 1;
                  GX_FocusControl = edtCustomerId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A15CustomerId = 0;
                  AssignAttri("", false, "A15CustomerId", StringUtil.LTrimStr( (decimal)(A15CustomerId), 4, 0));
               }
               else
               {
                  A15CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A15CustomerId", StringUtil.LTrimStr( (decimal)(A15CustomerId), 4, 0));
               }
               A16CustomerName = cgiGet( edtCustomerName_Internalname);
               AssignAttri("", false, "A16CustomerName", A16CustomerName);
               A17CustomerDirectionDestination = cgiGet( edtCustomerDirectionDestination_Internalname);
               AssignAttri("", false, "A17CustomerDirectionDestination", A17CustomerDirectionDestination);
               A1CountryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1CountryId", StringUtil.LTrimStr( (decimal)(A1CountryId), 4, 0));
               A2CountryName = cgiGet( edtCountryName_Internalname);
               AssignAttri("", false, "A2CountryName", A2CountryName);
               A33ShoppingCartTotalCost = context.localUtil.CToN( cgiGet( edtShoppingCartTotalCost_Internalname), ",", ".");
               n33ShoppingCartTotalCost = false;
               AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
               A35ShoppingCartDeliveryDate = context.localUtil.CToD( cgiGet( edtShoppingCartDeliveryDate_Internalname), 2);
               AssignAttri("", false, "A35ShoppingCartDeliveryDate", context.localUtil.Format(A35ShoppingCartDeliveryDate, "99/99/99"));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ShoppingCart");
               A31ShoppingCartId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtShoppingCartId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
               forbiddenHiddens.Add("ShoppingCartId", context.localUtil.Format( (decimal)(A31ShoppingCartId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A31ShoppingCartId != Z31ShoppingCartId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("shoppingcart:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A31ShoppingCartId = (short)(Math.Round(NumberUtil.Val( GetPar( "ShoppingCartId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode9 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode9;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound9 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_090( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SHOPPINGCARTID");
                        AnyError = 1;
                        GX_FocusControl = edtShoppingCartId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11092 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12092 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
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
            E12092 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll099( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
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

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes099( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
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
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0910( )
      {
         s33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
         n33ShoppingCartTotalCost = false;
         AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         nGXsfl_83_idx = 0;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            ReadRow0910( ) ;
            if ( ( nRcdExists_10 != 0 ) || ( nIsMod_10 != 0 ) )
            {
               GetKey0910( ) ;
               if ( ( nRcdExists_10 == 0 ) && ( nRcdDeleted_10 == 0 ) )
               {
                  if ( RcdFound10 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0910( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0910( ) ;
                        CloseExtendedTableCursors0910( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
                        n33ShoppingCartTotalCost = false;
                        AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODUCTID_" + sGXsfl_83_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProductId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound10 != 0 )
                  {
                     if ( nRcdDeleted_10 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0910( ) ;
                        Load0910( ) ;
                        BeforeValidate0910( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0910( ) ;
                           O33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
                           n33ShoppingCartTotalCost = false;
                           AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
                        }
                     }
                     else
                     {
                        if ( nIsMod_10 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0910( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0910( ) ;
                              CloseExtendedTableCursors0910( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
                              n33ShoppingCartTotalCost = false;
                              AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_10 == 0 )
                     {
                        GXCCtl = "PRODUCTID_" + sGXsfl_83_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProductId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductId), 4, 0, ",", ""))) ;
            ChangePostValue( edtProductName_Internalname, A11ProductName) ;
            ChangePostValue( edtProductDescription_Internalname, A12ProductDescription) ;
            ChangePostValue( edtProductPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A13ProductPrice, 18, 2, ",", ""))) ;
            ChangePostValue( edtCategoryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoryId), 4, 0, ",", ""))) ;
            ChangePostValue( edtCategoryName_Internalname, A5CategoryName) ;
            ChangePostValue( edtProductFinalPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A39ProductFinalPrice, 18, 2, ",", ""))) ;
            ChangePostValue( edtProductQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A37ProductQuantity), 10, 0, ",", ""))) ;
            ChangePostValue( edtProductTotalCost_Internalname, StringUtil.LTrim( StringUtil.NToC( A36ProductTotalCost, 18, 2, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z10ProductId_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ProductId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z37ProductQuantity_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37ProductQuantity), 10, 0, ",", ""))) ;
            ChangePostValue( "T36ProductTotalCost_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( O36ProductTotalCost, 18, 2, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_10_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_10), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_10_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_10), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_10_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_10), 4, 0, ",", ""))) ;
            if ( nIsMod_10 != 0 )
            {
               ChangePostValue( "PRODUCTID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTDESCRIPTION_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductDescription_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTPRICE_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORYID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORYNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTFINALPRICE_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductFinalPrice_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTQUANTITY_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductQuantity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTTOTALCOST_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductTotalCost_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O33ShoppingCartTotalCost = s33ShoppingCartTotalCost;
         n33ShoppingCartTotalCost = false;
         AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption090( )
      {
      }

      protected void E11092( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV16Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_CustomerId = 0;
         AssignAttri("", false, "AV11Insert_CustomerId", StringUtil.LTrimStr( (decimal)(AV11Insert_CustomerId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "CustomerId") == 0 )
               {
                  AV11Insert_CustomerId = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_CustomerId", StringUtil.LTrimStr( (decimal)(AV11Insert_CustomerId), 4, 0));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
               AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12092( )
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
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwshoppingcart.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM099( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z34ShoppingCartDate = T00097_A34ShoppingCartDate[0];
               Z15CustomerId = T00097_A15CustomerId[0];
            }
            else
            {
               Z34ShoppingCartDate = A34ShoppingCartDate;
               Z15CustomerId = A15CustomerId;
            }
         }
         if ( GX_JID == -18 )
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
         edtShoppingCartId_Enabled = 0;
         AssignProp("", false, edtShoppingCartId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_15_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CUSTOMERID"+"'), id:'"+"CUSTOMERID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtShoppingCartId_Enabled = 0;
         AssignProp("", false, edtShoppingCartId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ShoppingCartId) )
         {
            A31ShoppingCartId = AV7ShoppingCartId;
            AssignAttri("", false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_CustomerId) )
         {
            edtCustomerId_Enabled = 0;
            AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         }
         else
         {
            edtCustomerId_Enabled = 1;
            AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_CustomerId) )
         {
            A15CustomerId = AV11Insert_CustomerId;
            AssignAttri("", false, "A15CustomerId", StringUtil.LTrimStr( (decimal)(A15CustomerId), 4, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( IsIns( )  && (DateTime.MinValue==A34ShoppingCartDate) && ( Gx_BScreen == 0 ) )
         {
            A34ShoppingCartDate = Gx_date;
            AssignAttri("", false, "A34ShoppingCartDate", context.localUtil.Format(A34ShoppingCartDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000917 */
            pr_default.execute(8, new Object[] {A31ShoppingCartId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               A33ShoppingCartTotalCost = T000917_A33ShoppingCartTotalCost[0];
               n33ShoppingCartTotalCost = T000917_n33ShoppingCartTotalCost[0];
               AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
            }
            else
            {
               A33ShoppingCartTotalCost = 0;
               n33ShoppingCartTotalCost = false;
               AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
            }
            O33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
            n33ShoppingCartTotalCost = false;
            AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
            pr_default.close(8);
            AV16Pgmname = "ShoppingCart";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T00098 */
            pr_default.execute(6, new Object[] {A15CustomerId});
            A16CustomerName = T00098_A16CustomerName[0];
            AssignAttri("", false, "A16CustomerName", A16CustomerName);
            A17CustomerDirectionDestination = T00098_A17CustomerDirectionDestination[0];
            AssignAttri("", false, "A17CustomerDirectionDestination", A17CustomerDirectionDestination);
            A1CountryId = T00098_A1CountryId[0];
            AssignAttri("", false, "A1CountryId", StringUtil.LTrimStr( (decimal)(A1CountryId), 4, 0));
            pr_default.close(6);
            /* Using cursor T00099 */
            pr_default.execute(7, new Object[] {A1CountryId});
            A2CountryName = T00099_A2CountryName[0];
            AssignAttri("", false, "A2CountryName", A2CountryName);
            pr_default.close(7);
            A35ShoppingCartDeliveryDate = DateTimeUtil.DAdd(A34ShoppingCartDate,+((int)(5)));
            AssignAttri("", false, "A35ShoppingCartDeliveryDate", context.localUtil.Format(A35ShoppingCartDeliveryDate, "99/99/99"));
         }
      }

      protected void Load099( )
      {
         /* Using cursor T000925 */
         pr_default.execute(9, new Object[] {A31ShoppingCartId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound9 = 1;
            A34ShoppingCartDate = T000925_A34ShoppingCartDate[0];
            AssignAttri("", false, "A34ShoppingCartDate", context.localUtil.Format(A34ShoppingCartDate, "99/99/99"));
            A16CustomerName = T000925_A16CustomerName[0];
            AssignAttri("", false, "A16CustomerName", A16CustomerName);
            A17CustomerDirectionDestination = T000925_A17CustomerDirectionDestination[0];
            AssignAttri("", false, "A17CustomerDirectionDestination", A17CustomerDirectionDestination);
            A2CountryName = T000925_A2CountryName[0];
            AssignAttri("", false, "A2CountryName", A2CountryName);
            A15CustomerId = T000925_A15CustomerId[0];
            AssignAttri("", false, "A15CustomerId", StringUtil.LTrimStr( (decimal)(A15CustomerId), 4, 0));
            A1CountryId = T000925_A1CountryId[0];
            AssignAttri("", false, "A1CountryId", StringUtil.LTrimStr( (decimal)(A1CountryId), 4, 0));
            A33ShoppingCartTotalCost = T000925_A33ShoppingCartTotalCost[0];
            n33ShoppingCartTotalCost = T000925_n33ShoppingCartTotalCost[0];
            AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
            ZM099( -18) ;
         }
         pr_default.close(9);
         OnLoadActions099( ) ;
      }

      protected void OnLoadActions099( )
      {
         O33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
         n33ShoppingCartTotalCost = false;
         AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         AV16Pgmname = "ShoppingCart";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         A35ShoppingCartDeliveryDate = DateTimeUtil.DAdd(A34ShoppingCartDate,+((int)(5)));
         AssignAttri("", false, "A35ShoppingCartDeliveryDate", context.localUtil.Format(A35ShoppingCartDeliveryDate, "99/99/99"));
      }

      protected void CheckExtendedTable099( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV16Pgmname = "ShoppingCart";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         /* Using cursor T000917 */
         pr_default.execute(8, new Object[] {A31ShoppingCartId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A33ShoppingCartTotalCost = T000917_A33ShoppingCartTotalCost[0];
            n33ShoppingCartTotalCost = T000917_n33ShoppingCartTotalCost[0];
            AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         }
         else
         {
            A33ShoppingCartTotalCost = 0;
            n33ShoppingCartTotalCost = false;
            AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         }
         pr_default.close(8);
         if ( ! ( (DateTime.MinValue==A34ShoppingCartDate) || ( DateTimeUtil.ResetTime ( A34ShoppingCartDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Shopping Cart Date fuera de rango", "OutOfRange", 1, "SHOPPINGCARTDATE");
            AnyError = 1;
            GX_FocusControl = edtShoppingCartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A35ShoppingCartDeliveryDate = DateTimeUtil.DAdd(A34ShoppingCartDate,+((int)(5)));
         AssignAttri("", false, "A35ShoppingCartDeliveryDate", context.localUtil.Format(A35ShoppingCartDeliveryDate, "99/99/99"));
         /* Using cursor T00098 */
         pr_default.execute(6, new Object[] {A15CustomerId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Customer'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16CustomerName = T00098_A16CustomerName[0];
         AssignAttri("", false, "A16CustomerName", A16CustomerName);
         A17CustomerDirectionDestination = T00098_A17CustomerDirectionDestination[0];
         AssignAttri("", false, "A17CustomerDirectionDestination", A17CustomerDirectionDestination);
         A1CountryId = T00098_A1CountryId[0];
         AssignAttri("", false, "A1CountryId", StringUtil.LTrimStr( (decimal)(A1CountryId), 4, 0));
         pr_default.close(6);
         /* Using cursor T00099 */
         pr_default.execute(7, new Object[] {A1CountryId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A2CountryName = T00099_A2CountryName[0];
         AssignAttri("", false, "A2CountryName", A2CountryName);
         pr_default.close(7);
         if ( (0==A15CustomerId) )
         {
            GX_msglist.addItem("Debe seleccionar un cliente", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( DateTimeUtil.ResetTime ( A34ShoppingCartDate ) > DateTimeUtil.ResetTime ( Gx_date ) )
         {
            GX_msglist.addItem("El carrito debe ser de una fecha anterior a hoy", 1, "SHOPPINGCARTDATE");
            AnyError = 1;
            GX_FocusControl = edtShoppingCartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void gxLoad_21( short A31ShoppingCartId )
      {
         /* Using cursor T000933 */
         pr_default.execute(10, new Object[] {A31ShoppingCartId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A33ShoppingCartTotalCost = T000933_A33ShoppingCartTotalCost[0];
            n33ShoppingCartTotalCost = T000933_n33ShoppingCartTotalCost[0];
            AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         }
         else
         {
            A33ShoppingCartTotalCost = 0;
            n33ShoppingCartTotalCost = false;
            AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A33ShoppingCartTotalCost, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_19( short A15CustomerId )
      {
         /* Using cursor T000934 */
         pr_default.execute(11, new Object[] {A15CustomerId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Customer'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16CustomerName = T000934_A16CustomerName[0];
         AssignAttri("", false, "A16CustomerName", A16CustomerName);
         A17CustomerDirectionDestination = T000934_A17CustomerDirectionDestination[0];
         AssignAttri("", false, "A17CustomerDirectionDestination", A17CustomerDirectionDestination);
         A1CountryId = T000934_A1CountryId[0];
         AssignAttri("", false, "A1CountryId", StringUtil.LTrimStr( (decimal)(A1CountryId), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A16CustomerName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A17CustomerDirectionDestination)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CountryId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_20( short A1CountryId )
      {
         /* Using cursor T000935 */
         pr_default.execute(12, new Object[] {A1CountryId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A2CountryName = T000935_A2CountryName[0];
         AssignAttri("", false, "A2CountryName", A2CountryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2CountryName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey099( )
      {
         /* Using cursor T000936 */
         pr_default.execute(13, new Object[] {A31ShoppingCartId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A31ShoppingCartId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM099( 18) ;
            RcdFound9 = 1;
            A31ShoppingCartId = T00097_A31ShoppingCartId[0];
            AssignAttri("", false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
            A34ShoppingCartDate = T00097_A34ShoppingCartDate[0];
            AssignAttri("", false, "A34ShoppingCartDate", context.localUtil.Format(A34ShoppingCartDate, "99/99/99"));
            A15CustomerId = T00097_A15CustomerId[0];
            AssignAttri("", false, "A15CustomerId", StringUtil.LTrimStr( (decimal)(A15CustomerId), 4, 0));
            Z31ShoppingCartId = A31ShoppingCartId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load099( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey099( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey099( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey099( ) ;
         if ( RcdFound9 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound9 = 0;
         /* Using cursor T000937 */
         pr_default.execute(14, new Object[] {A31ShoppingCartId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000937_A31ShoppingCartId[0] < A31ShoppingCartId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000937_A31ShoppingCartId[0] > A31ShoppingCartId ) ) )
            {
               A31ShoppingCartId = T000937_A31ShoppingCartId[0];
               AssignAttri("", false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T000938 */
         pr_default.execute(15, new Object[] {A31ShoppingCartId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T000938_A31ShoppingCartId[0] > A31ShoppingCartId ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T000938_A31ShoppingCartId[0] < A31ShoppingCartId ) ) )
            {
               A31ShoppingCartId = T000938_A31ShoppingCartId[0];
               AssignAttri("", false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey099( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
            n33ShoppingCartTotalCost = false;
            AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
            GX_FocusControl = edtShoppingCartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert099( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A31ShoppingCartId != Z31ShoppingCartId )
               {
                  A31ShoppingCartId = Z31ShoppingCartId;
                  AssignAttri("", false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SHOPPINGCARTID");
                  AnyError = 1;
                  GX_FocusControl = edtShoppingCartId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
                  n33ShoppingCartTotalCost = false;
                  AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtShoppingCartDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
                  n33ShoppingCartTotalCost = false;
                  AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
                  Update099( ) ;
                  GX_FocusControl = edtShoppingCartDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A31ShoppingCartId != Z31ShoppingCartId )
               {
                  /* Insert record */
                  A33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
                  n33ShoppingCartTotalCost = false;
                  AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
                  GX_FocusControl = edtShoppingCartDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert099( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SHOPPINGCARTID");
                     AnyError = 1;
                     GX_FocusControl = edtShoppingCartId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
                     n33ShoppingCartTotalCost = false;
                     AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
                     GX_FocusControl = edtShoppingCartDate_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert099( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A31ShoppingCartId != Z31ShoppingCartId )
         {
            A31ShoppingCartId = Z31ShoppingCartId;
            AssignAttri("", false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SHOPPINGCARTID");
            AnyError = 1;
            GX_FocusControl = edtShoppingCartId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
            n33ShoppingCartTotalCost = false;
            AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtShoppingCartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency099( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00096 */
            pr_default.execute(4, new Object[] {A31ShoppingCartId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCart"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( DateTimeUtil.ResetTime ( Z34ShoppingCartDate ) != DateTimeUtil.ResetTime ( T00096_A34ShoppingCartDate[0] ) ) || ( Z15CustomerId != T00096_A15CustomerId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z34ShoppingCartDate ) != DateTimeUtil.ResetTime ( T00096_A34ShoppingCartDate[0] ) )
               {
                  GXUtil.WriteLog("shoppingcart:[seudo value changed for attri]"+"ShoppingCartDate");
                  GXUtil.WriteLogRaw("Old: ",Z34ShoppingCartDate);
                  GXUtil.WriteLogRaw("Current: ",T00096_A34ShoppingCartDate[0]);
               }
               if ( Z15CustomerId != T00096_A15CustomerId[0] )
               {
                  GXUtil.WriteLog("shoppingcart:[seudo value changed for attri]"+"CustomerId");
                  GXUtil.WriteLogRaw("Old: ",Z15CustomerId);
                  GXUtil.WriteLogRaw("Current: ",T00096_A15CustomerId[0]);
               }
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
                     /* Using cursor T000939 */
                     pr_default.execute(16, new Object[] {A34ShoppingCartDate, A15CustomerId});
                     A31ShoppingCartId = T000939_A31ShoppingCartId[0];
                     AssignAttri("", false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
                     pr_default.close(16);
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
                              ResetCaption090( ) ;
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
                     /* Using cursor T000940 */
                     pr_default.execute(17, new Object[] {A34ShoppingCartDate, A15CustomerId, A31ShoppingCartId});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("ShoppingCart");
                     if ( (pr_default.getStatus(17) == 103) )
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
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
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
                  AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
                  ScanStart0910( ) ;
                  while ( RcdFound10 != 0 )
                  {
                     getByPrimaryKey0910( ) ;
                     Delete0910( ) ;
                     ScanNext0910( ) ;
                     O33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
                     n33ShoppingCartTotalCost = false;
                     AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
                  }
                  ScanEnd0910( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000941 */
                     pr_default.execute(18, new Object[] {A31ShoppingCartId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("ShoppingCart");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
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
            }
         }
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel099( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls099( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV16Pgmname = "ShoppingCart";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T000949 */
            pr_default.execute(19, new Object[] {A31ShoppingCartId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               A33ShoppingCartTotalCost = T000949_A33ShoppingCartTotalCost[0];
               n33ShoppingCartTotalCost = T000949_n33ShoppingCartTotalCost[0];
               AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
            }
            else
            {
               A33ShoppingCartTotalCost = 0;
               n33ShoppingCartTotalCost = false;
               AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
            }
            pr_default.close(19);
            A35ShoppingCartDeliveryDate = DateTimeUtil.DAdd(A34ShoppingCartDate,+((int)(5)));
            AssignAttri("", false, "A35ShoppingCartDeliveryDate", context.localUtil.Format(A35ShoppingCartDeliveryDate, "99/99/99"));
            /* Using cursor T000950 */
            pr_default.execute(20, new Object[] {A15CustomerId});
            A16CustomerName = T000950_A16CustomerName[0];
            AssignAttri("", false, "A16CustomerName", A16CustomerName);
            A17CustomerDirectionDestination = T000950_A17CustomerDirectionDestination[0];
            AssignAttri("", false, "A17CustomerDirectionDestination", A17CustomerDirectionDestination);
            A1CountryId = T000950_A1CountryId[0];
            AssignAttri("", false, "A1CountryId", StringUtil.LTrimStr( (decimal)(A1CountryId), 4, 0));
            pr_default.close(20);
            /* Using cursor T000951 */
            pr_default.execute(21, new Object[] {A1CountryId});
            A2CountryName = T000951_A2CountryName[0];
            AssignAttri("", false, "A2CountryName", A2CountryName);
            pr_default.close(21);
         }
      }

      protected void ProcessNestedLevel0910( )
      {
         s33ShoppingCartTotalCost = O33ShoppingCartTotalCost;
         n33ShoppingCartTotalCost = false;
         AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         nGXsfl_83_idx = 0;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            ReadRow0910( ) ;
            if ( ( nRcdExists_10 != 0 ) || ( nIsMod_10 != 0 ) )
            {
               standaloneNotModal0910( ) ;
               GetKey0910( ) ;
               if ( ( nRcdExists_10 == 0 ) && ( nRcdDeleted_10 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0910( ) ;
               }
               else
               {
                  if ( RcdFound10 != 0 )
                  {
                     if ( ( nRcdDeleted_10 != 0 ) && ( nRcdExists_10 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0910( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_10 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0910( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_10 == 0 )
                     {
                        GXCCtl = "PRODUCTID_" + sGXsfl_83_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProductId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
               n33ShoppingCartTotalCost = false;
               AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
            }
            ChangePostValue( edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductId), 4, 0, ",", ""))) ;
            ChangePostValue( edtProductName_Internalname, A11ProductName) ;
            ChangePostValue( edtProductDescription_Internalname, A12ProductDescription) ;
            ChangePostValue( edtProductPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A13ProductPrice, 18, 2, ",", ""))) ;
            ChangePostValue( edtCategoryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoryId), 4, 0, ",", ""))) ;
            ChangePostValue( edtCategoryName_Internalname, A5CategoryName) ;
            ChangePostValue( edtProductFinalPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A39ProductFinalPrice, 18, 2, ",", ""))) ;
            ChangePostValue( edtProductQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A37ProductQuantity), 10, 0, ",", ""))) ;
            ChangePostValue( edtProductTotalCost_Internalname, StringUtil.LTrim( StringUtil.NToC( A36ProductTotalCost, 18, 2, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z10ProductId_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ProductId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z37ProductQuantity_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37ProductQuantity), 10, 0, ",", ""))) ;
            ChangePostValue( "T36ProductTotalCost_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( O36ProductTotalCost, 18, 2, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_10_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_10), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_10_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_10), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_10_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_10), 4, 0, ",", ""))) ;
            if ( nIsMod_10 != 0 )
            {
               ChangePostValue( "PRODUCTID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTDESCRIPTION_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductDescription_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTPRICE_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORYID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORYNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTFINALPRICE_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductFinalPrice_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTQUANTITY_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductQuantity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTTOTALCOST_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductTotalCost_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0910( ) ;
         if ( AnyError != 0 )
         {
            O33ShoppingCartTotalCost = s33ShoppingCartTotalCost;
            n33ShoppingCartTotalCost = false;
            AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         }
         nRcdExists_10 = 0;
         nIsMod_10 = 0;
         nRcdDeleted_10 = 0;
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
            AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         }
         /* Restore parent mode. */
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("shoppingcart",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("shoppingcart",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart099( )
      {
         /* Scan By routine */
         /* Using cursor T000952 */
         pr_default.execute(22);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound9 = 1;
            A31ShoppingCartId = T000952_A31ShoppingCartId[0];
            AssignAttri("", false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext099( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound9 = 1;
            A31ShoppingCartId = T000952_A31ShoppingCartId[0];
            AssignAttri("", false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
         }
      }

      protected void ScanEnd099( )
      {
         pr_default.close(22);
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
            GX_msglist.addItem("No se puede eliminar carritos del día de hoy", 1, "SHOPPINGCARTDATE");
            AnyError = 1;
            GX_FocusControl = edtShoppingCartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         edtShoppingCartId_Enabled = 0;
         AssignProp("", false, edtShoppingCartId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartId_Enabled), 5, 0), true);
         edtShoppingCartDate_Enabled = 0;
         AssignProp("", false, edtShoppingCartDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartDate_Enabled), 5, 0), true);
         edtCustomerId_Enabled = 0;
         AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         edtCustomerName_Enabled = 0;
         AssignProp("", false, edtCustomerName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerName_Enabled), 5, 0), true);
         edtCustomerDirectionDestination_Enabled = 0;
         AssignProp("", false, edtCustomerDirectionDestination_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerDirectionDestination_Enabled), 5, 0), true);
         edtCountryId_Enabled = 0;
         AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         edtCountryName_Enabled = 0;
         AssignProp("", false, edtCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryName_Enabled), 5, 0), true);
         edtShoppingCartTotalCost_Enabled = 0;
         AssignProp("", false, edtShoppingCartTotalCost_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartTotalCost_Enabled), 5, 0), true);
         edtShoppingCartDeliveryDate_Enabled = 0;
         AssignProp("", false, edtShoppingCartDeliveryDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartDeliveryDate_Enabled), 5, 0), true);
      }

      protected void ZM0910( short GX_JID )
      {
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z37ProductQuantity = T00093_A37ProductQuantity[0];
            }
            else
            {
               Z37ProductQuantity = A37ProductQuantity;
            }
         }
         if ( GX_JID == -22 )
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
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProductId_Enabled = 0;
            AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         }
         else
         {
            edtProductId_Enabled = 1;
            AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         }
      }

      protected void Load0910( )
      {
         /* Using cursor T000953 */
         pr_default.execute(23, new Object[] {A31ShoppingCartId, A10ProductId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound10 = 1;
            A11ProductName = T000953_A11ProductName[0];
            A12ProductDescription = T000953_A12ProductDescription[0];
            A13ProductPrice = T000953_A13ProductPrice[0];
            A5CategoryName = T000953_A5CategoryName[0];
            A37ProductQuantity = T000953_A37ProductQuantity[0];
            A4CategoryId = T000953_A4CategoryId[0];
            ZM0910( -22) ;
         }
         pr_default.close(23);
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
            AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A33ShoppingCartTotalCost = (decimal)(O33ShoppingCartTotalCost+A36ProductTotalCost-O36ProductTotalCost);
               n33ShoppingCartTotalCost = false;
               AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A33ShoppingCartTotalCost = (decimal)(O33ShoppingCartTotalCost-O36ProductTotalCost);
                  n33ShoppingCartTotalCost = false;
                  AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
               }
            }
         }
      }

      protected void CheckExtendedTable0910( )
      {
         nIsDirty_10 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0910( ) ;
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {A10ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_83_idx;
            GX_msglist.addItem("No existe 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A11ProductName = T00094_A11ProductName[0];
         A12ProductDescription = T00094_A12ProductDescription[0];
         A13ProductPrice = T00094_A13ProductPrice[0];
         A4CategoryId = T00094_A4CategoryId[0];
         pr_default.close(2);
         /* Using cursor T00095 */
         pr_default.execute(3, new Object[] {A4CategoryId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "CATEGORYID_" + sGXsfl_83_idx;
            GX_msglist.addItem("No existe 'Category'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
         }
         A5CategoryName = T00095_A5CategoryName[0];
         pr_default.close(3);
         if ( A4CategoryId == GetProductFinalPrice0( ) )
         {
            nIsDirty_10 = 1;
            A39ProductFinalPrice = (decimal)(A13ProductPrice+(A13ProductPrice*0.05m));
            n39ProductFinalPrice = false;
         }
         else
         {
            if ( A4CategoryId == GetProductFinalPrice1( ) )
            {
               nIsDirty_10 = 1;
               A39ProductFinalPrice = (decimal)(A13ProductPrice-(A13ProductPrice*0.1m));
               n39ProductFinalPrice = false;
            }
            else
            {
               nIsDirty_10 = 1;
               A39ProductFinalPrice = A13ProductPrice;
               n39ProductFinalPrice = false;
            }
         }
         nIsDirty_10 = 1;
         A36ProductTotalCost = (decimal)(A39ProductFinalPrice*A37ProductQuantity);
         n36ProductTotalCost = false;
         if ( IsIns( )  )
         {
            nIsDirty_10 = 1;
            A33ShoppingCartTotalCost = (decimal)(O33ShoppingCartTotalCost+A36ProductTotalCost);
            n33ShoppingCartTotalCost = false;
            AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_10 = 1;
               A33ShoppingCartTotalCost = (decimal)(O33ShoppingCartTotalCost+A36ProductTotalCost-O36ProductTotalCost);
               n33ShoppingCartTotalCost = false;
               AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_10 = 1;
                  A33ShoppingCartTotalCost = (decimal)(O33ShoppingCartTotalCost-O36ProductTotalCost);
                  n33ShoppingCartTotalCost = false;
                  AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
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

      protected void gxLoad_23( short A10ProductId )
      {
         /* Using cursor T000954 */
         pr_default.execute(24, new Object[] {A10ProductId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_83_idx;
            GX_msglist.addItem("No existe 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A11ProductName = T000954_A11ProductName[0];
         A12ProductDescription = T000954_A12ProductDescription[0];
         A13ProductPrice = T000954_A13ProductPrice[0];
         A4CategoryId = T000954_A4CategoryId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A11ProductName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A12ProductDescription)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A13ProductPrice, 18, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoryId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(24) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(24);
      }

      protected void gxLoad_24( short A4CategoryId )
      {
         /* Using cursor T000955 */
         pr_default.execute(25, new Object[] {A4CategoryId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GXCCtl = "CATEGORYID_" + sGXsfl_83_idx;
            GX_msglist.addItem("No existe 'Category'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
         }
         A5CategoryName = T000955_A5CategoryName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A5CategoryName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(25) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(25);
      }

      protected void GetKey0910( )
      {
         /* Using cursor T000956 */
         pr_default.execute(26, new Object[] {A31ShoppingCartId, A10ProductId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(26);
      }

      protected void getByPrimaryKey0910( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A31ShoppingCartId, A10ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0910( 22) ;
            RcdFound10 = 1;
            InitializeNonKey0910( ) ;
            A37ProductQuantity = T00093_A37ProductQuantity[0];
            A10ProductId = T00093_A10ProductId[0];
            Z31ShoppingCartId = A31ShoppingCartId;
            Z10ProductId = A10ProductId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0910( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0910( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0910( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
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
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {A31ShoppingCartId, A10ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCartProducts"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z37ProductQuantity != T00092_A37ProductQuantity[0] ) )
            {
               if ( Z37ProductQuantity != T00092_A37ProductQuantity[0] )
               {
                  GXUtil.WriteLog("shoppingcart:[seudo value changed for attri]"+"ProductQuantity");
                  GXUtil.WriteLogRaw("Old: ",Z37ProductQuantity);
                  GXUtil.WriteLogRaw("Current: ",T00092_A37ProductQuantity[0]);
               }
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
                     /* Using cursor T000957 */
                     pr_default.execute(27, new Object[] {A31ShoppingCartId, A37ProductQuantity, A10ProductId});
                     pr_default.close(27);
                     pr_default.SmartCacheProvider.SetUpdated("ShoppingCartProducts");
                     if ( (pr_default.getStatus(27) == 1) )
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
         if ( ( nIsMod_10 != 0 ) || ( nIsDirty_10 != 0 ) )
         {
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
                        /* Using cursor T000958 */
                        pr_default.execute(28, new Object[] {A37ProductQuantity, A31ShoppingCartId, A10ProductId});
                        pr_default.close(28);
                        pr_default.SmartCacheProvider.SetUpdated("ShoppingCartProducts");
                        if ( (pr_default.getStatus(28) == 103) )
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
         }
         CloseExtendedTableCursors0910( ) ;
      }

      protected void DeferredUpdate0910( )
      {
      }

      protected void Delete0910( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
                  /* Using cursor T000959 */
                  pr_default.execute(29, new Object[] {A31ShoppingCartId, A10ProductId});
                  pr_default.close(29);
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
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0910( ) ;
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0910( )
      {
         standaloneModal0910( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000960 */
            pr_default.execute(30, new Object[] {A10ProductId});
            A11ProductName = T000960_A11ProductName[0];
            A12ProductDescription = T000960_A12ProductDescription[0];
            A13ProductPrice = T000960_A13ProductPrice[0];
            A4CategoryId = T000960_A4CategoryId[0];
            pr_default.close(30);
            /* Using cursor T000961 */
            pr_default.execute(31, new Object[] {A4CategoryId});
            A5CategoryName = T000961_A5CategoryName[0];
            pr_default.close(31);
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
               AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A33ShoppingCartTotalCost = (decimal)(O33ShoppingCartTotalCost+A36ProductTotalCost-O36ProductTotalCost);
                  n33ShoppingCartTotalCost = false;
                  AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A33ShoppingCartTotalCost = (decimal)(O33ShoppingCartTotalCost-O36ProductTotalCost);
                     n33ShoppingCartTotalCost = false;
                     AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
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

      public void ScanStart0910( )
      {
         /* Scan By routine */
         /* Using cursor T000962 */
         pr_default.execute(32, new Object[] {A31ShoppingCartId});
         RcdFound10 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound10 = 1;
            A10ProductId = T000962_A10ProductId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0910( )
      {
         /* Scan next routine */
         pr_default.readNext(32);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound10 = 1;
            A10ProductId = T000962_A10ProductId[0];
         }
      }

      protected void ScanEnd0910( )
      {
         pr_default.close(32);
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
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtProductDescription_Enabled = 0;
         AssignProp("", false, edtProductDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductDescription_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtProductPrice_Enabled = 0;
         AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtCategoryId_Enabled = 0;
         AssignProp("", false, edtCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtCategoryName_Enabled = 0;
         AssignProp("", false, edtCategoryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryName_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtProductFinalPrice_Enabled = 0;
         AssignProp("", false, edtProductFinalPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductFinalPrice_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtProductQuantity_Enabled = 0;
         AssignProp("", false, edtProductQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductQuantity_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtProductTotalCost_Enabled = 0;
         AssignProp("", false, edtProductTotalCost_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductTotalCost_Enabled), 5, 0), !bGXsfl_83_Refreshing);
      }

      protected void send_integrity_lvl_hashes0910( )
      {
      }

      protected void send_integrity_lvl_hashes099( )
      {
      }

      protected void SubsflControlProps_8310( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_83_idx;
         imgprompt_10_Internalname = "PROMPT_10_"+sGXsfl_83_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_83_idx;
         edtProductDescription_Internalname = "PRODUCTDESCRIPTION_"+sGXsfl_83_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_83_idx;
         edtCategoryId_Internalname = "CATEGORYID_"+sGXsfl_83_idx;
         edtCategoryName_Internalname = "CATEGORYNAME_"+sGXsfl_83_idx;
         edtProductFinalPrice_Internalname = "PRODUCTFINALPRICE_"+sGXsfl_83_idx;
         edtProductQuantity_Internalname = "PRODUCTQUANTITY_"+sGXsfl_83_idx;
         edtProductTotalCost_Internalname = "PRODUCTTOTALCOST_"+sGXsfl_83_idx;
      }

      protected void SubsflControlProps_fel_8310( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_83_fel_idx;
         imgprompt_10_Internalname = "PROMPT_10_"+sGXsfl_83_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_83_fel_idx;
         edtProductDescription_Internalname = "PRODUCTDESCRIPTION_"+sGXsfl_83_fel_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_83_fel_idx;
         edtCategoryId_Internalname = "CATEGORYID_"+sGXsfl_83_fel_idx;
         edtCategoryName_Internalname = "CATEGORYNAME_"+sGXsfl_83_fel_idx;
         edtProductFinalPrice_Internalname = "PRODUCTFINALPRICE_"+sGXsfl_83_fel_idx;
         edtProductQuantity_Internalname = "PRODUCTQUANTITY_"+sGXsfl_83_fel_idx;
         edtProductTotalCost_Internalname = "PRODUCTTOTALCOST_"+sGXsfl_83_fel_idx;
      }

      protected void AddRow0910( )
      {
         nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_8310( ) ;
         SendRow0910( ) ;
      }

      protected void SendRow0910( )
      {
         Gridshoppingcart_productRow = GXWebRow.GetNew(context);
         if ( subGridshoppingcart_product_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridshoppingcart_product_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridshoppingcart_product_Class, "") != 0 )
            {
               subGridshoppingcart_product_Linesclass = subGridshoppingcart_product_Class+"Odd";
            }
         }
         else if ( subGridshoppingcart_product_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridshoppingcart_product_Backstyle = 0;
            subGridshoppingcart_product_Backcolor = subGridshoppingcart_product_Allbackcolor;
            if ( StringUtil.StrCmp(subGridshoppingcart_product_Class, "") != 0 )
            {
               subGridshoppingcart_product_Linesclass = subGridshoppingcart_product_Class+"Uniform";
            }
         }
         else if ( subGridshoppingcart_product_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridshoppingcart_product_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridshoppingcart_product_Class, "") != 0 )
            {
               subGridshoppingcart_product_Linesclass = subGridshoppingcart_product_Class+"Odd";
            }
            subGridshoppingcart_product_Backcolor = (int)(0x0);
         }
         else if ( subGridshoppingcart_product_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridshoppingcart_product_Backstyle = 1;
            if ( ((int)((nGXsfl_83_idx) % (2))) == 0 )
            {
               subGridshoppingcart_product_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridshoppingcart_product_Class, "") != 0 )
               {
                  subGridshoppingcart_product_Linesclass = subGridshoppingcart_product_Class+"Even";
               }
            }
            else
            {
               subGridshoppingcart_product_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridshoppingcart_product_Class, "") != 0 )
               {
                  subGridshoppingcart_product_Linesclass = subGridshoppingcart_product_Class+"Odd";
               }
            }
         }
         imgprompt_10_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTID_"+sGXsfl_83_idx+"'), id:'"+"PRODUCTID_"+sGXsfl_83_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_10_"+sGXsfl_83_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A10ProductId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,84);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_10_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_10_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridshoppingcart_productRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_10_Internalname,(string)sImgUrl,(string)imgprompt_10_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_10_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,(string)A11ProductName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductDescription_Internalname,(string)A12ProductDescription,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductDescription_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A13ProductPrice, 18, 2, ",", "")),StringUtil.LTrim( ((edtProductPrice_Enabled!=0) ? context.localUtil.Format( A13ProductPrice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A13ProductPrice, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,87);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductPrice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoryId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoryId), 4, 0, ",", "")),StringUtil.LTrim( ((edtCategoryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A4CategoryId), "ZZZ9") : context.localUtil.Format( (decimal)(A4CategoryId), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,88);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoryId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCategoryId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoryName_Internalname,(string)A5CategoryName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoryName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCategoryName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductFinalPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A39ProductFinalPrice, 18, 2, ",", "")),StringUtil.LTrim( ((edtProductFinalPrice_Enabled!=0) ? context.localUtil.Format( A39ProductFinalPrice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A39ProductFinalPrice, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,90);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductFinalPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductFinalPrice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductQuantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A37ProductQuantity), 10, 0, ",", "")),StringUtil.LTrim( ((edtProductQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A37ProductQuantity), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A37ProductQuantity), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,91);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductQuantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductQuantity_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 92,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductTotalCost_Internalname,StringUtil.LTrim( StringUtil.NToC( A36ProductTotalCost, 18, 2, ",", "")),StringUtil.LTrim( ((edtProductTotalCost_Enabled!=0) ? context.localUtil.Format( A36ProductTotalCost, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A36ProductTotalCost, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,92);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductTotalCost_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductTotalCost_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         ajax_sending_grid_row(Gridshoppingcart_productRow);
         send_integrity_lvl_hashes0910( ) ;
         GXCCtl = "Z10ProductId_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ProductId), 4, 0, ",", "")));
         GXCCtl = "Z37ProductQuantity_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37ProductQuantity), 10, 0, ",", "")));
         GXCCtl = "O36ProductTotalCost_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( O36ProductTotalCost, 18, 2, ",", "")));
         GXCCtl = "nRcdDeleted_10_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_10), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_10_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_10), 4, 0, ",", "")));
         GXCCtl = "nIsMod_10_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_10), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_83_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vSHOPPINGCARTID_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ShoppingCartId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTDESCRIPTION_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductDescription_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTPRICE_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CATEGORYID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CATEGORYNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTFINALPRICE_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductFinalPrice_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTQUANTITY_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductQuantity_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTTOTALCOST_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductTotalCost_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_10_"+sGXsfl_83_idx+"Link", StringUtil.RTrim( imgprompt_10_Link));
         ajax_sending_grid_row(null);
         Gridshoppingcart_productContainer.AddRow(Gridshoppingcart_productRow);
      }

      protected void ReadRow0910( )
      {
         nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_8310( ) ;
         edtProductId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtProductName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtProductDescription_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTDESCRIPTION_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtProductPrice_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTPRICE_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtCategoryId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORYID_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtCategoryName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORYNAME_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtProductFinalPrice_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTFINALPRICE_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtProductQuantity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTQUANTITY_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtProductTotalCost_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTTOTALCOST_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         imgprompt_15_Link = cgiGet( "PROMPT_10_"+sGXsfl_83_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_83_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            wbErr = true;
            A10ProductId = 0;
         }
         else
         {
            A10ProductId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         A11ProductName = cgiGet( edtProductName_Internalname);
         A12ProductDescription = cgiGet( edtProductDescription_Internalname);
         A13ProductPrice = context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ",", ".");
         A4CategoryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         A5CategoryName = cgiGet( edtCategoryName_Internalname);
         A39ProductFinalPrice = context.localUtil.CToN( cgiGet( edtProductFinalPrice_Internalname), ",", ".");
         n39ProductFinalPrice = false;
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductQuantity_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductQuantity_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
         {
            GXCCtl = "PRODUCTQUANTITY_" + sGXsfl_83_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductQuantity_Internalname;
            wbErr = true;
            A37ProductQuantity = 0;
         }
         else
         {
            A37ProductQuantity = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProductQuantity_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         A36ProductTotalCost = context.localUtil.CToN( cgiGet( edtProductTotalCost_Internalname), ",", ".");
         n36ProductTotalCost = false;
         GXCCtl = "Z10ProductId_" + sGXsfl_83_idx;
         Z10ProductId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z37ProductQuantity_" + sGXsfl_83_idx;
         Z37ProductQuantity = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "O36ProductTotalCost_" + sGXsfl_83_idx;
         O36ProductTotalCost = context.localUtil.CToN( cgiGet( GXCCtl), ",", ".");
         GXCCtl = "nRcdDeleted_10_" + sGXsfl_83_idx;
         nRcdDeleted_10 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_10_" + sGXsfl_83_idx;
         nRcdExists_10 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_10_" + sGXsfl_83_idx;
         nIsMod_10 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtProductId_Enabled = edtProductId_Enabled;
      }

      protected void ConfirmValues090( )
      {
         nGXsfl_83_idx = 0;
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_8310( ) ;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
            SubsflControlProps_8310( ) ;
            ChangePostValue( "Z10ProductId_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z10ProductId_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z10ProductId_"+sGXsfl_83_idx) ;
            ChangePostValue( "Z37ProductQuantity_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z37ProductQuantity_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z37ProductQuantity_"+sGXsfl_83_idx) ;
         }
         ChangePostValue( "O36ProductTotalCost", cgiGet( "T36ProductTotalCost")) ;
         DeletePostValue( "T36ProductTotalCost") ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 239440), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("shoppingcart.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ShoppingCartId,4,0))}, new string[] {"Gx_mode","ShoppingCartId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"ShoppingCart");
         forbiddenHiddens.Add("ShoppingCartId", context.localUtil.Format( (decimal)(A31ShoppingCartId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("shoppingcart:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z31ShoppingCartId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31ShoppingCartId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z34ShoppingCartDate", context.localUtil.DToC( Z34ShoppingCartDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z15CustomerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15CustomerId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "O33ShoppingCartTotalCost", StringUtil.LTrim( StringUtil.NToC( O33ShoppingCartTotalCost, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_83", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_83_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N15CustomerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CustomerId), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vSHOPPINGCARTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ShoppingCartId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOPPINGCARTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ShoppingCartId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_CustomerId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("shoppingcart.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ShoppingCartId,4,0))}, new string[] {"Gx_mode","ShoppingCartId"})  ;
      }

      public override string GetPgmname( )
      {
         return "ShoppingCart" ;
      }

      public override string GetPgmdesc( )
      {
         return "Shopping Cart" ;
      }

      protected void InitializeNonKey099( )
      {
         A15CustomerId = 0;
         AssignAttri("", false, "A15CustomerId", StringUtil.LTrimStr( (decimal)(A15CustomerId), 4, 0));
         A35ShoppingCartDeliveryDate = DateTime.MinValue;
         AssignAttri("", false, "A35ShoppingCartDeliveryDate", context.localUtil.Format(A35ShoppingCartDeliveryDate, "99/99/99"));
         A16CustomerName = "";
         AssignAttri("", false, "A16CustomerName", A16CustomerName);
         A17CustomerDirectionDestination = "";
         AssignAttri("", false, "A17CustomerDirectionDestination", A17CustomerDirectionDestination);
         A1CountryId = 0;
         AssignAttri("", false, "A1CountryId", StringUtil.LTrimStr( (decimal)(A1CountryId), 4, 0));
         A2CountryName = "";
         AssignAttri("", false, "A2CountryName", A2CountryName);
         A33ShoppingCartTotalCost = 0;
         n33ShoppingCartTotalCost = false;
         AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         A34ShoppingCartDate = Gx_date;
         AssignAttri("", false, "A34ShoppingCartDate", context.localUtil.Format(A34ShoppingCartDate, "99/99/99"));
         O33ShoppingCartTotalCost = A33ShoppingCartTotalCost;
         n33ShoppingCartTotalCost = false;
         AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         Z34ShoppingCartDate = DateTime.MinValue;
         Z15CustomerId = 0;
      }

      protected void InitAll099( )
      {
         A31ShoppingCartId = 0;
         AssignAttri("", false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
         InitializeNonKey099( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A34ShoppingCartDate = i34ShoppingCartDate;
         AssignAttri("", false, "A34ShoppingCartDate", context.localUtil.Format(A34ShoppingCartDate, "99/99/99"));
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

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024111119411468", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("shoppingcart.js", "?2024111119411468", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties10( )
      {
         edtProductId_Enabled = defedtProductId_Enabled;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
      }

      protected void StartGridControl83( )
      {
         Gridshoppingcart_productContainer.AddObjectProperty("GridName", "Gridshoppingcart_product");
         Gridshoppingcart_productContainer.AddObjectProperty("Header", subGridshoppingcart_product_Header);
         Gridshoppingcart_productContainer.AddObjectProperty("Class", "Grid");
         Gridshoppingcart_productContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Backcolorstyle), 1, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("CmpContext", "");
         Gridshoppingcart_productContainer.AddObjectProperty("InMasterPage", "false");
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductId), 4, 0, ".", ""))));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11ProductName));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A12ProductDescription));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductDescription_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A13ProductPrice, 18, 2, ".", ""))));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoryId), 4, 0, ".", ""))));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryId_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A5CategoryName));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryName_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A39ProductFinalPrice, 18, 2, ".", ""))));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductFinalPrice_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A37ProductQuantity), 10, 0, ".", ""))));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductQuantity_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A36ProductTotalCost, 18, 2, ".", ""))));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductTotalCost_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Selectedindex), 4, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Allowselection), 1, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Selectioncolor), 9, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Allowhovering), 1, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Hoveringcolor), 9, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Allowcollapsing), 1, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtShoppingCartId_Internalname = "SHOPPINGCARTID";
         edtShoppingCartDate_Internalname = "SHOPPINGCARTDATE";
         edtCustomerId_Internalname = "CUSTOMERID";
         edtCustomerName_Internalname = "CUSTOMERNAME";
         edtCustomerDirectionDestination_Internalname = "CUSTOMERDIRECTIONDESTINATION";
         edtCountryId_Internalname = "COUNTRYID";
         edtCountryName_Internalname = "COUNTRYNAME";
         edtShoppingCartTotalCost_Internalname = "SHOPPINGCARTTOTALCOST";
         edtShoppingCartDeliveryDate_Internalname = "SHOPPINGCARTDELIVERYDATE";
         lblTitleproduct_Internalname = "TITLEPRODUCT";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductDescription_Internalname = "PRODUCTDESCRIPTION";
         edtProductPrice_Internalname = "PRODUCTPRICE";
         edtCategoryId_Internalname = "CATEGORYID";
         edtCategoryName_Internalname = "CATEGORYNAME";
         edtProductFinalPrice_Internalname = "PRODUCTFINALPRICE";
         edtProductQuantity_Internalname = "PRODUCTQUANTITY";
         edtProductTotalCost_Internalname = "PRODUCTTOTALCOST";
         divProducttable_Internalname = "PRODUCTTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_15_Internalname = "PROMPT_15";
         imgprompt_10_Internalname = "PROMPT_10";
         subGridshoppingcart_product_Internalname = "GRIDSHOPPINGCART_PRODUCT";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("ObligatorioShop", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridshoppingcart_product_Allowcollapsing = 0;
         subGridshoppingcart_product_Allowselection = 0;
         subGridshoppingcart_product_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Shopping Cart";
         edtProductTotalCost_Jsonclick = "";
         edtProductQuantity_Jsonclick = "";
         edtProductFinalPrice_Jsonclick = "";
         edtCategoryName_Jsonclick = "";
         edtCategoryId_Jsonclick = "";
         edtProductPrice_Jsonclick = "";
         edtProductDescription_Jsonclick = "";
         edtProductName_Jsonclick = "";
         imgprompt_10_Visible = 1;
         imgprompt_10_Link = "";
         imgprompt_15_Visible = 1;
         edtProductId_Jsonclick = "";
         subGridshoppingcart_product_Class = "Grid";
         subGridshoppingcart_product_Backcolorstyle = 0;
         edtProductTotalCost_Enabled = 0;
         edtProductQuantity_Enabled = 1;
         edtProductFinalPrice_Enabled = 0;
         edtCategoryName_Enabled = 0;
         edtCategoryId_Enabled = 0;
         edtProductPrice_Enabled = 0;
         edtProductDescription_Enabled = 0;
         edtProductName_Enabled = 0;
         edtProductId_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtShoppingCartDeliveryDate_Jsonclick = "";
         edtShoppingCartDeliveryDate_Enabled = 0;
         edtShoppingCartTotalCost_Jsonclick = "";
         edtShoppingCartTotalCost_Enabled = 0;
         edtCountryName_Jsonclick = "";
         edtCountryName_Enabled = 0;
         edtCountryId_Jsonclick = "";
         edtCountryId_Enabled = 0;
         edtCustomerDirectionDestination_Jsonclick = "";
         edtCustomerDirectionDestination_Enabled = 0;
         edtCustomerName_Jsonclick = "";
         edtCustomerName_Enabled = 0;
         imgprompt_15_Visible = 1;
         imgprompt_15_Link = "";
         edtCustomerId_Jsonclick = "";
         edtCustomerId_Enabled = 1;
         edtShoppingCartDate_Jsonclick = "";
         edtShoppingCartDate_Enabled = 1;
         edtShoppingCartId_Jsonclick = "";
         edtShoppingCartId_Enabled = 0;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GX15ASAPRODUCTFINALPRICE0910( decimal A13ProductPrice ,
                                                   short A4CategoryId )
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
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A39ProductFinalPrice, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridshoppingcart_product_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_8310( ) ;
         while ( nGXsfl_83_idx <= nRC_GXsfl_83 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0910( ) ;
            standaloneModal0910( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0910( ) ;
            nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
            SubsflControlProps_8310( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridshoppingcart_productContainer)) ;
         /* End function gxnrGridshoppingcart_product_newrow */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
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

      public void Valid_Shoppingcartid( )
      {
         n33ShoppingCartTotalCost = false;
         /* Using cursor T000949 */
         pr_default.execute(19, new Object[] {A31ShoppingCartId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A33ShoppingCartTotalCost = T000949_A33ShoppingCartTotalCost[0];
            n33ShoppingCartTotalCost = T000949_n33ShoppingCartTotalCost[0];
         }
         else
         {
            A33ShoppingCartTotalCost = 0;
            n33ShoppingCartTotalCost = false;
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A33ShoppingCartTotalCost", StringUtil.LTrim( StringUtil.NToC( A33ShoppingCartTotalCost, 18, 2, ".", "")));
      }

      public void Valid_Customerid( )
      {
         /* Using cursor T000950 */
         pr_default.execute(20, new Object[] {A15CustomerId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Customer'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
         }
         A16CustomerName = T000950_A16CustomerName[0];
         A17CustomerDirectionDestination = T000950_A17CustomerDirectionDestination[0];
         A1CountryId = T000950_A1CountryId[0];
         pr_default.close(20);
         /* Using cursor T000951 */
         pr_default.execute(21, new Object[] {A1CountryId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A2CountryName = T000951_A2CountryName[0];
         pr_default.close(21);
         if ( (0==A15CustomerId) )
         {
            GX_msglist.addItem("Debe seleccionar un cliente", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A16CustomerName", A16CustomerName);
         AssignAttri("", false, "A17CustomerDirectionDestination", A17CustomerDirectionDestination);
         AssignAttri("", false, "A1CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A2CountryName", A2CountryName);
      }

      public void Valid_Productid( )
      {
         n39ProductFinalPrice = false;
         /* Using cursor T000960 */
         pr_default.execute(30, new Object[] {A10ProductId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No existe 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
         }
         A11ProductName = T000960_A11ProductName[0];
         A12ProductDescription = T000960_A12ProductDescription[0];
         A13ProductPrice = T000960_A13ProductPrice[0];
         A4CategoryId = T000960_A4CategoryId[0];
         pr_default.close(30);
         /* Using cursor T000961 */
         pr_default.execute(31, new Object[] {A4CategoryId});
         if ( (pr_default.getStatus(31) == 101) )
         {
            GX_msglist.addItem("No existe 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
         }
         A5CategoryName = T000961_A5CategoryName[0];
         pr_default.close(31);
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
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A11ProductName", A11ProductName);
         AssignAttri("", false, "A12ProductDescription", A12ProductDescription);
         AssignAttri("", false, "A13ProductPrice", StringUtil.LTrim( StringUtil.NToC( A13ProductPrice, 18, 2, ".", "")));
         AssignAttri("", false, "A4CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoryId), 4, 0, ".", "")));
         AssignAttri("", false, "A5CategoryName", A5CategoryName);
         AssignAttri("", false, "A39ProductFinalPrice", StringUtil.LTrim( StringUtil.NToC( A39ProductFinalPrice, 18, 2, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7ShoppingCartId","fld":"vSHOPPINGCARTID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7ShoppingCartId","fld":"vSHOPPINGCARTID","pic":"ZZZ9","hsh":true},{"av":"A31ShoppingCartId","fld":"SHOPPINGCARTID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12092","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"A33ShoppingCartTotalCost","fld":"SHOPPINGCARTTOTALCOST","pic":"ZZZZZZZZZZZZZZ9.99"},{"av":"A15CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"A31ShoppingCartId","fld":"SHOPPINGCARTID","pic":"ZZZ9"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_SHOPPINGCARTID","""{"handler":"Valid_Shoppingcartid","iparms":[{"av":"A31ShoppingCartId","fld":"SHOPPINGCARTID","pic":"ZZZ9"},{"av":"A33ShoppingCartTotalCost","fld":"SHOPPINGCARTTOTALCOST","pic":"ZZZZZZZZZZZZZZ9.99"}]""");
         setEventMetadata("VALID_SHOPPINGCARTID",""","oparms":[{"av":"A33ShoppingCartTotalCost","fld":"SHOPPINGCARTTOTALCOST","pic":"ZZZZZZZZZZZZZZ9.99"}]}""");
         setEventMetadata("VALID_SHOPPINGCARTDATE","""{"handler":"Valid_Shoppingcartdate","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERID","""{"handler":"Valid_Customerid","iparms":[{"av":"A15CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"A1CountryId","fld":"COUNTRYID","pic":"ZZZ9"},{"av":"A16CustomerName","fld":"CUSTOMERNAME"},{"av":"A17CustomerDirectionDestination","fld":"CUSTOMERDIRECTIONDESTINATION"},{"av":"A2CountryName","fld":"COUNTRYNAME"}]""");
         setEventMetadata("VALID_CUSTOMERID",""","oparms":[{"av":"A16CustomerName","fld":"CUSTOMERNAME"},{"av":"A17CustomerDirectionDestination","fld":"CUSTOMERDIRECTIONDESTINATION"},{"av":"A1CountryId","fld":"COUNTRYID","pic":"ZZZ9"},{"av":"A2CountryName","fld":"COUNTRYNAME"}]}""");
         setEventMetadata("VALID_COUNTRYID","""{"handler":"Valid_Countryid","iparms":[]}""");
         setEventMetadata("VALID_SHOPPINGCARTTOTALCOST","""{"handler":"Valid_Shoppingcarttotalcost","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTID","""{"handler":"Valid_Productid","iparms":[{"av":"A10ProductId","fld":"PRODUCTID","pic":"ZZZ9"},{"av":"A4CategoryId","fld":"CATEGORYID","pic":"ZZZ9"},{"av":"A13ProductPrice","fld":"PRODUCTPRICE","pic":"ZZZZZZZZZZZZZZ9.99"},{"av":"A11ProductName","fld":"PRODUCTNAME"},{"av":"A12ProductDescription","fld":"PRODUCTDESCRIPTION"},{"av":"A5CategoryName","fld":"CATEGORYNAME"},{"av":"A39ProductFinalPrice","fld":"PRODUCTFINALPRICE","pic":"ZZZZZZZZZZZZZZ9.99"}]""");
         setEventMetadata("VALID_PRODUCTID",""","oparms":[{"av":"A11ProductName","fld":"PRODUCTNAME"},{"av":"A12ProductDescription","fld":"PRODUCTDESCRIPTION"},{"av":"A13ProductPrice","fld":"PRODUCTPRICE","pic":"ZZZZZZZZZZZZZZ9.99"},{"av":"A4CategoryId","fld":"CATEGORYID","pic":"ZZZ9"},{"av":"A5CategoryName","fld":"CATEGORYNAME"},{"av":"A39ProductFinalPrice","fld":"PRODUCTFINALPRICE","pic":"ZZZZZZZZZZZZZZ9.99"}]}""");
         setEventMetadata("VALID_PRODUCTPRICE","""{"handler":"Valid_Productprice","iparms":[]}""");
         setEventMetadata("VALID_CATEGORYID","""{"handler":"Valid_Categoryid","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTFINALPRICE","""{"handler":"Valid_Productfinalprice","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTQUANTITY","""{"handler":"Valid_Productquantity","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTTOTALCOST","""{"handler":"Valid_Producttotalcost","iparms":[]}""");
         return  ;
      }

      protected short GetProductFinalPrice1( )
      {
         X4CategoryId = 0;
         Gx_first = true;
         /* Using cursor T000963 */
         pr_default.execute(33);
         while ( (pr_default.getStatus(33) != 101) )
         {
            if ( StringUtil.StrCmp(T000963_A5CategoryName[0], "Entretenimiento") == 0 )
            {
               X4CategoryId = (short)(T000963_A4CategoryId[0]);
               if (true) break;
            }
            pr_default.readNext(33);
         }
         pr_default.close(33);
         return X4CategoryId ;
      }

      protected short GetProductFinalPrice0( )
      {
         X4CategoryId = 0;
         Gx_first = true;
         /* Using cursor T000964 */
         pr_default.execute(34);
         while ( (pr_default.getStatus(34) != 101) )
         {
            if ( StringUtil.StrCmp(T000964_A5CategoryName[0], "Joyeria") == 0 )
            {
               X4CategoryId = (short)(T000964_A4CategoryId[0]);
               if (true) break;
            }
            pr_default.readNext(34);
         }
         pr_default.close(34);
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
         pr_default.close(30);
         pr_default.close(31);
         pr_default.close(5);
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z34ShoppingCartDate = DateTime.MinValue;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A34ShoppingCartDate = DateTime.MinValue;
         imgprompt_15_gximage = "";
         sImgUrl = "";
         A16CustomerName = "";
         A17CustomerDirectionDestination = "";
         A2CountryName = "";
         A35ShoppingCartDeliveryDate = DateTime.MinValue;
         lblTitleproduct_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridshoppingcart_productContainer = new GXWebGrid( context);
         sMode10 = "";
         sStyleString = "";
         Gx_date = DateTime.MinValue;
         AV16Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode9 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A11ProductName = "";
         A12ProductDescription = "";
         A5CategoryName = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z16CustomerName = "";
         Z17CustomerDirectionDestination = "";
         Z2CountryName = "";
         T000917_A33ShoppingCartTotalCost = new decimal[1] ;
         T000917_n33ShoppingCartTotalCost = new bool[] {false} ;
         T00098_A16CustomerName = new string[] {""} ;
         T00098_A17CustomerDirectionDestination = new string[] {""} ;
         T00098_A1CountryId = new short[1] ;
         T00099_A2CountryName = new string[] {""} ;
         T000925_A31ShoppingCartId = new short[1] ;
         T000925_A34ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         T000925_A16CustomerName = new string[] {""} ;
         T000925_A17CustomerDirectionDestination = new string[] {""} ;
         T000925_A2CountryName = new string[] {""} ;
         T000925_A15CustomerId = new short[1] ;
         T000925_A1CountryId = new short[1] ;
         T000925_A33ShoppingCartTotalCost = new decimal[1] ;
         T000925_n33ShoppingCartTotalCost = new bool[] {false} ;
         T000933_A33ShoppingCartTotalCost = new decimal[1] ;
         T000933_n33ShoppingCartTotalCost = new bool[] {false} ;
         T000934_A16CustomerName = new string[] {""} ;
         T000934_A17CustomerDirectionDestination = new string[] {""} ;
         T000934_A1CountryId = new short[1] ;
         T000935_A2CountryName = new string[] {""} ;
         T000936_A31ShoppingCartId = new short[1] ;
         T00097_A31ShoppingCartId = new short[1] ;
         T00097_A34ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         T00097_A15CustomerId = new short[1] ;
         T000937_A31ShoppingCartId = new short[1] ;
         T000938_A31ShoppingCartId = new short[1] ;
         T00096_A31ShoppingCartId = new short[1] ;
         T00096_A34ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         T00096_A15CustomerId = new short[1] ;
         T000939_A31ShoppingCartId = new short[1] ;
         T000949_A33ShoppingCartTotalCost = new decimal[1] ;
         T000949_n33ShoppingCartTotalCost = new bool[] {false} ;
         T000950_A16CustomerName = new string[] {""} ;
         T000950_A17CustomerDirectionDestination = new string[] {""} ;
         T000950_A1CountryId = new short[1] ;
         T000951_A2CountryName = new string[] {""} ;
         T000952_A31ShoppingCartId = new short[1] ;
         Z11ProductName = "";
         Z12ProductDescription = "";
         Z5CategoryName = "";
         T000953_A31ShoppingCartId = new short[1] ;
         T000953_A11ProductName = new string[] {""} ;
         T000953_A12ProductDescription = new string[] {""} ;
         T000953_A13ProductPrice = new decimal[1] ;
         T000953_A5CategoryName = new string[] {""} ;
         T000953_A37ProductQuantity = new long[1] ;
         T000953_A10ProductId = new short[1] ;
         T000953_A4CategoryId = new short[1] ;
         T00094_A11ProductName = new string[] {""} ;
         T00094_A12ProductDescription = new string[] {""} ;
         T00094_A13ProductPrice = new decimal[1] ;
         T00094_A4CategoryId = new short[1] ;
         T00095_A5CategoryName = new string[] {""} ;
         T000954_A11ProductName = new string[] {""} ;
         T000954_A12ProductDescription = new string[] {""} ;
         T000954_A13ProductPrice = new decimal[1] ;
         T000954_A4CategoryId = new short[1] ;
         T000955_A5CategoryName = new string[] {""} ;
         T000956_A31ShoppingCartId = new short[1] ;
         T000956_A10ProductId = new short[1] ;
         T00093_A31ShoppingCartId = new short[1] ;
         T00093_A37ProductQuantity = new long[1] ;
         T00093_A10ProductId = new short[1] ;
         T00092_A31ShoppingCartId = new short[1] ;
         T00092_A37ProductQuantity = new long[1] ;
         T00092_A10ProductId = new short[1] ;
         T000960_A11ProductName = new string[] {""} ;
         T000960_A12ProductDescription = new string[] {""} ;
         T000960_A13ProductPrice = new decimal[1] ;
         T000960_A4CategoryId = new short[1] ;
         T000961_A5CategoryName = new string[] {""} ;
         T000962_A31ShoppingCartId = new short[1] ;
         T000962_A10ProductId = new short[1] ;
         Gridshoppingcart_productRow = new GXWebRow();
         subGridshoppingcart_product_Linesclass = "";
         ROClassString = "";
         imgprompt_10_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i34ShoppingCartDate = DateTime.MinValue;
         Gridshoppingcart_productColumn = new GXWebColumn();
         T000963_A5CategoryName = new string[] {""} ;
         T000963_A4CategoryId = new short[1] ;
         T000964_A5CategoryName = new string[] {""} ;
         T000964_A4CategoryId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.shoppingcart__default(),
            new Object[][] {
                new Object[] {
               T00092_A31ShoppingCartId, T00092_A37ProductQuantity, T00092_A10ProductId
               }
               , new Object[] {
               T00093_A31ShoppingCartId, T00093_A37ProductQuantity, T00093_A10ProductId
               }
               , new Object[] {
               T00094_A11ProductName, T00094_A12ProductDescription, T00094_A13ProductPrice, T00094_A4CategoryId
               }
               , new Object[] {
               T00095_A5CategoryName
               }
               , new Object[] {
               T00096_A31ShoppingCartId, T00096_A34ShoppingCartDate, T00096_A15CustomerId
               }
               , new Object[] {
               T00097_A31ShoppingCartId, T00097_A34ShoppingCartDate, T00097_A15CustomerId
               }
               , new Object[] {
               T00098_A16CustomerName, T00098_A17CustomerDirectionDestination, T00098_A1CountryId
               }
               , new Object[] {
               T00099_A2CountryName
               }
               , new Object[] {
               T000917_A33ShoppingCartTotalCost, T000917_n33ShoppingCartTotalCost
               }
               , new Object[] {
               T000925_A31ShoppingCartId, T000925_A34ShoppingCartDate, T000925_A16CustomerName, T000925_A17CustomerDirectionDestination, T000925_A2CountryName, T000925_A15CustomerId, T000925_A1CountryId, T000925_A33ShoppingCartTotalCost, T000925_n33ShoppingCartTotalCost
               }
               , new Object[] {
               T000933_A33ShoppingCartTotalCost, T000933_n33ShoppingCartTotalCost
               }
               , new Object[] {
               T000934_A16CustomerName, T000934_A17CustomerDirectionDestination, T000934_A1CountryId
               }
               , new Object[] {
               T000935_A2CountryName
               }
               , new Object[] {
               T000936_A31ShoppingCartId
               }
               , new Object[] {
               T000937_A31ShoppingCartId
               }
               , new Object[] {
               T000938_A31ShoppingCartId
               }
               , new Object[] {
               T000939_A31ShoppingCartId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000949_A33ShoppingCartTotalCost, T000949_n33ShoppingCartTotalCost
               }
               , new Object[] {
               T000950_A16CustomerName, T000950_A17CustomerDirectionDestination, T000950_A1CountryId
               }
               , new Object[] {
               T000951_A2CountryName
               }
               , new Object[] {
               T000952_A31ShoppingCartId
               }
               , new Object[] {
               T000953_A31ShoppingCartId, T000953_A11ProductName, T000953_A12ProductDescription, T000953_A13ProductPrice, T000953_A5CategoryName, T000953_A37ProductQuantity, T000953_A10ProductId, T000953_A4CategoryId
               }
               , new Object[] {
               T000954_A11ProductName, T000954_A12ProductDescription, T000954_A13ProductPrice, T000954_A4CategoryId
               }
               , new Object[] {
               T000955_A5CategoryName
               }
               , new Object[] {
               T000956_A31ShoppingCartId, T000956_A10ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000960_A11ProductName, T000960_A12ProductDescription, T000960_A13ProductPrice, T000960_A4CategoryId
               }
               , new Object[] {
               T000961_A5CategoryName
               }
               , new Object[] {
               T000962_A31ShoppingCartId, T000962_A10ProductId
               }
               , new Object[] {
               T000963_A5CategoryName, T000963_A4CategoryId
               }
               , new Object[] {
               T000964_A5CategoryName, T000964_A4CategoryId
               }
            }
         );
         AV16Pgmname = "ShoppingCart";
         Z34ShoppingCartDate = DateTime.MinValue;
         A34ShoppingCartDate = DateTime.MinValue;
         i34ShoppingCartDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nIsMod_10 ;
      private short wcpOAV7ShoppingCartId ;
      private short Z31ShoppingCartId ;
      private short Z15CustomerId ;
      private short N15CustomerId ;
      private short Z10ProductId ;
      private short nRcdDeleted_10 ;
      private short nRcdExists_10 ;
      private short GxWebError ;
      private short A4CategoryId ;
      private short A31ShoppingCartId ;
      private short A15CustomerId ;
      private short A1CountryId ;
      private short A10ProductId ;
      private short AV7ShoppingCartId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount10 ;
      private short RcdFound10 ;
      private short nBlankRcdUsr10 ;
      private short AV11Insert_CustomerId ;
      private short Gx_BScreen ;
      private short RcdFound9 ;
      private short Z1CountryId ;
      private short Z4CategoryId ;
      private short nIsDirty_10 ;
      private short subGridshoppingcart_product_Backcolorstyle ;
      private short subGridshoppingcart_product_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridshoppingcart_product_Allowselection ;
      private short subGridshoppingcart_product_Allowhovering ;
      private short subGridshoppingcart_product_Allowcollapsing ;
      private short subGridshoppingcart_product_Collapsed ;
      private short X4CategoryId ;
      private int nRC_GXsfl_83 ;
      private int nGXsfl_83_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtShoppingCartId_Enabled ;
      private int edtShoppingCartDate_Enabled ;
      private int edtCustomerId_Enabled ;
      private int imgprompt_15_Visible ;
      private int edtCustomerName_Enabled ;
      private int edtCustomerDirectionDestination_Enabled ;
      private int edtCountryId_Enabled ;
      private int edtCountryName_Enabled ;
      private int edtShoppingCartTotalCost_Enabled ;
      private int edtShoppingCartDeliveryDate_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtProductId_Enabled ;
      private int edtProductName_Enabled ;
      private int edtProductDescription_Enabled ;
      private int edtProductPrice_Enabled ;
      private int edtCategoryId_Enabled ;
      private int edtCategoryName_Enabled ;
      private int edtProductFinalPrice_Enabled ;
      private int edtProductQuantity_Enabled ;
      private int edtProductTotalCost_Enabled ;
      private int fRowAdded ;
      private int AV17GXV1 ;
      private int subGridshoppingcart_product_Backcolor ;
      private int subGridshoppingcart_product_Allbackcolor ;
      private int imgprompt_10_Visible ;
      private int defedtProductId_Enabled ;
      private int idxLst ;
      private int subGridshoppingcart_product_Selectedindex ;
      private int subGridshoppingcart_product_Selectioncolor ;
      private int subGridshoppingcart_product_Hoveringcolor ;
      private long Z37ProductQuantity ;
      private long GRIDSHOPPINGCART_PRODUCT_nFirstRecordOnPage ;
      private long A37ProductQuantity ;
      private decimal O33ShoppingCartTotalCost ;
      private decimal O36ProductTotalCost ;
      private decimal A13ProductPrice ;
      private decimal A33ShoppingCartTotalCost ;
      private decimal B33ShoppingCartTotalCost ;
      private decimal s33ShoppingCartTotalCost ;
      private decimal A39ProductFinalPrice ;
      private decimal A36ProductTotalCost ;
      private decimal T36ProductTotalCost ;
      private decimal Z33ShoppingCartTotalCost ;
      private decimal Z13ProductPrice ;
      private decimal Z39ProductFinalPrice ;
      private string sPrefix ;
      private string sGXsfl_83_idx="0001" ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtShoppingCartDate_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtShoppingCartId_Internalname ;
      private string edtShoppingCartId_Jsonclick ;
      private string edtShoppingCartDate_Jsonclick ;
      private string edtCustomerId_Internalname ;
      private string edtCustomerId_Jsonclick ;
      private string imgprompt_15_gximage ;
      private string sImgUrl ;
      private string imgprompt_15_Internalname ;
      private string imgprompt_15_Link ;
      private string edtCustomerName_Internalname ;
      private string edtCustomerName_Jsonclick ;
      private string edtCustomerDirectionDestination_Internalname ;
      private string edtCustomerDirectionDestination_Jsonclick ;
      private string edtCountryId_Internalname ;
      private string edtCountryId_Jsonclick ;
      private string edtCountryName_Internalname ;
      private string edtCountryName_Jsonclick ;
      private string edtShoppingCartTotalCost_Internalname ;
      private string edtShoppingCartTotalCost_Jsonclick ;
      private string edtShoppingCartDeliveryDate_Internalname ;
      private string edtShoppingCartDeliveryDate_Jsonclick ;
      private string divProducttable_Internalname ;
      private string lblTitleproduct_Internalname ;
      private string lblTitleproduct_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode10 ;
      private string edtProductId_Internalname ;
      private string edtProductName_Internalname ;
      private string edtProductDescription_Internalname ;
      private string edtProductPrice_Internalname ;
      private string edtCategoryId_Internalname ;
      private string edtCategoryName_Internalname ;
      private string edtProductFinalPrice_Internalname ;
      private string edtProductQuantity_Internalname ;
      private string edtProductTotalCost_Internalname ;
      private string sStyleString ;
      private string subGridshoppingcart_product_Internalname ;
      private string AV16Pgmname ;
      private string hsh ;
      private string sMode9 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string imgprompt_10_Internalname ;
      private string sGXsfl_83_fel_idx="0001" ;
      private string subGridshoppingcart_product_Class ;
      private string subGridshoppingcart_product_Linesclass ;
      private string imgprompt_10_Link ;
      private string ROClassString ;
      private string edtProductId_Jsonclick ;
      private string imgprompt_10_gximage ;
      private string edtProductName_Jsonclick ;
      private string edtProductDescription_Jsonclick ;
      private string edtProductPrice_Jsonclick ;
      private string edtCategoryId_Jsonclick ;
      private string edtCategoryName_Jsonclick ;
      private string edtProductFinalPrice_Jsonclick ;
      private string edtProductQuantity_Jsonclick ;
      private string edtProductTotalCost_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridshoppingcart_product_Header ;
      private DateTime Z34ShoppingCartDate ;
      private DateTime A34ShoppingCartDate ;
      private DateTime A35ShoppingCartDeliveryDate ;
      private DateTime Gx_date ;
      private DateTime i34ShoppingCartDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n33ShoppingCartTotalCost ;
      private bool bGXsfl_83_Refreshing=false ;
      private bool returnInSub ;
      private bool n39ProductFinalPrice ;
      private bool n36ProductTotalCost ;
      private bool Gx_first ;
      private string A16CustomerName ;
      private string A17CustomerDirectionDestination ;
      private string A2CountryName ;
      private string A11ProductName ;
      private string A12ProductDescription ;
      private string A5CategoryName ;
      private string Z16CustomerName ;
      private string Z17CustomerDirectionDestination ;
      private string Z2CountryName ;
      private string Z11ProductName ;
      private string Z12ProductDescription ;
      private string Z5CategoryName ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridshoppingcart_productContainer ;
      private GXWebRow Gridshoppingcart_productRow ;
      private GXWebColumn Gridshoppingcart_productColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private decimal[] T000917_A33ShoppingCartTotalCost ;
      private bool[] T000917_n33ShoppingCartTotalCost ;
      private string[] T00098_A16CustomerName ;
      private string[] T00098_A17CustomerDirectionDestination ;
      private short[] T00098_A1CountryId ;
      private string[] T00099_A2CountryName ;
      private short[] T000925_A31ShoppingCartId ;
      private DateTime[] T000925_A34ShoppingCartDate ;
      private string[] T000925_A16CustomerName ;
      private string[] T000925_A17CustomerDirectionDestination ;
      private string[] T000925_A2CountryName ;
      private short[] T000925_A15CustomerId ;
      private short[] T000925_A1CountryId ;
      private decimal[] T000925_A33ShoppingCartTotalCost ;
      private bool[] T000925_n33ShoppingCartTotalCost ;
      private decimal[] T000933_A33ShoppingCartTotalCost ;
      private bool[] T000933_n33ShoppingCartTotalCost ;
      private string[] T000934_A16CustomerName ;
      private string[] T000934_A17CustomerDirectionDestination ;
      private short[] T000934_A1CountryId ;
      private string[] T000935_A2CountryName ;
      private short[] T000936_A31ShoppingCartId ;
      private short[] T00097_A31ShoppingCartId ;
      private DateTime[] T00097_A34ShoppingCartDate ;
      private short[] T00097_A15CustomerId ;
      private short[] T000937_A31ShoppingCartId ;
      private short[] T000938_A31ShoppingCartId ;
      private short[] T00096_A31ShoppingCartId ;
      private DateTime[] T00096_A34ShoppingCartDate ;
      private short[] T00096_A15CustomerId ;
      private short[] T000939_A31ShoppingCartId ;
      private decimal[] T000949_A33ShoppingCartTotalCost ;
      private bool[] T000949_n33ShoppingCartTotalCost ;
      private string[] T000950_A16CustomerName ;
      private string[] T000950_A17CustomerDirectionDestination ;
      private short[] T000950_A1CountryId ;
      private string[] T000951_A2CountryName ;
      private short[] T000952_A31ShoppingCartId ;
      private short[] T000953_A31ShoppingCartId ;
      private string[] T000953_A11ProductName ;
      private string[] T000953_A12ProductDescription ;
      private decimal[] T000953_A13ProductPrice ;
      private string[] T000953_A5CategoryName ;
      private long[] T000953_A37ProductQuantity ;
      private short[] T000953_A10ProductId ;
      private short[] T000953_A4CategoryId ;
      private string[] T00094_A11ProductName ;
      private string[] T00094_A12ProductDescription ;
      private decimal[] T00094_A13ProductPrice ;
      private short[] T00094_A4CategoryId ;
      private string[] T00095_A5CategoryName ;
      private string[] T000954_A11ProductName ;
      private string[] T000954_A12ProductDescription ;
      private decimal[] T000954_A13ProductPrice ;
      private short[] T000954_A4CategoryId ;
      private string[] T000955_A5CategoryName ;
      private short[] T000956_A31ShoppingCartId ;
      private short[] T000956_A10ProductId ;
      private short[] T00093_A31ShoppingCartId ;
      private long[] T00093_A37ProductQuantity ;
      private short[] T00093_A10ProductId ;
      private short[] T00092_A31ShoppingCartId ;
      private long[] T00092_A37ProductQuantity ;
      private short[] T00092_A10ProductId ;
      private string[] T000960_A11ProductName ;
      private string[] T000960_A12ProductDescription ;
      private decimal[] T000960_A13ProductPrice ;
      private short[] T000960_A4CategoryId ;
      private string[] T000961_A5CategoryName ;
      private short[] T000962_A31ShoppingCartId ;
      private short[] T000962_A10ProductId ;
      private string[] T000963_A5CategoryName ;
      private short[] T000963_A4CategoryId ;
      private string[] T000964_A5CategoryName ;
      private short[] T000964_A4CategoryId ;
   }

   public class shoppingcart__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new UpdateCursor(def[27])
         ,new UpdateCursor(def[28])
         ,new UpdateCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00092;
          prmT00092 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00093;
          prmT00093 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00094;
          prmT00094 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00095;
          prmT00095 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT00096;
          prmT00096 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT00097;
          prmT00097 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT00098;
          prmT00098 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmT00099;
          prmT00099 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000917;
          prmT000917 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000925;
          prmT000925 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          string cmdBufferT000925;
          cmdBufferT000925=" SELECT TM1.[ShoppingCartId], TM1.[ShoppingCartDate], T3.[CustomerName], T3.[CustomerDirectionDestination], T4.[CountryName], TM1.[CustomerId], T3.[CountryId], COALESCE( T2.[ShoppingCartTotalCost], 0) AS ShoppingCartTotalCost FROM ((([ShoppingCart] TM1 LEFT JOIN (SELECT SUM(COALESCE( T6.[ProductTotalCost], 0)) AS ShoppingCartTotalCost, T5.[ShoppingCartId] FROM ([ShoppingCartProducts] T5 INNER JOIN (SELECT ( COALESCE( T8.[ProductFinalPrice], 0)) * CAST(T7.[ProductQuantity] AS decimal( 28, 10)) AS ProductTotalCost, T7.[ShoppingCartId], T7.[ProductId] FROM ([ShoppingCartProducts] T7 INNER JOIN (SELECT CASE  WHEN T12.[CategoryId] = COALESCE( T11.[CategoryId], 0) THEN T12.[ProductPrice] + ( T12.[ProductPrice] * CAST(0.05 AS decimal( 28, 10))) WHEN T12.[CategoryId] = COALESCE( T10.[CategoryId], 0) THEN T12.[ProductPrice] - ( T12.[ProductPrice] * CAST(0.1 AS decimal( 28, 10))) ELSE T12.[ProductPrice] END AS ProductFinalPrice, T9.[ShoppingCartId], T9.[ProductId] FROM ((([ShoppingCartProducts] T9 INNER JOIN [Product] T12 ON T12.[ProductId] = T9.[ProductId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Entretenimiento' ) T10 ON T10.[CategoryId] = T12.[CategoryId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Joyeria' ) T11 ON T11.[CategoryId] = T12.[CategoryId]) ) T8 ON T8.[ShoppingCartId] = T7.[ShoppingCartId] AND T8.[ProductId] = T7.[ProductId]) ) T6 ON T6.[ShoppingCartId] = T5.[ShoppingCartId] AND T6.[ProductId] = T5.[ProductId]) GROUP BY T5.[ShoppingCartId] ) T2 ON T2.[ShoppingCartId] = TM1.[ShoppingCartId]) INNER JOIN [Customer] T3 ON T3.[CustomerId] = TM1.[CustomerId]) INNER JOIN [Country] T4 ON T4.[CountryId] = T3.[CountryId]) WHERE TM1.[ShoppingCartId] = @ShoppingCartId "
          + " ORDER BY TM1.[ShoppingCartId]  OPTION (FAST 100)" ;
          Object[] prmT000933;
          prmT000933 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000934;
          prmT000934 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmT000935;
          prmT000935 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000936;
          prmT000936 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000937;
          prmT000937 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000938;
          prmT000938 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000939;
          prmT000939 = new Object[] {
          new ParDef("@ShoppingCartDate",GXType.Date,8,0) ,
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmT000940;
          prmT000940 = new Object[] {
          new ParDef("@ShoppingCartDate",GXType.Date,8,0) ,
          new ParDef("@CustomerId",GXType.Int16,4,0) ,
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000941;
          prmT000941 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000949;
          prmT000949 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000950;
          prmT000950 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmT000951;
          prmT000951 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000952;
          prmT000952 = new Object[] {
          };
          Object[] prmT000953;
          prmT000953 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000954;
          prmT000954 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000955;
          prmT000955 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT000956;
          prmT000956 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000957;
          prmT000957 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductQuantity",GXType.Decimal,10,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000958;
          prmT000958 = new Object[] {
          new ParDef("@ProductQuantity",GXType.Decimal,10,0) ,
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000959;
          prmT000959 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000960;
          prmT000960 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000961;
          prmT000961 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT000962;
          prmT000962 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000963;
          prmT000963 = new Object[] {
          };
          Object[] prmT000964;
          prmT000964 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00092", "SELECT [ShoppingCartId], [ProductQuantity], [ProductId] FROM [ShoppingCartProducts] WITH (UPDLOCK) WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00093", "SELECT [ShoppingCartId], [ProductQuantity], [ProductId] FROM [ShoppingCartProducts] WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00094", "SELECT [ProductName], [ProductDescription], [ProductPrice], [CategoryId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00095", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00096", "SELECT [ShoppingCartId], [ShoppingCartDate], [CustomerId] FROM [ShoppingCart] WITH (UPDLOCK) WHERE [ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00097", "SELECT [ShoppingCartId], [ShoppingCartDate], [CustomerId] FROM [ShoppingCart] WHERE [ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00098", "SELECT [CustomerName], [CustomerDirectionDestination], [CountryId] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00098,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00099", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000917", "SELECT COALESCE( T1.[ShoppingCartTotalCost], 0) AS ShoppingCartTotalCost FROM (SELECT SUM(COALESCE( T3.[ProductTotalCost], 0)) AS ShoppingCartTotalCost, T2.[ShoppingCartId] FROM ([ShoppingCartProducts] T2 WITH (UPDLOCK) INNER JOIN (SELECT ( COALESCE( T5.[ProductFinalPrice], 0)) * CAST(T4.[ProductQuantity] AS decimal( 28, 10)) AS ProductTotalCost, T4.[ShoppingCartId], T4.[ProductId] FROM ([ShoppingCartProducts] T4 WITH (UPDLOCK) INNER JOIN (SELECT CASE  WHEN T9.[CategoryId] = COALESCE( T8.[CategoryId], 0) THEN T9.[ProductPrice] + ( T9.[ProductPrice] * CAST(0.05 AS decimal( 28, 10))) WHEN T9.[CategoryId] = COALESCE( T7.[CategoryId], 0) THEN T9.[ProductPrice] - ( T9.[ProductPrice] * CAST(0.1 AS decimal( 28, 10))) ELSE T9.[ProductPrice] END AS ProductFinalPrice, T6.[ShoppingCartId], T6.[ProductId] FROM ((([ShoppingCartProducts] T6 WITH (UPDLOCK) INNER JOIN [Product] T9 ON T9.[ProductId] = T6.[ProductId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Entretenimiento' ) T7 ON T7.[CategoryId] = T9.[CategoryId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Joyeria' ) T8 ON T8.[CategoryId] = T9.[CategoryId]) ) T5 ON T5.[ShoppingCartId] = T4.[ShoppingCartId] AND T5.[ProductId] = T4.[ProductId]) ) T3 ON T3.[ShoppingCartId] = T2.[ShoppingCartId] AND T3.[ProductId] = T2.[ProductId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000917,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000925", cmdBufferT000925,true, GxErrorMask.GX_NOMASK, false, this,prmT000925,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000933", "SELECT COALESCE( T1.[ShoppingCartTotalCost], 0) AS ShoppingCartTotalCost FROM (SELECT SUM(COALESCE( T3.[ProductTotalCost], 0)) AS ShoppingCartTotalCost, T2.[ShoppingCartId] FROM ([ShoppingCartProducts] T2 WITH (UPDLOCK) INNER JOIN (SELECT ( COALESCE( T5.[ProductFinalPrice], 0)) * CAST(T4.[ProductQuantity] AS decimal( 28, 10)) AS ProductTotalCost, T4.[ShoppingCartId], T4.[ProductId] FROM ([ShoppingCartProducts] T4 WITH (UPDLOCK) INNER JOIN (SELECT CASE  WHEN T9.[CategoryId] = COALESCE( T8.[CategoryId], 0) THEN T9.[ProductPrice] + ( T9.[ProductPrice] * CAST(0.05 AS decimal( 28, 10))) WHEN T9.[CategoryId] = COALESCE( T7.[CategoryId], 0) THEN T9.[ProductPrice] - ( T9.[ProductPrice] * CAST(0.1 AS decimal( 28, 10))) ELSE T9.[ProductPrice] END AS ProductFinalPrice, T6.[ShoppingCartId], T6.[ProductId] FROM ((([ShoppingCartProducts] T6 WITH (UPDLOCK) INNER JOIN [Product] T9 ON T9.[ProductId] = T6.[ProductId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Entretenimiento' ) T7 ON T7.[CategoryId] = T9.[CategoryId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Joyeria' ) T8 ON T8.[CategoryId] = T9.[CategoryId]) ) T5 ON T5.[ShoppingCartId] = T4.[ShoppingCartId] AND T5.[ProductId] = T4.[ProductId]) ) T3 ON T3.[ShoppingCartId] = T2.[ShoppingCartId] AND T3.[ProductId] = T2.[ProductId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000933,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000934", "SELECT [CustomerName], [CustomerDirectionDestination], [CountryId] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000934,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000935", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000935,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000936", "SELECT [ShoppingCartId] FROM [ShoppingCart] WHERE [ShoppingCartId] = @ShoppingCartId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000936,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000937", "SELECT TOP 1 [ShoppingCartId] FROM [ShoppingCart] WHERE ( [ShoppingCartId] > @ShoppingCartId) ORDER BY [ShoppingCartId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000937,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000938", "SELECT TOP 1 [ShoppingCartId] FROM [ShoppingCart] WHERE ( [ShoppingCartId] < @ShoppingCartId) ORDER BY [ShoppingCartId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000938,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000939", "INSERT INTO [ShoppingCart]([ShoppingCartDate], [CustomerId]) VALUES(@ShoppingCartDate, @CustomerId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000939,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000940", "UPDATE [ShoppingCart] SET [ShoppingCartDate]=@ShoppingCartDate, [CustomerId]=@CustomerId  WHERE [ShoppingCartId] = @ShoppingCartId", GxErrorMask.GX_NOMASK,prmT000940)
             ,new CursorDef("T000941", "DELETE FROM [ShoppingCart]  WHERE [ShoppingCartId] = @ShoppingCartId", GxErrorMask.GX_NOMASK,prmT000941)
             ,new CursorDef("T000949", "SELECT COALESCE( T1.[ShoppingCartTotalCost], 0) AS ShoppingCartTotalCost FROM (SELECT SUM(COALESCE( T3.[ProductTotalCost], 0)) AS ShoppingCartTotalCost, T2.[ShoppingCartId] FROM ([ShoppingCartProducts] T2 WITH (UPDLOCK) INNER JOIN (SELECT ( COALESCE( T5.[ProductFinalPrice], 0)) * CAST(T4.[ProductQuantity] AS decimal( 28, 10)) AS ProductTotalCost, T4.[ShoppingCartId], T4.[ProductId] FROM ([ShoppingCartProducts] T4 WITH (UPDLOCK) INNER JOIN (SELECT CASE  WHEN T9.[CategoryId] = COALESCE( T8.[CategoryId], 0) THEN T9.[ProductPrice] + ( T9.[ProductPrice] * CAST(0.05 AS decimal( 28, 10))) WHEN T9.[CategoryId] = COALESCE( T7.[CategoryId], 0) THEN T9.[ProductPrice] - ( T9.[ProductPrice] * CAST(0.1 AS decimal( 28, 10))) ELSE T9.[ProductPrice] END AS ProductFinalPrice, T6.[ShoppingCartId], T6.[ProductId] FROM ((([ShoppingCartProducts] T6 WITH (UPDLOCK) INNER JOIN [Product] T9 ON T9.[ProductId] = T6.[ProductId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Entretenimiento' ) T7 ON T7.[CategoryId] = T9.[CategoryId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Joyeria' ) T8 ON T8.[CategoryId] = T9.[CategoryId]) ) T5 ON T5.[ShoppingCartId] = T4.[ShoppingCartId] AND T5.[ProductId] = T4.[ProductId]) ) T3 ON T3.[ShoppingCartId] = T2.[ShoppingCartId] AND T3.[ProductId] = T2.[ProductId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000949,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000950", "SELECT [CustomerName], [CustomerDirectionDestination], [CountryId] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000950,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000951", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000951,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000952", "SELECT [ShoppingCartId] FROM [ShoppingCart] ORDER BY [ShoppingCartId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000952,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000953", "SELECT T1.[ShoppingCartId], T2.[ProductName], T2.[ProductDescription], T2.[ProductPrice], T3.[CategoryName], T1.[ProductQuantity], T1.[ProductId], T2.[CategoryId] FROM (([ShoppingCartProducts] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) INNER JOIN [Category] T3 ON T3.[CategoryId] = T2.[CategoryId]) WHERE T1.[ShoppingCartId] = @ShoppingCartId and T1.[ProductId] = @ProductId ORDER BY T1.[ShoppingCartId], T1.[ProductId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000953,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000954", "SELECT [ProductName], [ProductDescription], [ProductPrice], [CategoryId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000954,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000955", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000955,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000956", "SELECT [ShoppingCartId], [ProductId] FROM [ShoppingCartProducts] WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000956,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000957", "INSERT INTO [ShoppingCartProducts]([ShoppingCartId], [ProductQuantity], [ProductId]) VALUES(@ShoppingCartId, @ProductQuantity, @ProductId)", GxErrorMask.GX_NOMASK,prmT000957)
             ,new CursorDef("T000958", "UPDATE [ShoppingCartProducts] SET [ProductQuantity]=@ProductQuantity  WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000958)
             ,new CursorDef("T000959", "DELETE FROM [ShoppingCartProducts]  WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000959)
             ,new CursorDef("T000960", "SELECT [ProductName], [ProductDescription], [ProductPrice], [CategoryId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000960,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000961", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000961,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000962", "SELECT [ShoppingCartId], [ProductId] FROM [ShoppingCartProducts] WHERE [ShoppingCartId] = @ShoppingCartId ORDER BY [ShoppingCartId], [ProductId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000962,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000963", "SELECT [CategoryName], [CategoryId] FROM [Category] WHERE [CategoryName] = 'Entretenimiento' ",true, GxErrorMask.GX_NOMASK, false, this,prmT000963,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000964", "SELECT [CategoryName], [CategoryId] FROM [Category] WHERE [CategoryName] = 'Joyeria' ",true, GxErrorMask.GX_NOMASK, false, this,prmT000964,0, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 25 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 26 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 31 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 32 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 33 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 34 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
