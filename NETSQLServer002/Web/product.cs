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
   public class product : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A6SellerId = (short)(Math.Round(NumberUtil.Val( GetPar( "SellerId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A6SellerId", StringUtil.LTrimStr( (decimal)(A6SellerId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A6SellerId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A41ProductCountryId = (short)(Math.Round(NumberUtil.Val( GetPar( "ProductCountryId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A41ProductCountryId", StringUtil.LTrimStr( (decimal)(A41ProductCountryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A41ProductCountryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A24SupplierId = (short)(Math.Round(NumberUtil.Val( GetPar( "SupplierId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A24SupplierId", StringUtil.LTrimStr( (decimal)(A24SupplierId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A24SupplierId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A4CategoryId = (short)(Math.Round(NumberUtil.Val( GetPar( "CategoryId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A4CategoryId", StringUtil.LTrimStr( (decimal)(A4CategoryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A4CategoryId) ;
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
               AV7ProductId = (short)(Math.Round(NumberUtil.Val( GetPar( "ProductId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7ProductId", StringUtil.LTrimStr( (decimal)(AV7ProductId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProductId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", "Product", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProductName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("ObligatorioShop", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public product( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public product( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_ProductId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ProductId = aP1_ProductId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Product", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Product.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Product.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductId), 4, 0, ",", "")), StringUtil.LTrim( ((edtProductId_Enabled!=0) ? context.localUtil.Format( (decimal)(A10ProductId), "ZZZ9") : context.localUtil.Format( (decimal)(A10ProductId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductName_Internalname, A11ProductName, StringUtil.RTrim( context.localUtil.Format( A11ProductName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductDescription_Internalname, "Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProductDescription_Internalname, A12ProductDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtProductDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductPrice_Internalname, "Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A13ProductPrice, 18, 2, ",", "")), StringUtil.LTrim( ((edtProductPrice_Enabled!=0) ? context.localUtil.Format( A13ProductPrice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A13ProductPrice, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductPrice_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProductImage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Image", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A14ProductImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage)) ? A40000ProductImage_GXI : context.PathToRelativeUrl( A14ProductImage));
         GxWebStd.gx_bitmap( context, imgProductImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProductImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", "", "", 0, A14ProductImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         AssignProp("", false, imgProductImage_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage)) ? A40000ProductImage_GXI : context.PathToRelativeUrl( A14ProductImage)), true);
         AssignProp("", false, imgProductImage_Internalname, "IsBlob", StringUtil.BoolToStr( A14ProductImage_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSellerId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSellerId_Internalname, "Seller Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSellerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6SellerId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A6SellerId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSellerId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSellerId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Product.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_6_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_6_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_6_Internalname, sImgUrl, imgprompt_6_Link, "", "", context.GetTheme( ), imgprompt_6_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSellerName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSellerName_Internalname, "Seller Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSellerName_Internalname, A7SellerName, StringUtil.RTrim( context.localUtil.Format( A7SellerName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSellerName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSellerName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductCountryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductCountryId_Internalname, "Country Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41ProductCountryId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A41ProductCountryId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductCountryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductCountryId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Product.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_41_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_41_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_41_Internalname, sImgUrl, imgprompt_41_Link, "", "", context.GetTheme( ), imgprompt_41_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductCountryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductCountryName_Internalname, "Country Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductCountryName_Internalname, A42ProductCountryName, StringUtil.RTrim( context.localUtil.Format( A42ProductCountryName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductCountryName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProductCountryFlag_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Country Flag", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A43ProductCountryFlag_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A43ProductCountryFlag))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001ProductCountryFlag_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A43ProductCountryFlag)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A43ProductCountryFlag)) ? A40001ProductCountryFlag_GXI : context.PathToRelativeUrl( A43ProductCountryFlag));
         GxWebStd.gx_bitmap( context, imgProductCountryFlag_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProductCountryFlag_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", "", "", 0, A43ProductCountryFlag_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         AssignProp("", false, imgProductCountryFlag_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A43ProductCountryFlag)) ? A40001ProductCountryFlag_GXI : context.PathToRelativeUrl( A43ProductCountryFlag)), true);
         AssignProp("", false, imgProductCountryFlag_Internalname, "IsBlob", StringUtil.BoolToStr( A43ProductCountryFlag_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierId_Internalname, "Supplier Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24SupplierId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A24SupplierId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Product.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_24_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_24_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_24_Internalname, sImgUrl, imgprompt_24_Link, "", "", context.GetTheme( ), imgprompt_24_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierName_Internalname, "Supplier Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierName_Internalname, A25SupplierName, StringUtil.RTrim( context.localUtil.Format( A25SupplierName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCategoryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoryId_Internalname, "Category Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCategoryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoryId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A4CategoryId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoryId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Product.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCategoryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoryName_Internalname, "Category Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCategoryName_Internalname, A5CategoryName, StringUtil.RTrim( context.localUtil.Format( A5CategoryName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoryName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Product.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         E11042 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z10ProductId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z10ProductId"), ",", "."), 18, MidpointRounding.ToEven));
               Z11ProductName = cgiGet( "Z11ProductName");
               Z12ProductDescription = cgiGet( "Z12ProductDescription");
               Z13ProductPrice = context.localUtil.CToN( cgiGet( "Z13ProductPrice"), ",", ".");
               Z6SellerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z6SellerId"), ",", "."), 18, MidpointRounding.ToEven));
               Z24SupplierId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z24SupplierId"), ",", "."), 18, MidpointRounding.ToEven));
               Z4CategoryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z4CategoryId"), ",", "."), 18, MidpointRounding.ToEven));
               Z41ProductCountryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z41ProductCountryId"), ",", "."), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N6SellerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N6SellerId"), ",", "."), 18, MidpointRounding.ToEven));
               N41ProductCountryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N41ProductCountryId"), ",", "."), 18, MidpointRounding.ToEven));
               N24SupplierId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N24SupplierId"), ",", "."), 18, MidpointRounding.ToEven));
               N4CategoryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N4CategoryId"), ",", "."), 18, MidpointRounding.ToEven));
               AV7ProductId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vPRODUCTID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_SellerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SELLERID"), ",", "."), 18, MidpointRounding.ToEven));
               AV15Insert_ProductCountryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PRODUCTCOUNTRYID"), ",", "."), 18, MidpointRounding.ToEven));
               AV12Insert_SupplierId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SUPPLIERID"), ",", "."), 18, MidpointRounding.ToEven));
               AV13Insert_CategoryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CATEGORYID"), ",", "."), 18, MidpointRounding.ToEven));
               A40000ProductImage_GXI = cgiGet( "PRODUCTIMAGE_GXI");
               A40001ProductCountryFlag_GXI = cgiGet( "PRODUCTCOUNTRYFLAG_GXI");
               AV16Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A10ProductId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A10ProductId", StringUtil.LTrimStr( (decimal)(A10ProductId), 4, 0));
               A11ProductName = cgiGet( edtProductName_Internalname);
               AssignAttri("", false, "A11ProductName", A11ProductName);
               A12ProductDescription = cgiGet( edtProductDescription_Internalname);
               AssignAttri("", false, "A12ProductDescription", A12ProductDescription);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTPRICE");
                  AnyError = 1;
                  GX_FocusControl = edtProductPrice_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A13ProductPrice = 0;
                  AssignAttri("", false, "A13ProductPrice", StringUtil.LTrimStr( A13ProductPrice, 18, 2));
               }
               else
               {
                  A13ProductPrice = context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ",", ".");
                  AssignAttri("", false, "A13ProductPrice", StringUtil.LTrimStr( A13ProductPrice, 18, 2));
               }
               A14ProductImage = cgiGet( imgProductImage_Internalname);
               AssignAttri("", false, "A14ProductImage", A14ProductImage);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSellerId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSellerId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SELLERID");
                  AnyError = 1;
                  GX_FocusControl = edtSellerId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A6SellerId = 0;
                  AssignAttri("", false, "A6SellerId", StringUtil.LTrimStr( (decimal)(A6SellerId), 4, 0));
               }
               else
               {
                  A6SellerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSellerId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A6SellerId", StringUtil.LTrimStr( (decimal)(A6SellerId), 4, 0));
               }
               A7SellerName = cgiGet( edtSellerName_Internalname);
               AssignAttri("", false, "A7SellerName", A7SellerName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductCountryId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductCountryId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTCOUNTRYID");
                  AnyError = 1;
                  GX_FocusControl = edtProductCountryId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A41ProductCountryId = 0;
                  AssignAttri("", false, "A41ProductCountryId", StringUtil.LTrimStr( (decimal)(A41ProductCountryId), 4, 0));
               }
               else
               {
                  A41ProductCountryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductCountryId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A41ProductCountryId", StringUtil.LTrimStr( (decimal)(A41ProductCountryId), 4, 0));
               }
               A42ProductCountryName = cgiGet( edtProductCountryName_Internalname);
               AssignAttri("", false, "A42ProductCountryName", A42ProductCountryName);
               A43ProductCountryFlag = cgiGet( imgProductCountryFlag_Internalname);
               AssignAttri("", false, "A43ProductCountryFlag", A43ProductCountryFlag);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSupplierId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSupplierId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SUPPLIERID");
                  AnyError = 1;
                  GX_FocusControl = edtSupplierId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A24SupplierId = 0;
                  AssignAttri("", false, "A24SupplierId", StringUtil.LTrimStr( (decimal)(A24SupplierId), 4, 0));
               }
               else
               {
                  A24SupplierId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSupplierId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A24SupplierId", StringUtil.LTrimStr( (decimal)(A24SupplierId), 4, 0));
               }
               A25SupplierName = cgiGet( edtSupplierName_Internalname);
               AssignAttri("", false, "A25SupplierName", A25SupplierName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CATEGORYID");
                  AnyError = 1;
                  GX_FocusControl = edtCategoryId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A4CategoryId = 0;
                  AssignAttri("", false, "A4CategoryId", StringUtil.LTrimStr( (decimal)(A4CategoryId), 4, 0));
               }
               else
               {
                  A4CategoryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A4CategoryId", StringUtil.LTrimStr( (decimal)(A4CategoryId), 4, 0));
               }
               A5CategoryName = cgiGet( edtCategoryName_Internalname);
               AssignAttri("", false, "A5CategoryName", A5CategoryName);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProductImage_Internalname, ref  A14ProductImage, ref  A40000ProductImage_GXI);
               getMultimediaValue(imgProductCountryFlag_Internalname, ref  A43ProductCountryFlag, ref  A40001ProductCountryFlag_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Product");
               A10ProductId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A10ProductId", StringUtil.LTrimStr( (decimal)(A10ProductId), 4, 0));
               forbiddenHiddens.Add("ProductId", context.localUtil.Format( (decimal)(A10ProductId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A10ProductId != Z10ProductId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("product:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A10ProductId = (short)(Math.Round(NumberUtil.Val( GetPar( "ProductId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A10ProductId", StringUtil.LTrimStr( (decimal)(A10ProductId), 4, 0));
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
                     sMode4 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode4;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound4 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_040( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PRODUCTID");
                        AnyError = 1;
                        GX_FocusControl = edtProductId_Internalname;
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
                           E11042 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12042 ();
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
            E12042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll044( ) ;
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
            DisableAttributes044( ) ;
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
               CloseExtendedTableCursors044( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption040( )
      {
      }

      protected void E11042( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV16Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_SellerId = 0;
         AssignAttri("", false, "AV11Insert_SellerId", StringUtil.LTrimStr( (decimal)(AV11Insert_SellerId), 4, 0));
         AV15Insert_ProductCountryId = 0;
         AssignAttri("", false, "AV15Insert_ProductCountryId", StringUtil.LTrimStr( (decimal)(AV15Insert_ProductCountryId), 4, 0));
         AV12Insert_SupplierId = 0;
         AssignAttri("", false, "AV12Insert_SupplierId", StringUtil.LTrimStr( (decimal)(AV12Insert_SupplierId), 4, 0));
         AV13Insert_CategoryId = 0;
         AssignAttri("", false, "AV13Insert_CategoryId", StringUtil.LTrimStr( (decimal)(AV13Insert_CategoryId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SellerId") == 0 )
               {
                  AV11Insert_SellerId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_SellerId", StringUtil.LTrimStr( (decimal)(AV11Insert_SellerId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ProductCountryId") == 0 )
               {
                  AV15Insert_ProductCountryId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15Insert_ProductCountryId", StringUtil.LTrimStr( (decimal)(AV15Insert_ProductCountryId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SupplierId") == 0 )
               {
                  AV12Insert_SupplierId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_SupplierId", StringUtil.LTrimStr( (decimal)(AV12Insert_SupplierId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CategoryId") == 0 )
               {
                  AV13Insert_CategoryId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_CategoryId", StringUtil.LTrimStr( (decimal)(AV13Insert_CategoryId), 4, 0));
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

      protected void E12042( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwproduct.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z11ProductName = T00043_A11ProductName[0];
               Z12ProductDescription = T00043_A12ProductDescription[0];
               Z13ProductPrice = T00043_A13ProductPrice[0];
               Z6SellerId = T00043_A6SellerId[0];
               Z24SupplierId = T00043_A24SupplierId[0];
               Z4CategoryId = T00043_A4CategoryId[0];
               Z41ProductCountryId = T00043_A41ProductCountryId[0];
            }
            else
            {
               Z11ProductName = A11ProductName;
               Z12ProductDescription = A12ProductDescription;
               Z13ProductPrice = A13ProductPrice;
               Z6SellerId = A6SellerId;
               Z24SupplierId = A24SupplierId;
               Z4CategoryId = A4CategoryId;
               Z41ProductCountryId = A41ProductCountryId;
            }
         }
         if ( GX_JID == -19 )
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
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), true);
         imgprompt_6_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SELLERID"+"'), id:'"+"SELLERID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_41_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTCOUNTRYID"+"'), id:'"+"PRODUCTCOUNTRYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_24_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0070.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SUPPLIERID"+"'), id:'"+"SUPPLIERID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CATEGORYID"+"'), id:'"+"CATEGORYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ProductId) )
         {
            A10ProductId = AV7ProductId;
            AssignAttri("", false, "A10ProductId", StringUtil.LTrimStr( (decimal)(A10ProductId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_SellerId) )
         {
            edtSellerId_Enabled = 0;
            AssignProp("", false, edtSellerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSellerId_Enabled), 5, 0), true);
         }
         else
         {
            edtSellerId_Enabled = 1;
            AssignProp("", false, edtSellerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSellerId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_ProductCountryId) )
         {
            edtProductCountryId_Enabled = 0;
            AssignProp("", false, edtProductCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCountryId_Enabled), 5, 0), true);
         }
         else
         {
            edtProductCountryId_Enabled = 1;
            AssignProp("", false, edtProductCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCountryId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SupplierId) )
         {
            edtSupplierId_Enabled = 0;
            AssignProp("", false, edtSupplierId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierId_Enabled), 5, 0), true);
         }
         else
         {
            edtSupplierId_Enabled = 1;
            AssignProp("", false, edtSupplierId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CategoryId) )
         {
            edtCategoryId_Enabled = 0;
            AssignProp("", false, edtCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryId_Enabled), 5, 0), true);
         }
         else
         {
            edtCategoryId_Enabled = 1;
            AssignProp("", false, edtCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CategoryId) )
         {
            A4CategoryId = AV13Insert_CategoryId;
            AssignAttri("", false, "A4CategoryId", StringUtil.LTrimStr( (decimal)(A4CategoryId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SupplierId) )
         {
            A24SupplierId = AV12Insert_SupplierId;
            AssignAttri("", false, "A24SupplierId", StringUtil.LTrimStr( (decimal)(A24SupplierId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_ProductCountryId) )
         {
            A41ProductCountryId = AV15Insert_ProductCountryId;
            AssignAttri("", false, "A41ProductCountryId", StringUtil.LTrimStr( (decimal)(A41ProductCountryId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_SellerId) )
         {
            A6SellerId = AV11Insert_SellerId;
            AssignAttri("", false, "A6SellerId", StringUtil.LTrimStr( (decimal)(A6SellerId), 4, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV16Pgmname = "Product";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T00046 */
            pr_default.execute(4, new Object[] {A4CategoryId});
            A5CategoryName = T00046_A5CategoryName[0];
            AssignAttri("", false, "A5CategoryName", A5CategoryName);
            pr_default.close(4);
            /* Using cursor T00045 */
            pr_default.execute(3, new Object[] {A24SupplierId});
            A25SupplierName = T00045_A25SupplierName[0];
            AssignAttri("", false, "A25SupplierName", A25SupplierName);
            pr_default.close(3);
            /* Using cursor T00047 */
            pr_default.execute(5, new Object[] {A41ProductCountryId});
            A42ProductCountryName = T00047_A42ProductCountryName[0];
            AssignAttri("", false, "A42ProductCountryName", A42ProductCountryName);
            A40001ProductCountryFlag_GXI = T00047_A40001ProductCountryFlag_GXI[0];
            n40001ProductCountryFlag_GXI = T00047_n40001ProductCountryFlag_GXI[0];
            AssignProp("", false, imgProductCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A43ProductCountryFlag)) ? A40001ProductCountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A43ProductCountryFlag))), true);
            AssignProp("", false, imgProductCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A43ProductCountryFlag), true);
            A43ProductCountryFlag = T00047_A43ProductCountryFlag[0];
            AssignAttri("", false, "A43ProductCountryFlag", A43ProductCountryFlag);
            AssignProp("", false, imgProductCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A43ProductCountryFlag)) ? A40001ProductCountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A43ProductCountryFlag))), true);
            AssignProp("", false, imgProductCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A43ProductCountryFlag), true);
            pr_default.close(5);
            /* Using cursor T00044 */
            pr_default.execute(2, new Object[] {A6SellerId});
            A7SellerName = T00044_A7SellerName[0];
            AssignAttri("", false, "A7SellerName", A7SellerName);
            pr_default.close(2);
         }
      }

      protected void Load044( )
      {
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {A10ProductId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound4 = 1;
            A11ProductName = T00048_A11ProductName[0];
            AssignAttri("", false, "A11ProductName", A11ProductName);
            A12ProductDescription = T00048_A12ProductDescription[0];
            AssignAttri("", false, "A12ProductDescription", A12ProductDescription);
            A13ProductPrice = T00048_A13ProductPrice[0];
            AssignAttri("", false, "A13ProductPrice", StringUtil.LTrimStr( A13ProductPrice, 18, 2));
            A40000ProductImage_GXI = T00048_A40000ProductImage_GXI[0];
            AssignProp("", false, imgProductImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage)) ? A40000ProductImage_GXI : context.convertURL( context.PathToRelativeUrl( A14ProductImage))), true);
            AssignProp("", false, imgProductImage_Internalname, "SrcSet", context.GetImageSrcSet( A14ProductImage), true);
            A7SellerName = T00048_A7SellerName[0];
            AssignAttri("", false, "A7SellerName", A7SellerName);
            A42ProductCountryName = T00048_A42ProductCountryName[0];
            AssignAttri("", false, "A42ProductCountryName", A42ProductCountryName);
            A40001ProductCountryFlag_GXI = T00048_A40001ProductCountryFlag_GXI[0];
            n40001ProductCountryFlag_GXI = T00048_n40001ProductCountryFlag_GXI[0];
            AssignProp("", false, imgProductCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A43ProductCountryFlag)) ? A40001ProductCountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A43ProductCountryFlag))), true);
            AssignProp("", false, imgProductCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A43ProductCountryFlag), true);
            A25SupplierName = T00048_A25SupplierName[0];
            AssignAttri("", false, "A25SupplierName", A25SupplierName);
            A5CategoryName = T00048_A5CategoryName[0];
            AssignAttri("", false, "A5CategoryName", A5CategoryName);
            A6SellerId = T00048_A6SellerId[0];
            AssignAttri("", false, "A6SellerId", StringUtil.LTrimStr( (decimal)(A6SellerId), 4, 0));
            A24SupplierId = T00048_A24SupplierId[0];
            AssignAttri("", false, "A24SupplierId", StringUtil.LTrimStr( (decimal)(A24SupplierId), 4, 0));
            A4CategoryId = T00048_A4CategoryId[0];
            AssignAttri("", false, "A4CategoryId", StringUtil.LTrimStr( (decimal)(A4CategoryId), 4, 0));
            A41ProductCountryId = T00048_A41ProductCountryId[0];
            AssignAttri("", false, "A41ProductCountryId", StringUtil.LTrimStr( (decimal)(A41ProductCountryId), 4, 0));
            A14ProductImage = T00048_A14ProductImage[0];
            AssignAttri("", false, "A14ProductImage", A14ProductImage);
            AssignProp("", false, imgProductImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage)) ? A40000ProductImage_GXI : context.convertURL( context.PathToRelativeUrl( A14ProductImage))), true);
            AssignProp("", false, imgProductImage_Internalname, "SrcSet", context.GetImageSrcSet( A14ProductImage), true);
            A43ProductCountryFlag = T00048_A43ProductCountryFlag[0];
            AssignAttri("", false, "A43ProductCountryFlag", A43ProductCountryFlag);
            AssignProp("", false, imgProductCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A43ProductCountryFlag)) ? A40001ProductCountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A43ProductCountryFlag))), true);
            AssignProp("", false, imgProductCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A43ProductCountryFlag), true);
            ZM044( -19) ;
         }
         pr_default.close(6);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
         AV16Pgmname = "Product";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
      }

      protected void CheckExtendedTable044( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV16Pgmname = "Product";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {A11ProductName, A10ProductId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Product Name"}), 1, "PRODUCTNAME");
            AnyError = 1;
            GX_FocusControl = edtProductName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(7);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A11ProductName)) )
         {
            GX_msglist.addItem("El nombre no puede estar vacio", 1, "PRODUCTNAME");
            AnyError = 1;
            GX_FocusControl = edtProductName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Convert.ToDecimal(0)==A13ProductPrice) )
         {
            GX_msglist.addItem("El precio no puede estar vacio", 1, "PRODUCTPRICE");
            AnyError = 1;
            GX_FocusControl = edtProductPrice_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {A6SellerId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Seller'.", "ForeignKeyNotFound", 1, "SELLERID");
            AnyError = 1;
            GX_FocusControl = edtSellerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A7SellerName = T00044_A7SellerName[0];
         AssignAttri("", false, "A7SellerName", A7SellerName);
         pr_default.close(2);
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A41ProductCountryId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Product Country'.", "ForeignKeyNotFound", 1, "PRODUCTCOUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtProductCountryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A42ProductCountryName = T00047_A42ProductCountryName[0];
         AssignAttri("", false, "A42ProductCountryName", A42ProductCountryName);
         A40001ProductCountryFlag_GXI = T00047_A40001ProductCountryFlag_GXI[0];
         n40001ProductCountryFlag_GXI = T00047_n40001ProductCountryFlag_GXI[0];
         AssignProp("", false, imgProductCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A43ProductCountryFlag)) ? A40001ProductCountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A43ProductCountryFlag))), true);
         AssignProp("", false, imgProductCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A43ProductCountryFlag), true);
         A43ProductCountryFlag = T00047_A43ProductCountryFlag[0];
         AssignAttri("", false, "A43ProductCountryFlag", A43ProductCountryFlag);
         AssignProp("", false, imgProductCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A43ProductCountryFlag)) ? A40001ProductCountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A43ProductCountryFlag))), true);
         AssignProp("", false, imgProductCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A43ProductCountryFlag), true);
         pr_default.close(5);
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {A24SupplierId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A25SupplierName = T00045_A25SupplierName[0];
         AssignAttri("", false, "A25SupplierName", A25SupplierName);
         pr_default.close(3);
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {A4CategoryId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
            GX_FocusControl = edtCategoryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5CategoryName = T00046_A5CategoryName[0];
         AssignAttri("", false, "A5CategoryName", A5CategoryName);
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

      protected void gxLoad_21( short A6SellerId )
      {
         /* Using cursor T000410 */
         pr_default.execute(8, new Object[] {A6SellerId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Seller'.", "ForeignKeyNotFound", 1, "SELLERID");
            AnyError = 1;
            GX_FocusControl = edtSellerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A7SellerName = T000410_A7SellerName[0];
         AssignAttri("", false, "A7SellerName", A7SellerName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A7SellerName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_24( short A41ProductCountryId )
      {
         /* Using cursor T000411 */
         pr_default.execute(9, new Object[] {A41ProductCountryId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Product Country'.", "ForeignKeyNotFound", 1, "PRODUCTCOUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtProductCountryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A42ProductCountryName = T000411_A42ProductCountryName[0];
         AssignAttri("", false, "A42ProductCountryName", A42ProductCountryName);
         A40001ProductCountryFlag_GXI = T000411_A40001ProductCountryFlag_GXI[0];
         n40001ProductCountryFlag_GXI = T000411_n40001ProductCountryFlag_GXI[0];
         AssignProp("", false, imgProductCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A43ProductCountryFlag)) ? A40001ProductCountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A43ProductCountryFlag))), true);
         AssignProp("", false, imgProductCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A43ProductCountryFlag), true);
         A43ProductCountryFlag = T000411_A43ProductCountryFlag[0];
         AssignAttri("", false, "A43ProductCountryFlag", A43ProductCountryFlag);
         AssignProp("", false, imgProductCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A43ProductCountryFlag)) ? A40001ProductCountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A43ProductCountryFlag))), true);
         AssignProp("", false, imgProductCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A43ProductCountryFlag), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A42ProductCountryName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A43ProductCountryFlag)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40001ProductCountryFlag_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_22( short A24SupplierId )
      {
         /* Using cursor T000412 */
         pr_default.execute(10, new Object[] {A24SupplierId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A25SupplierName = T000412_A25SupplierName[0];
         AssignAttri("", false, "A25SupplierName", A25SupplierName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A25SupplierName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_23( short A4CategoryId )
      {
         /* Using cursor T000413 */
         pr_default.execute(11, new Object[] {A4CategoryId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
            GX_FocusControl = edtCategoryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5CategoryName = T000413_A5CategoryName[0];
         AssignAttri("", false, "A5CategoryName", A5CategoryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A5CategoryName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void GetKey044( )
      {
         /* Using cursor T000414 */
         pr_default.execute(12, new Object[] {A10ProductId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(12);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A10ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 19) ;
            RcdFound4 = 1;
            A10ProductId = T00043_A10ProductId[0];
            AssignAttri("", false, "A10ProductId", StringUtil.LTrimStr( (decimal)(A10ProductId), 4, 0));
            A11ProductName = T00043_A11ProductName[0];
            AssignAttri("", false, "A11ProductName", A11ProductName);
            A12ProductDescription = T00043_A12ProductDescription[0];
            AssignAttri("", false, "A12ProductDescription", A12ProductDescription);
            A13ProductPrice = T00043_A13ProductPrice[0];
            AssignAttri("", false, "A13ProductPrice", StringUtil.LTrimStr( A13ProductPrice, 18, 2));
            A40000ProductImage_GXI = T00043_A40000ProductImage_GXI[0];
            AssignProp("", false, imgProductImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage)) ? A40000ProductImage_GXI : context.convertURL( context.PathToRelativeUrl( A14ProductImage))), true);
            AssignProp("", false, imgProductImage_Internalname, "SrcSet", context.GetImageSrcSet( A14ProductImage), true);
            A6SellerId = T00043_A6SellerId[0];
            AssignAttri("", false, "A6SellerId", StringUtil.LTrimStr( (decimal)(A6SellerId), 4, 0));
            A24SupplierId = T00043_A24SupplierId[0];
            AssignAttri("", false, "A24SupplierId", StringUtil.LTrimStr( (decimal)(A24SupplierId), 4, 0));
            A4CategoryId = T00043_A4CategoryId[0];
            AssignAttri("", false, "A4CategoryId", StringUtil.LTrimStr( (decimal)(A4CategoryId), 4, 0));
            A41ProductCountryId = T00043_A41ProductCountryId[0];
            AssignAttri("", false, "A41ProductCountryId", StringUtil.LTrimStr( (decimal)(A41ProductCountryId), 4, 0));
            A14ProductImage = T00043_A14ProductImage[0];
            AssignAttri("", false, "A14ProductImage", A14ProductImage);
            AssignProp("", false, imgProductImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage)) ? A40000ProductImage_GXI : context.convertURL( context.PathToRelativeUrl( A14ProductImage))), true);
            AssignProp("", false, imgProductImage_Internalname, "SrcSet", context.GetImageSrcSet( A14ProductImage), true);
            Z10ProductId = A10ProductId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound4 = 0;
         /* Using cursor T000415 */
         pr_default.execute(13, new Object[] {A10ProductId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T000415_A10ProductId[0] < A10ProductId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T000415_A10ProductId[0] > A10ProductId ) ) )
            {
               A10ProductId = T000415_A10ProductId[0];
               AssignAttri("", false, "A10ProductId", StringUtil.LTrimStr( (decimal)(A10ProductId), 4, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T000416 */
         pr_default.execute(14, new Object[] {A10ProductId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000416_A10ProductId[0] > A10ProductId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000416_A10ProductId[0] < A10ProductId ) ) )
            {
               A10ProductId = T000416_A10ProductId[0];
               AssignAttri("", false, "A10ProductId", StringUtil.LTrimStr( (decimal)(A10ProductId), 4, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProductName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert044( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A10ProductId != Z10ProductId )
               {
                  A10ProductId = Z10ProductId;
                  AssignAttri("", false, "A10ProductId", StringUtil.LTrimStr( (decimal)(A10ProductId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRODUCTID");
                  AnyError = 1;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProductName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update044( ) ;
                  GX_FocusControl = edtProductName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A10ProductId != Z10ProductId )
               {
                  /* Insert record */
                  GX_FocusControl = edtProductName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert044( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRODUCTID");
                     AnyError = 1;
                     GX_FocusControl = edtProductId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtProductName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert044( ) ;
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
         if ( A10ProductId != Z10ProductId )
         {
            A10ProductId = Z10ProductId;
            AssignAttri("", false, "A10ProductId", StringUtil.LTrimStr( (decimal)(A10ProductId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProductName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A10ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z11ProductName, T00042_A11ProductName[0]) != 0 ) || ( StringUtil.StrCmp(Z12ProductDescription, T00042_A12ProductDescription[0]) != 0 ) || ( Z13ProductPrice != T00042_A13ProductPrice[0] ) || ( Z6SellerId != T00042_A6SellerId[0] ) || ( Z24SupplierId != T00042_A24SupplierId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z4CategoryId != T00042_A4CategoryId[0] ) || ( Z41ProductCountryId != T00042_A41ProductCountryId[0] ) )
            {
               if ( StringUtil.StrCmp(Z11ProductName, T00042_A11ProductName[0]) != 0 )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductName");
                  GXUtil.WriteLogRaw("Old: ",Z11ProductName);
                  GXUtil.WriteLogRaw("Current: ",T00042_A11ProductName[0]);
               }
               if ( StringUtil.StrCmp(Z12ProductDescription, T00042_A12ProductDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductDescription");
                  GXUtil.WriteLogRaw("Old: ",Z12ProductDescription);
                  GXUtil.WriteLogRaw("Current: ",T00042_A12ProductDescription[0]);
               }
               if ( Z13ProductPrice != T00042_A13ProductPrice[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductPrice");
                  GXUtil.WriteLogRaw("Old: ",Z13ProductPrice);
                  GXUtil.WriteLogRaw("Current: ",T00042_A13ProductPrice[0]);
               }
               if ( Z6SellerId != T00042_A6SellerId[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"SellerId");
                  GXUtil.WriteLogRaw("Old: ",Z6SellerId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A6SellerId[0]);
               }
               if ( Z24SupplierId != T00042_A24SupplierId[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"SupplierId");
                  GXUtil.WriteLogRaw("Old: ",Z24SupplierId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A24SupplierId[0]);
               }
               if ( Z4CategoryId != T00042_A4CategoryId[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"CategoryId");
                  GXUtil.WriteLogRaw("Old: ",Z4CategoryId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A4CategoryId[0]);
               }
               if ( Z41ProductCountryId != T00042_A41ProductCountryId[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductCountryId");
                  GXUtil.WriteLogRaw("Old: ",Z41ProductCountryId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A41ProductCountryId[0]);
               }
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
                     /* Using cursor T000417 */
                     pr_default.execute(15, new Object[] {A11ProductName, A12ProductDescription, A13ProductPrice, A14ProductImage, A40000ProductImage_GXI, A6SellerId, A24SupplierId, A4CategoryId, A41ProductCountryId});
                     A10ProductId = T000417_A10ProductId[0];
                     AssignAttri("", false, "A10ProductId", StringUtil.LTrimStr( (decimal)(A10ProductId), 4, 0));
                     pr_default.close(15);
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
                           ResetCaption040( ) ;
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
                     /* Using cursor T000418 */
                     pr_default.execute(16, new Object[] {A11ProductName, A12ProductDescription, A13ProductPrice, A6SellerId, A24SupplierId, A4CategoryId, A41ProductCountryId, A10ProductId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Product");
                     if ( (pr_default.getStatus(16) == 103) )
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000419 */
            pr_default.execute(17, new Object[] {A14ProductImage, A40000ProductImage_GXI, A10ProductId});
            pr_default.close(17);
            pr_default.SmartCacheProvider.SetUpdated("Product");
         }
      }

      protected void delete( )
      {
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
                  /* Using cursor T000420 */
                  pr_default.execute(18, new Object[] {A10ProductId});
                  pr_default.close(18);
                  pr_default.SmartCacheProvider.SetUpdated("Product");
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel044( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV16Pgmname = "Product";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T000421 */
            pr_default.execute(19, new Object[] {A6SellerId});
            A7SellerName = T000421_A7SellerName[0];
            AssignAttri("", false, "A7SellerName", A7SellerName);
            pr_default.close(19);
            /* Using cursor T000422 */
            pr_default.execute(20, new Object[] {A41ProductCountryId});
            A42ProductCountryName = T000422_A42ProductCountryName[0];
            AssignAttri("", false, "A42ProductCountryName", A42ProductCountryName);
            A40001ProductCountryFlag_GXI = T000422_A40001ProductCountryFlag_GXI[0];
            n40001ProductCountryFlag_GXI = T000422_n40001ProductCountryFlag_GXI[0];
            AssignProp("", false, imgProductCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A43ProductCountryFlag)) ? A40001ProductCountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A43ProductCountryFlag))), true);
            AssignProp("", false, imgProductCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A43ProductCountryFlag), true);
            A43ProductCountryFlag = T000422_A43ProductCountryFlag[0];
            AssignAttri("", false, "A43ProductCountryFlag", A43ProductCountryFlag);
            AssignProp("", false, imgProductCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A43ProductCountryFlag)) ? A40001ProductCountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A43ProductCountryFlag))), true);
            AssignProp("", false, imgProductCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A43ProductCountryFlag), true);
            pr_default.close(20);
            /* Using cursor T000423 */
            pr_default.execute(21, new Object[] {A24SupplierId});
            A25SupplierName = T000423_A25SupplierName[0];
            AssignAttri("", false, "A25SupplierName", A25SupplierName);
            pr_default.close(21);
            /* Using cursor T000424 */
            pr_default.execute(22, new Object[] {A4CategoryId});
            A5CategoryName = T000424_A5CategoryName[0];
            AssignAttri("", false, "A5CategoryName", A5CategoryName);
            pr_default.close(22);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000425 */
            pr_default.execute(23, new Object[] {A10ProductId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T000426 */
            pr_default.execute(24, new Object[] {A10ProductId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Products"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
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
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(21);
            pr_default.close(22);
            pr_default.close(20);
            context.CommitDataStores("product",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(21);
            pr_default.close(22);
            pr_default.close(20);
            context.RollbackDataStores("product",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart044( )
      {
         /* Scan By routine */
         /* Using cursor T000427 */
         pr_default.execute(25);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound4 = 1;
            A10ProductId = T000427_A10ProductId[0];
            AssignAttri("", false, "A10ProductId", StringUtil.LTrimStr( (decimal)(A10ProductId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound4 = 1;
            A10ProductId = T000427_A10ProductId[0];
            AssignAttri("", false, "A10ProductId", StringUtil.LTrimStr( (decimal)(A10ProductId), 4, 0));
         }
      }

      protected void ScanEnd044( )
      {
         pr_default.close(25);
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
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), true);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), true);
         edtProductDescription_Enabled = 0;
         AssignProp("", false, edtProductDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductDescription_Enabled), 5, 0), true);
         edtProductPrice_Enabled = 0;
         AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), true);
         imgProductImage_Enabled = 0;
         AssignProp("", false, imgProductImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProductImage_Enabled), 5, 0), true);
         edtSellerId_Enabled = 0;
         AssignProp("", false, edtSellerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSellerId_Enabled), 5, 0), true);
         edtSellerName_Enabled = 0;
         AssignProp("", false, edtSellerName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSellerName_Enabled), 5, 0), true);
         edtProductCountryId_Enabled = 0;
         AssignProp("", false, edtProductCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCountryId_Enabled), 5, 0), true);
         edtProductCountryName_Enabled = 0;
         AssignProp("", false, edtProductCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCountryName_Enabled), 5, 0), true);
         imgProductCountryFlag_Enabled = 0;
         AssignProp("", false, imgProductCountryFlag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProductCountryFlag_Enabled), 5, 0), true);
         edtSupplierId_Enabled = 0;
         AssignProp("", false, edtSupplierId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierId_Enabled), 5, 0), true);
         edtSupplierName_Enabled = 0;
         AssignProp("", false, edtSupplierName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierName_Enabled), 5, 0), true);
         edtCategoryId_Enabled = 0;
         AssignProp("", false, edtCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryId_Enabled), 5, 0), true);
         edtCategoryName_Enabled = 0;
         AssignProp("", false, edtCategoryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
      {
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("product.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ProductId,4,0))}, new string[] {"Gx_mode","ProductId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Product");
         forbiddenHiddens.Add("ProductId", context.localUtil.Format( (decimal)(A10ProductId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("product:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z10ProductId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ProductId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z11ProductName", Z11ProductName);
         GxWebStd.gx_hidden_field( context, "Z12ProductDescription", Z12ProductDescription);
         GxWebStd.gx_hidden_field( context, "Z13ProductPrice", StringUtil.LTrim( StringUtil.NToC( Z13ProductPrice, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z6SellerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6SellerId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z24SupplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24SupplierId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z4CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4CategoryId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z41ProductCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41ProductCountryId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N6SellerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6SellerId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N41ProductCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41ProductCountryId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N24SupplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24SupplierId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N4CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoryId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vPRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ProductId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProductId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_SELLERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_SellerId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PRODUCTCOUNTRYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Insert_ProductCountryId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SUPPLIERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_SupplierId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CATEGORYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_CategoryId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTIMAGE_GXI", A40000ProductImage_GXI);
         GxWebStd.gx_hidden_field( context, "PRODUCTCOUNTRYFLAG_GXI", A40001ProductCountryFlag_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
         GXCCtlgxBlob = "PRODUCTIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A14ProductImage);
         GXCCtlgxBlob = "PRODUCTCOUNTRYFLAG" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A43ProductCountryFlag);
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
         return formatLink("product.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ProductId,4,0))}, new string[] {"Gx_mode","ProductId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Product" ;
      }

      public override string GetPgmdesc( )
      {
         return "Product" ;
      }

      protected void InitializeNonKey044( )
      {
         A6SellerId = 0;
         AssignAttri("", false, "A6SellerId", StringUtil.LTrimStr( (decimal)(A6SellerId), 4, 0));
         A41ProductCountryId = 0;
         AssignAttri("", false, "A41ProductCountryId", StringUtil.LTrimStr( (decimal)(A41ProductCountryId), 4, 0));
         A24SupplierId = 0;
         AssignAttri("", false, "A24SupplierId", StringUtil.LTrimStr( (decimal)(A24SupplierId), 4, 0));
         A4CategoryId = 0;
         AssignAttri("", false, "A4CategoryId", StringUtil.LTrimStr( (decimal)(A4CategoryId), 4, 0));
         A11ProductName = "";
         AssignAttri("", false, "A11ProductName", A11ProductName);
         A12ProductDescription = "";
         AssignAttri("", false, "A12ProductDescription", A12ProductDescription);
         A13ProductPrice = 0;
         AssignAttri("", false, "A13ProductPrice", StringUtil.LTrimStr( A13ProductPrice, 18, 2));
         A14ProductImage = "";
         AssignAttri("", false, "A14ProductImage", A14ProductImage);
         AssignProp("", false, imgProductImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage)) ? A40000ProductImage_GXI : context.convertURL( context.PathToRelativeUrl( A14ProductImage))), true);
         AssignProp("", false, imgProductImage_Internalname, "SrcSet", context.GetImageSrcSet( A14ProductImage), true);
         A40000ProductImage_GXI = "";
         AssignProp("", false, imgProductImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage)) ? A40000ProductImage_GXI : context.convertURL( context.PathToRelativeUrl( A14ProductImage))), true);
         AssignProp("", false, imgProductImage_Internalname, "SrcSet", context.GetImageSrcSet( A14ProductImage), true);
         A7SellerName = "";
         AssignAttri("", false, "A7SellerName", A7SellerName);
         A42ProductCountryName = "";
         AssignAttri("", false, "A42ProductCountryName", A42ProductCountryName);
         A43ProductCountryFlag = "";
         AssignAttri("", false, "A43ProductCountryFlag", A43ProductCountryFlag);
         AssignProp("", false, imgProductCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A43ProductCountryFlag)) ? A40001ProductCountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A43ProductCountryFlag))), true);
         AssignProp("", false, imgProductCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A43ProductCountryFlag), true);
         A40001ProductCountryFlag_GXI = "";
         n40001ProductCountryFlag_GXI = false;
         AssignProp("", false, imgProductCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A43ProductCountryFlag)) ? A40001ProductCountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A43ProductCountryFlag))), true);
         AssignProp("", false, imgProductCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A43ProductCountryFlag), true);
         A25SupplierName = "";
         AssignAttri("", false, "A25SupplierName", A25SupplierName);
         A5CategoryName = "";
         AssignAttri("", false, "A5CategoryName", A5CategoryName);
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
         AssignAttri("", false, "A10ProductId", StringUtil.LTrimStr( (decimal)(A10ProductId), 4, 0));
         InitializeNonKey044( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411250212965", true, true);
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
         context.AddJavascriptSource("product.js", "?202411250212965", false, true);
         /* End function include_jscripts */
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
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductDescription_Internalname = "PRODUCTDESCRIPTION";
         edtProductPrice_Internalname = "PRODUCTPRICE";
         imgProductImage_Internalname = "PRODUCTIMAGE";
         edtSellerId_Internalname = "SELLERID";
         edtSellerName_Internalname = "SELLERNAME";
         edtProductCountryId_Internalname = "PRODUCTCOUNTRYID";
         edtProductCountryName_Internalname = "PRODUCTCOUNTRYNAME";
         imgProductCountryFlag_Internalname = "PRODUCTCOUNTRYFLAG";
         edtSupplierId_Internalname = "SUPPLIERID";
         edtSupplierName_Internalname = "SUPPLIERNAME";
         edtCategoryId_Internalname = "CATEGORYID";
         edtCategoryName_Internalname = "CATEGORYNAME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_6_Internalname = "PROMPT_6";
         imgprompt_41_Internalname = "PROMPT_41";
         imgprompt_24_Internalname = "PROMPT_24";
         imgprompt_4_Internalname = "PROMPT_4";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("ObligatorioShop", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Product";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCategoryName_Jsonclick = "";
         edtCategoryName_Enabled = 0;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtCategoryId_Jsonclick = "";
         edtCategoryId_Enabled = 1;
         edtSupplierName_Jsonclick = "";
         edtSupplierName_Enabled = 0;
         imgprompt_24_Visible = 1;
         imgprompt_24_Link = "";
         edtSupplierId_Jsonclick = "";
         edtSupplierId_Enabled = 1;
         imgProductCountryFlag_Enabled = 0;
         edtProductCountryName_Jsonclick = "";
         edtProductCountryName_Enabled = 0;
         imgprompt_41_Visible = 1;
         imgprompt_41_Link = "";
         edtProductCountryId_Jsonclick = "";
         edtProductCountryId_Enabled = 1;
         edtSellerName_Jsonclick = "";
         edtSellerName_Enabled = 0;
         imgprompt_6_Visible = 1;
         imgprompt_6_Link = "";
         edtSellerId_Jsonclick = "";
         edtSellerId_Enabled = 1;
         imgProductImage_Enabled = 1;
         edtProductPrice_Jsonclick = "";
         edtProductPrice_Enabled = 1;
         edtProductDescription_Enabled = 1;
         edtProductName_Jsonclick = "";
         edtProductName_Enabled = 1;
         edtProductId_Jsonclick = "";
         edtProductId_Enabled = 0;
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

      public void Valid_Productname( )
      {
         /* Using cursor T000428 */
         pr_default.execute(26, new Object[] {A11ProductName, A10ProductId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Product Name"}), 1, "PRODUCTNAME");
            AnyError = 1;
            GX_FocusControl = edtProductName_Internalname;
         }
         pr_default.close(26);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A11ProductName)) )
         {
            GX_msglist.addItem("El nombre no puede estar vacio", 1, "PRODUCTNAME");
            AnyError = 1;
            GX_FocusControl = edtProductName_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Sellerid( )
      {
         /* Using cursor T000421 */
         pr_default.execute(19, new Object[] {A6SellerId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Seller'.", "ForeignKeyNotFound", 1, "SELLERID");
            AnyError = 1;
            GX_FocusControl = edtSellerId_Internalname;
         }
         A7SellerName = T000421_A7SellerName[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A7SellerName", A7SellerName);
      }

      public void Valid_Productcountryid( )
      {
         n40001ProductCountryFlag_GXI = false;
         /* Using cursor T000422 */
         pr_default.execute(20, new Object[] {A41ProductCountryId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Product Country'.", "ForeignKeyNotFound", 1, "PRODUCTCOUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtProductCountryId_Internalname;
         }
         A42ProductCountryName = T000422_A42ProductCountryName[0];
         A40001ProductCountryFlag_GXI = T000422_A40001ProductCountryFlag_GXI[0];
         n40001ProductCountryFlag_GXI = T000422_n40001ProductCountryFlag_GXI[0];
         A43ProductCountryFlag = T000422_A43ProductCountryFlag[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A42ProductCountryName", A42ProductCountryName);
         AssignAttri("", false, "A43ProductCountryFlag", context.PathToRelativeUrl( A43ProductCountryFlag));
         GXCCtlgxBlob = "PRODUCTCOUNTRYFLAG" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A43ProductCountryFlag));
         AssignAttri("", false, "A40001ProductCountryFlag_GXI", A40001ProductCountryFlag_GXI);
      }

      public void Valid_Supplierid( )
      {
         /* Using cursor T000423 */
         pr_default.execute(21, new Object[] {A24SupplierId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSupplierId_Internalname;
         }
         A25SupplierName = T000423_A25SupplierName[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A25SupplierName", A25SupplierName);
      }

      public void Valid_Categoryid( )
      {
         /* Using cursor T000424 */
         pr_default.execute(22, new Object[] {A4CategoryId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
            GX_FocusControl = edtCategoryId_Internalname;
         }
         A5CategoryName = T000424_A5CategoryName[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A5CategoryName", A5CategoryName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7ProductId","fld":"vPRODUCTID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7ProductId","fld":"vPRODUCTID","pic":"ZZZ9","hsh":true},{"av":"A10ProductId","fld":"PRODUCTID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12042","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_PRODUCTID","""{"handler":"Valid_Productid","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTNAME","""{"handler":"Valid_Productname","iparms":[{"av":"A11ProductName","fld":"PRODUCTNAME"},{"av":"A10ProductId","fld":"PRODUCTID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_PRODUCTPRICE","""{"handler":"Valid_Productprice","iparms":[]}""");
         setEventMetadata("VALID_SELLERID","""{"handler":"Valid_Sellerid","iparms":[{"av":"A6SellerId","fld":"SELLERID","pic":"ZZZ9"},{"av":"A7SellerName","fld":"SELLERNAME"}]""");
         setEventMetadata("VALID_SELLERID",""","oparms":[{"av":"A7SellerName","fld":"SELLERNAME"}]}""");
         setEventMetadata("VALID_PRODUCTCOUNTRYID","""{"handler":"Valid_Productcountryid","iparms":[{"av":"A41ProductCountryId","fld":"PRODUCTCOUNTRYID","pic":"ZZZ9"},{"av":"A42ProductCountryName","fld":"PRODUCTCOUNTRYNAME"},{"av":"A43ProductCountryFlag","fld":"PRODUCTCOUNTRYFLAG"},{"av":"A40001ProductCountryFlag_GXI","fld":"PRODUCTCOUNTRYFLAG_GXI"}]""");
         setEventMetadata("VALID_PRODUCTCOUNTRYID",""","oparms":[{"av":"A42ProductCountryName","fld":"PRODUCTCOUNTRYNAME"},{"av":"A43ProductCountryFlag","fld":"PRODUCTCOUNTRYFLAG"},{"av":"A40001ProductCountryFlag_GXI","fld":"PRODUCTCOUNTRYFLAG_GXI"}]}""");
         setEventMetadata("VALID_SUPPLIERID","""{"handler":"Valid_Supplierid","iparms":[{"av":"A24SupplierId","fld":"SUPPLIERID","pic":"ZZZ9"},{"av":"A25SupplierName","fld":"SUPPLIERNAME"}]""");
         setEventMetadata("VALID_SUPPLIERID",""","oparms":[{"av":"A25SupplierName","fld":"SUPPLIERNAME"}]}""");
         setEventMetadata("VALID_CATEGORYID","""{"handler":"Valid_Categoryid","iparms":[{"av":"A4CategoryId","fld":"CATEGORYID","pic":"ZZZ9"},{"av":"A5CategoryName","fld":"CATEGORYNAME"}]""");
         setEventMetadata("VALID_CATEGORYID",""","oparms":[{"av":"A5CategoryName","fld":"CATEGORYNAME"}]}""");
         return  ;
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
         pr_default.close(19);
         pr_default.close(21);
         pr_default.close(22);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z11ProductName = "";
         Z12ProductDescription = "";
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
         A11ProductName = "";
         A12ProductDescription = "";
         A14ProductImage = "";
         A40000ProductImage_GXI = "";
         sImgUrl = "";
         imgprompt_6_gximage = "";
         A7SellerName = "";
         imgprompt_41_gximage = "";
         A42ProductCountryName = "";
         A43ProductCountryFlag = "";
         A40001ProductCountryFlag_GXI = "";
         imgprompt_24_gximage = "";
         A25SupplierName = "";
         imgprompt_4_gximage = "";
         A5CategoryName = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV16Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode4 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z14ProductImage = "";
         Z40000ProductImage_GXI = "";
         Z7SellerName = "";
         Z42ProductCountryName = "";
         Z43ProductCountryFlag = "";
         Z40001ProductCountryFlag_GXI = "";
         Z25SupplierName = "";
         Z5CategoryName = "";
         T00046_A5CategoryName = new string[] {""} ;
         T00045_A25SupplierName = new string[] {""} ;
         T00047_A42ProductCountryName = new string[] {""} ;
         T00047_A40001ProductCountryFlag_GXI = new string[] {""} ;
         T00047_n40001ProductCountryFlag_GXI = new bool[] {false} ;
         T00047_A43ProductCountryFlag = new string[] {""} ;
         T00044_A7SellerName = new string[] {""} ;
         T00048_A10ProductId = new short[1] ;
         T00048_A11ProductName = new string[] {""} ;
         T00048_A12ProductDescription = new string[] {""} ;
         T00048_A13ProductPrice = new decimal[1] ;
         T00048_A40000ProductImage_GXI = new string[] {""} ;
         T00048_A7SellerName = new string[] {""} ;
         T00048_A42ProductCountryName = new string[] {""} ;
         T00048_A40001ProductCountryFlag_GXI = new string[] {""} ;
         T00048_n40001ProductCountryFlag_GXI = new bool[] {false} ;
         T00048_A25SupplierName = new string[] {""} ;
         T00048_A5CategoryName = new string[] {""} ;
         T00048_A6SellerId = new short[1] ;
         T00048_A24SupplierId = new short[1] ;
         T00048_A4CategoryId = new short[1] ;
         T00048_A41ProductCountryId = new short[1] ;
         T00048_A14ProductImage = new string[] {""} ;
         T00048_A43ProductCountryFlag = new string[] {""} ;
         T00049_A11ProductName = new string[] {""} ;
         T000410_A7SellerName = new string[] {""} ;
         T000411_A42ProductCountryName = new string[] {""} ;
         T000411_A40001ProductCountryFlag_GXI = new string[] {""} ;
         T000411_n40001ProductCountryFlag_GXI = new bool[] {false} ;
         T000411_A43ProductCountryFlag = new string[] {""} ;
         T000412_A25SupplierName = new string[] {""} ;
         T000413_A5CategoryName = new string[] {""} ;
         T000414_A10ProductId = new short[1] ;
         T00043_A10ProductId = new short[1] ;
         T00043_A11ProductName = new string[] {""} ;
         T00043_A12ProductDescription = new string[] {""} ;
         T00043_A13ProductPrice = new decimal[1] ;
         T00043_A40000ProductImage_GXI = new string[] {""} ;
         T00043_A6SellerId = new short[1] ;
         T00043_A24SupplierId = new short[1] ;
         T00043_A4CategoryId = new short[1] ;
         T00043_A41ProductCountryId = new short[1] ;
         T00043_A14ProductImage = new string[] {""} ;
         T000415_A10ProductId = new short[1] ;
         T000416_A10ProductId = new short[1] ;
         T00042_A10ProductId = new short[1] ;
         T00042_A11ProductName = new string[] {""} ;
         T00042_A12ProductDescription = new string[] {""} ;
         T00042_A13ProductPrice = new decimal[1] ;
         T00042_A40000ProductImage_GXI = new string[] {""} ;
         T00042_A6SellerId = new short[1] ;
         T00042_A24SupplierId = new short[1] ;
         T00042_A4CategoryId = new short[1] ;
         T00042_A41ProductCountryId = new short[1] ;
         T00042_A14ProductImage = new string[] {""} ;
         T000417_A10ProductId = new short[1] ;
         T000421_A7SellerName = new string[] {""} ;
         T000422_A42ProductCountryName = new string[] {""} ;
         T000422_A40001ProductCountryFlag_GXI = new string[] {""} ;
         T000422_n40001ProductCountryFlag_GXI = new bool[] {false} ;
         T000422_A43ProductCountryFlag = new string[] {""} ;
         T000423_A25SupplierName = new string[] {""} ;
         T000424_A5CategoryName = new string[] {""} ;
         T000425_A26PromotionId = new short[1] ;
         T000425_A10ProductId = new short[1] ;
         T000426_A31ShoppingCartId = new short[1] ;
         T000426_A10ProductId = new short[1] ;
         T000427_A10ProductId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         T000428_A11ProductName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.product__default(),
            new Object[][] {
                new Object[] {
               T00042_A10ProductId, T00042_A11ProductName, T00042_A12ProductDescription, T00042_A13ProductPrice, T00042_A40000ProductImage_GXI, T00042_A6SellerId, T00042_A24SupplierId, T00042_A4CategoryId, T00042_A41ProductCountryId, T00042_A14ProductImage
               }
               , new Object[] {
               T00043_A10ProductId, T00043_A11ProductName, T00043_A12ProductDescription, T00043_A13ProductPrice, T00043_A40000ProductImage_GXI, T00043_A6SellerId, T00043_A24SupplierId, T00043_A4CategoryId, T00043_A41ProductCountryId, T00043_A14ProductImage
               }
               , new Object[] {
               T00044_A7SellerName
               }
               , new Object[] {
               T00045_A25SupplierName
               }
               , new Object[] {
               T00046_A5CategoryName
               }
               , new Object[] {
               T00047_A42ProductCountryName, T00047_A40001ProductCountryFlag_GXI, T00047_n40001ProductCountryFlag_GXI, T00047_A43ProductCountryFlag
               }
               , new Object[] {
               T00048_A10ProductId, T00048_A11ProductName, T00048_A12ProductDescription, T00048_A13ProductPrice, T00048_A40000ProductImage_GXI, T00048_A7SellerName, T00048_A42ProductCountryName, T00048_A40001ProductCountryFlag_GXI, T00048_n40001ProductCountryFlag_GXI, T00048_A25SupplierName,
               T00048_A5CategoryName, T00048_A6SellerId, T00048_A24SupplierId, T00048_A4CategoryId, T00048_A41ProductCountryId, T00048_A14ProductImage, T00048_A43ProductCountryFlag
               }
               , new Object[] {
               T00049_A11ProductName
               }
               , new Object[] {
               T000410_A7SellerName
               }
               , new Object[] {
               T000411_A42ProductCountryName, T000411_A40001ProductCountryFlag_GXI, T000411_n40001ProductCountryFlag_GXI, T000411_A43ProductCountryFlag
               }
               , new Object[] {
               T000412_A25SupplierName
               }
               , new Object[] {
               T000413_A5CategoryName
               }
               , new Object[] {
               T000414_A10ProductId
               }
               , new Object[] {
               T000415_A10ProductId
               }
               , new Object[] {
               T000416_A10ProductId
               }
               , new Object[] {
               T000417_A10ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000421_A7SellerName
               }
               , new Object[] {
               T000422_A42ProductCountryName, T000422_A40001ProductCountryFlag_GXI, T000422_n40001ProductCountryFlag_GXI, T000422_A43ProductCountryFlag
               }
               , new Object[] {
               T000423_A25SupplierName
               }
               , new Object[] {
               T000424_A5CategoryName
               }
               , new Object[] {
               T000425_A26PromotionId, T000425_A10ProductId
               }
               , new Object[] {
               T000426_A31ShoppingCartId, T000426_A10ProductId
               }
               , new Object[] {
               T000427_A10ProductId
               }
               , new Object[] {
               T000428_A11ProductName
               }
            }
         );
         AV16Pgmname = "Product";
      }

      private short wcpOAV7ProductId ;
      private short Z10ProductId ;
      private short Z6SellerId ;
      private short Z24SupplierId ;
      private short Z4CategoryId ;
      private short Z41ProductCountryId ;
      private short N6SellerId ;
      private short N41ProductCountryId ;
      private short N24SupplierId ;
      private short N4CategoryId ;
      private short GxWebError ;
      private short A6SellerId ;
      private short A41ProductCountryId ;
      private short A24SupplierId ;
      private short A4CategoryId ;
      private short AV7ProductId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A10ProductId ;
      private short AV11Insert_SellerId ;
      private short AV15Insert_ProductCountryId ;
      private short AV12Insert_SupplierId ;
      private short AV13Insert_CategoryId ;
      private short RcdFound4 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProductId_Enabled ;
      private int edtProductName_Enabled ;
      private int edtProductDescription_Enabled ;
      private int edtProductPrice_Enabled ;
      private int imgProductImage_Enabled ;
      private int edtSellerId_Enabled ;
      private int imgprompt_6_Visible ;
      private int edtSellerName_Enabled ;
      private int edtProductCountryId_Enabled ;
      private int imgprompt_41_Visible ;
      private int edtProductCountryName_Enabled ;
      private int imgProductCountryFlag_Enabled ;
      private int edtSupplierId_Enabled ;
      private int imgprompt_24_Visible ;
      private int edtSupplierName_Enabled ;
      private int edtCategoryId_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtCategoryName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV17GXV1 ;
      private int idxLst ;
      private decimal Z13ProductPrice ;
      private decimal A13ProductPrice ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProductName_Internalname ;
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
      private string edtProductId_Internalname ;
      private string edtProductId_Jsonclick ;
      private string edtProductName_Jsonclick ;
      private string edtProductDescription_Internalname ;
      private string edtProductPrice_Internalname ;
      private string edtProductPrice_Jsonclick ;
      private string imgProductImage_Internalname ;
      private string sImgUrl ;
      private string edtSellerId_Internalname ;
      private string edtSellerId_Jsonclick ;
      private string imgprompt_6_gximage ;
      private string imgprompt_6_Internalname ;
      private string imgprompt_6_Link ;
      private string edtSellerName_Internalname ;
      private string edtSellerName_Jsonclick ;
      private string edtProductCountryId_Internalname ;
      private string edtProductCountryId_Jsonclick ;
      private string imgprompt_41_gximage ;
      private string imgprompt_41_Internalname ;
      private string imgprompt_41_Link ;
      private string edtProductCountryName_Internalname ;
      private string edtProductCountryName_Jsonclick ;
      private string imgProductCountryFlag_Internalname ;
      private string edtSupplierId_Internalname ;
      private string edtSupplierId_Jsonclick ;
      private string imgprompt_24_gximage ;
      private string imgprompt_24_Internalname ;
      private string imgprompt_24_Link ;
      private string edtSupplierName_Internalname ;
      private string edtSupplierName_Jsonclick ;
      private string edtCategoryId_Internalname ;
      private string edtCategoryId_Jsonclick ;
      private string imgprompt_4_gximage ;
      private string imgprompt_4_Internalname ;
      private string imgprompt_4_Link ;
      private string edtCategoryName_Internalname ;
      private string edtCategoryName_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV16Pgmname ;
      private string hsh ;
      private string sMode4 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A14ProductImage_IsBlob ;
      private bool A43ProductCountryFlag_IsBlob ;
      private bool returnInSub ;
      private bool n40001ProductCountryFlag_GXI ;
      private bool Gx_longc ;
      private string Z11ProductName ;
      private string Z12ProductDescription ;
      private string A11ProductName ;
      private string A12ProductDescription ;
      private string A40000ProductImage_GXI ;
      private string A7SellerName ;
      private string A42ProductCountryName ;
      private string A40001ProductCountryFlag_GXI ;
      private string A25SupplierName ;
      private string A5CategoryName ;
      private string Z40000ProductImage_GXI ;
      private string Z7SellerName ;
      private string Z42ProductCountryName ;
      private string Z40001ProductCountryFlag_GXI ;
      private string Z25SupplierName ;
      private string Z5CategoryName ;
      private string A14ProductImage ;
      private string A43ProductCountryFlag ;
      private string Z14ProductImage ;
      private string Z43ProductCountryFlag ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00046_A5CategoryName ;
      private string[] T00045_A25SupplierName ;
      private string[] T00047_A42ProductCountryName ;
      private string[] T00047_A40001ProductCountryFlag_GXI ;
      private bool[] T00047_n40001ProductCountryFlag_GXI ;
      private string[] T00047_A43ProductCountryFlag ;
      private string[] T00044_A7SellerName ;
      private short[] T00048_A10ProductId ;
      private string[] T00048_A11ProductName ;
      private string[] T00048_A12ProductDescription ;
      private decimal[] T00048_A13ProductPrice ;
      private string[] T00048_A40000ProductImage_GXI ;
      private string[] T00048_A7SellerName ;
      private string[] T00048_A42ProductCountryName ;
      private string[] T00048_A40001ProductCountryFlag_GXI ;
      private bool[] T00048_n40001ProductCountryFlag_GXI ;
      private string[] T00048_A25SupplierName ;
      private string[] T00048_A5CategoryName ;
      private short[] T00048_A6SellerId ;
      private short[] T00048_A24SupplierId ;
      private short[] T00048_A4CategoryId ;
      private short[] T00048_A41ProductCountryId ;
      private string[] T00048_A14ProductImage ;
      private string[] T00048_A43ProductCountryFlag ;
      private string[] T00049_A11ProductName ;
      private string[] T000410_A7SellerName ;
      private string[] T000411_A42ProductCountryName ;
      private string[] T000411_A40001ProductCountryFlag_GXI ;
      private bool[] T000411_n40001ProductCountryFlag_GXI ;
      private string[] T000411_A43ProductCountryFlag ;
      private string[] T000412_A25SupplierName ;
      private string[] T000413_A5CategoryName ;
      private short[] T000414_A10ProductId ;
      private short[] T00043_A10ProductId ;
      private string[] T00043_A11ProductName ;
      private string[] T00043_A12ProductDescription ;
      private decimal[] T00043_A13ProductPrice ;
      private string[] T00043_A40000ProductImage_GXI ;
      private short[] T00043_A6SellerId ;
      private short[] T00043_A24SupplierId ;
      private short[] T00043_A4CategoryId ;
      private short[] T00043_A41ProductCountryId ;
      private string[] T00043_A14ProductImage ;
      private short[] T000415_A10ProductId ;
      private short[] T000416_A10ProductId ;
      private short[] T00042_A10ProductId ;
      private string[] T00042_A11ProductName ;
      private string[] T00042_A12ProductDescription ;
      private decimal[] T00042_A13ProductPrice ;
      private string[] T00042_A40000ProductImage_GXI ;
      private short[] T00042_A6SellerId ;
      private short[] T00042_A24SupplierId ;
      private short[] T00042_A4CategoryId ;
      private short[] T00042_A41ProductCountryId ;
      private string[] T00042_A14ProductImage ;
      private short[] T000417_A10ProductId ;
      private string[] T000421_A7SellerName ;
      private string[] T000422_A42ProductCountryName ;
      private string[] T000422_A40001ProductCountryFlag_GXI ;
      private bool[] T000422_n40001ProductCountryFlag_GXI ;
      private string[] T000422_A43ProductCountryFlag ;
      private string[] T000423_A25SupplierName ;
      private string[] T000424_A5CategoryName ;
      private short[] T000425_A26PromotionId ;
      private short[] T000425_A10ProductId ;
      private short[] T000426_A31ShoppingCartId ;
      private short[] T000426_A10ProductId ;
      private short[] T000427_A10ProductId ;
      private string[] T000428_A11ProductName ;
   }

   public class product__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[16])
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00042;
          prmT00042 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00043;
          prmT00043 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00044;
          prmT00044 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT00045;
          prmT00045 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0)
          };
          Object[] prmT00046;
          prmT00046 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT00047;
          prmT00047 = new Object[] {
          new ParDef("@ProductCountryId",GXType.Int16,4,0)
          };
          Object[] prmT00048;
          prmT00048 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00049;
          prmT00049 = new Object[] {
          new ParDef("@ProductName",GXType.NVarChar,40,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000410;
          prmT000410 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT000411;
          prmT000411 = new Object[] {
          new ParDef("@ProductCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000412;
          prmT000412 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0)
          };
          Object[] prmT000413;
          prmT000413 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT000414;
          prmT000414 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000415;
          prmT000415 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000416;
          prmT000416 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000417;
          prmT000417 = new Object[] {
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
          Object[] prmT000418;
          prmT000418 = new Object[] {
          new ParDef("@ProductName",GXType.NVarChar,40,0) ,
          new ParDef("@ProductDescription",GXType.NVarChar,200,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,18,2) ,
          new ParDef("@SellerId",GXType.Int16,4,0) ,
          new ParDef("@SupplierId",GXType.Int16,4,0) ,
          new ParDef("@CategoryId",GXType.Int16,4,0) ,
          new ParDef("@ProductCountryId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000419;
          prmT000419 = new Object[] {
          new ParDef("@ProductImage",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Product", Fld="ProductImage"} ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000420;
          prmT000420 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000421;
          prmT000421 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT000422;
          prmT000422 = new Object[] {
          new ParDef("@ProductCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000423;
          prmT000423 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0)
          };
          Object[] prmT000424;
          prmT000424 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT000425;
          prmT000425 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000426;
          prmT000426 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000427;
          prmT000427 = new Object[] {
          };
          Object[] prmT000428;
          prmT000428 = new Object[] {
          new ParDef("@ProductName",GXType.NVarChar,40,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00042", "SELECT [ProductId], [ProductName], [ProductDescription], [ProductPrice], [ProductImage_GXI], [SellerId], [SupplierId], [CategoryId], [ProductCountryId] AS ProductCountryId, [ProductImage] FROM [Product] WITH (UPDLOCK) WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00043", "SELECT [ProductId], [ProductName], [ProductDescription], [ProductPrice], [ProductImage_GXI], [SellerId], [SupplierId], [CategoryId], [ProductCountryId] AS ProductCountryId, [ProductImage] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00044", "SELECT [SellerName] FROM [Seller] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00045", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00046", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00047", "SELECT [CountryName] AS ProductCountryName, [CountryFlag_GXI] AS ProductCountryFlag_GXI, [CountryFlag] AS ProductCountryFlag FROM [Country] WHERE [CountryId] = @ProductCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00048", "SELECT TM1.[ProductId], TM1.[ProductName], TM1.[ProductDescription], TM1.[ProductPrice], TM1.[ProductImage_GXI], T2.[SellerName], T3.[CountryName] AS ProductCountryName, T3.[CountryFlag_GXI] AS ProductCountryFlag_GXI, T4.[SupplierName], T5.[CategoryName], TM1.[SellerId], TM1.[SupplierId], TM1.[CategoryId], TM1.[ProductCountryId] AS ProductCountryId, TM1.[ProductImage], T3.[CountryFlag] AS ProductCountryFlag FROM (((([Product] TM1 INNER JOIN [Seller] T2 ON T2.[SellerId] = TM1.[SellerId]) INNER JOIN [Country] T3 ON T3.[CountryId] = TM1.[ProductCountryId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = TM1.[SupplierId]) INNER JOIN [Category] T5 ON T5.[CategoryId] = TM1.[CategoryId]) WHERE TM1.[ProductId] = @ProductId ORDER BY TM1.[ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00049", "SELECT [ProductName] FROM [Product] WHERE ([ProductName] = @ProductName) AND (Not ( [ProductId] = @ProductId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000410", "SELECT [SellerName] FROM [Seller] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000411", "SELECT [CountryName] AS ProductCountryName, [CountryFlag_GXI] AS ProductCountryFlag_GXI, [CountryFlag] AS ProductCountryFlag FROM [Country] WHERE [CountryId] = @ProductCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000412", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000412,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000413", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000413,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000414", "SELECT [ProductId] FROM [Product] WHERE [ProductId] = @ProductId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000414,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000415", "SELECT TOP 1 [ProductId] FROM [Product] WHERE ( [ProductId] > @ProductId) ORDER BY [ProductId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000415,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000416", "SELECT TOP 1 [ProductId] FROM [Product] WHERE ( [ProductId] < @ProductId) ORDER BY [ProductId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000416,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000417", "INSERT INTO [Product]([ProductName], [ProductDescription], [ProductPrice], [ProductImage], [ProductImage_GXI], [SellerId], [SupplierId], [CategoryId], [ProductCountryId]) VALUES(@ProductName, @ProductDescription, @ProductPrice, @ProductImage, @ProductImage_GXI, @SellerId, @SupplierId, @CategoryId, @ProductCountryId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000417,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000418", "UPDATE [Product] SET [ProductName]=@ProductName, [ProductDescription]=@ProductDescription, [ProductPrice]=@ProductPrice, [SellerId]=@SellerId, [SupplierId]=@SupplierId, [CategoryId]=@CategoryId, [ProductCountryId]=@ProductCountryId  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000418)
             ,new CursorDef("T000419", "UPDATE [Product] SET [ProductImage]=@ProductImage, [ProductImage_GXI]=@ProductImage_GXI  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000419)
             ,new CursorDef("T000420", "DELETE FROM [Product]  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000420)
             ,new CursorDef("T000421", "SELECT [SellerName] FROM [Seller] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000421,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000422", "SELECT [CountryName] AS ProductCountryName, [CountryFlag_GXI] AS ProductCountryFlag_GXI, [CountryFlag] AS ProductCountryFlag FROM [Country] WHERE [CountryId] = @ProductCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000422,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000423", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000423,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000424", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000424,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000425", "SELECT TOP 1 [PromotionId], [ProductId] FROM [PromotionProduct] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000425,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000426", "SELECT TOP 1 [ShoppingCartId], [ProductId] FROM [ShoppingCartProducts] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000426,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000427", "SELECT [ProductId] FROM [Product] ORDER BY [ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000427,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000428", "SELECT [ProductName] FROM [Product] WHERE ([ProductName] = @ProductName) AND (Not ( [ProductId] = @ProductId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000428,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
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
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 25 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
