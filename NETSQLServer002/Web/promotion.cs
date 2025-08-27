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
   public class promotion : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A10ProductId = (short)(Math.Round(NumberUtil.Val( GetPar( "ProductId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A10ProductId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A4CategoryId = (short)(Math.Round(NumberUtil.Val( GetPar( "CategoryId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A4CategoryId", StringUtil.LTrimStr( (decimal)(A4CategoryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A4CategoryId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridpromotion_product") == 0 )
         {
            gxnrGridpromotion_product_newrow_invoke( ) ;
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
               AV7PromotionId = (short)(Math.Round(NumberUtil.Val( GetPar( "PromotionId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7PromotionId", StringUtil.LTrimStr( (decimal)(AV7PromotionId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPROMOTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PromotionId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", "Promotion", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPromotionDescription_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("ObligatorioShop", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridpromotion_product_newrow_invoke( )
      {
         nRC_GXsfl_63 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_63"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_63_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_63_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_63_idx = GetPar( "sGXsfl_63_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridpromotion_product_newrow( ) ;
         /* End function gxnrGridpromotion_product_newrow_invoke */
      }

      public promotion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public promotion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_PromotionId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PromotionId = aP1_PromotionId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Promotion", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Promotion.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Promotion.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromotionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromotionId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPromotionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26PromotionId), 4, 0, ",", "")), StringUtil.LTrim( ((edtPromotionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A26PromotionId), "ZZZ9") : context.localUtil.Format( (decimal)(A26PromotionId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromotionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromotionId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromotionDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromotionDescription_Internalname, "Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPromotionDescription_Internalname, A27PromotionDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtPromotionDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgPromotionImage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Image", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A28PromotionImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A28PromotionImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000PromotionImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A28PromotionImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A28PromotionImage)) ? A40000PromotionImage_GXI : context.PathToRelativeUrl( A28PromotionImage));
         GxWebStd.gx_bitmap( context, imgPromotionImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgPromotionImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", "", "", 0, A28PromotionImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Promotion.htm");
         AssignProp("", false, imgPromotionImage_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A28PromotionImage)) ? A40000PromotionImage_GXI : context.PathToRelativeUrl( A28PromotionImage)), true);
         AssignProp("", false, imgPromotionImage_Internalname, "IsBlob", StringUtil.BoolToStr( A28PromotionImage_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromotionDateStart_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromotionDateStart_Internalname, "Date Start", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPromotionDateStart_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPromotionDateStart_Internalname, context.localUtil.Format(A29PromotionDateStart, "99/99/99"), context.localUtil.Format( A29PromotionDateStart, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromotionDateStart_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromotionDateStart_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Promotion.htm");
         GxWebStd.gx_bitmap( context, edtPromotionDateStart_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPromotionDateStart_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Promotion.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromotionDateFinish_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromotionDateFinish_Internalname, "Date Finish", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPromotionDateFinish_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPromotionDateFinish_Internalname, context.localUtil.Format(A30PromotionDateFinish, "99/99/99"), context.localUtil.Format( A30PromotionDateFinish, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromotionDateFinish_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromotionDateFinish_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Promotion.htm");
         GxWebStd.gx_bitmap( context, edtPromotionDateFinish_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPromotionDateFinish_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Promotion.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTitleproduct_Internalname, "Product", "", "", lblTitleproduct_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridpromotion_product( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridpromotion_product( )
      {
         /*  Grid Control  */
         StartGridControl63( ) ;
         nGXsfl_63_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount11 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_11 = 1;
               ScanStart0811( ) ;
               while ( RcdFound11 != 0 )
               {
                  init_level_properties11( ) ;
                  getByPrimaryKey0811( ) ;
                  AddRow0811( ) ;
                  ScanNext0811( ) ;
               }
               ScanEnd0811( ) ;
               nBlankRcdCount11 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0811( ) ;
            standaloneModal0811( ) ;
            sMode11 = Gx_mode;
            while ( nGXsfl_63_idx < nRC_GXsfl_63 )
            {
               bGXsfl_63_Refreshing = true;
               ReadRow0811( ) ;
               edtProductId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_63_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtProductName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_63_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtProductDescription_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTDESCRIPTION_"+sGXsfl_63_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductDescription_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtCategoryName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORYNAME_"+sGXsfl_63_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCategoryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryName_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               imgprompt_10_Link = cgiGet( "PROMPT_10_"+sGXsfl_63_idx+"Link");
               if ( ( nRcdExists_11 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0811( ) ;
               }
               SendRow0811( ) ;
               bGXsfl_63_Refreshing = false;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount11 = 5;
            nRcdExists_11 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0811( ) ;
               while ( RcdFound11 != 0 )
               {
                  sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_6311( ) ;
                  init_level_properties11( ) ;
                  standaloneNotModal0811( ) ;
                  getByPrimaryKey0811( ) ;
                  standaloneModal0811( ) ;
                  AddRow0811( ) ;
                  ScanNext0811( ) ;
               }
               ScanEnd0811( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode11 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
            SubsflControlProps_6311( ) ;
            InitAll0811( ) ;
            init_level_properties11( ) ;
            nRcdExists_11 = 0;
            nIsMod_11 = 0;
            nRcdDeleted_11 = 0;
            nBlankRcdCount11 = (short)(nBlankRcdUsr11+nBlankRcdCount11);
            fRowAdded = 0;
            while ( nBlankRcdCount11 > 0 )
            {
               standaloneNotModal0811( ) ;
               standaloneModal0811( ) ;
               AddRow0811( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount11 = (short)(nBlankRcdCount11-1);
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridpromotion_productContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpromotion_product", Gridpromotion_productContainer, subGridpromotion_product_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpromotion_productContainerData", Gridpromotion_productContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpromotion_productContainerData"+"V", Gridpromotion_productContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridpromotion_productContainerData"+"V"+"\" value='"+Gridpromotion_productContainer.GridValuesHidden()+"'/>") ;
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
         E11082 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z26PromotionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z26PromotionId"), ",", "."), 18, MidpointRounding.ToEven));
               Z27PromotionDescription = cgiGet( "Z27PromotionDescription");
               Z29PromotionDateStart = context.localUtil.CToD( cgiGet( "Z29PromotionDateStart"), 0);
               Z30PromotionDateFinish = context.localUtil.CToD( cgiGet( "Z30PromotionDateFinish"), 0);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_63 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_63"), ",", "."), 18, MidpointRounding.ToEven));
               AV7PromotionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vPROMOTIONID"), ",", "."), 18, MidpointRounding.ToEven));
               A40000PromotionImage_GXI = cgiGet( "PROMOTIONIMAGE_GXI");
               AV11Pgmname = cgiGet( "vPGMNAME");
               A4CategoryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORYID"), ",", "."), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A26PromotionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPromotionId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A26PromotionId", StringUtil.LTrimStr( (decimal)(A26PromotionId), 4, 0));
               A27PromotionDescription = cgiGet( edtPromotionDescription_Internalname);
               AssignAttri("", false, "A27PromotionDescription", A27PromotionDescription);
               A28PromotionImage = cgiGet( imgPromotionImage_Internalname);
               AssignAttri("", false, "A28PromotionImage", A28PromotionImage);
               if ( context.localUtil.VCDate( cgiGet( edtPromotionDateStart_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Promotion Date Start"}), 1, "PROMOTIONDATESTART");
                  AnyError = 1;
                  GX_FocusControl = edtPromotionDateStart_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A29PromotionDateStart = DateTime.MinValue;
                  AssignAttri("", false, "A29PromotionDateStart", context.localUtil.Format(A29PromotionDateStart, "99/99/99"));
               }
               else
               {
                  A29PromotionDateStart = context.localUtil.CToD( cgiGet( edtPromotionDateStart_Internalname), 2);
                  AssignAttri("", false, "A29PromotionDateStart", context.localUtil.Format(A29PromotionDateStart, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtPromotionDateFinish_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Promotion Date Finish"}), 1, "PROMOTIONDATEFINISH");
                  AnyError = 1;
                  GX_FocusControl = edtPromotionDateFinish_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A30PromotionDateFinish = DateTime.MinValue;
                  AssignAttri("", false, "A30PromotionDateFinish", context.localUtil.Format(A30PromotionDateFinish, "99/99/99"));
               }
               else
               {
                  A30PromotionDateFinish = context.localUtil.CToD( cgiGet( edtPromotionDateFinish_Internalname), 2);
                  AssignAttri("", false, "A30PromotionDateFinish", context.localUtil.Format(A30PromotionDateFinish, "99/99/99"));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgPromotionImage_Internalname, ref  A28PromotionImage, ref  A40000PromotionImage_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Promotion");
               A26PromotionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPromotionId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A26PromotionId", StringUtil.LTrimStr( (decimal)(A26PromotionId), 4, 0));
               forbiddenHiddens.Add("PromotionId", context.localUtil.Format( (decimal)(A26PromotionId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A26PromotionId != Z26PromotionId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("promotion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A26PromotionId = (short)(Math.Round(NumberUtil.Val( GetPar( "PromotionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A26PromotionId", StringUtil.LTrimStr( (decimal)(A26PromotionId), 4, 0));
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
                     sMode8 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode8;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound8 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_080( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PROMOTIONID");
                        AnyError = 1;
                        GX_FocusControl = edtPromotionId_Internalname;
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
                           E11082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12082 ();
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
            E12082 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll088( ) ;
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
            DisableAttributes088( ) ;
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

      protected void CONFIRM_080( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls088( ) ;
            }
            else
            {
               CheckExtendedTable088( ) ;
               CloseExtendedTableCursors088( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode8 = Gx_mode;
            CONFIRM_0811( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode8;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0811( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow0811( ) ;
            if ( ( nRcdExists_11 != 0 ) || ( nIsMod_11 != 0 ) )
            {
               GetKey0811( ) ;
               if ( ( nRcdExists_11 == 0 ) && ( nRcdDeleted_11 == 0 ) )
               {
                  if ( RcdFound11 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0811( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0811( ) ;
                        CloseExtendedTableCursors0811( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProductId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound11 != 0 )
                  {
                     if ( nRcdDeleted_11 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0811( ) ;
                        Load0811( ) ;
                        BeforeValidate0811( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0811( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_11 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0811( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0811( ) ;
                              CloseExtendedTableCursors0811( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_11 == 0 )
                     {
                        GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
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
            ChangePostValue( edtCategoryName_Internalname, A5CategoryName) ;
            ChangePostValue( "ZT_"+"Z10ProductId_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ProductId), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_11_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_11), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_11_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_11), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_11_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_11), 4, 0, ",", ""))) ;
            if ( nIsMod_11 != 0 )
            {
               ChangePostValue( "PRODUCTID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTDESCRIPTION_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductDescription_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORYNAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption080( )
      {
      }

      protected void E11082( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12082( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwpromotion.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM088( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z27PromotionDescription = T00087_A27PromotionDescription[0];
               Z29PromotionDateStart = T00087_A29PromotionDateStart[0];
               Z30PromotionDateFinish = T00087_A30PromotionDateFinish[0];
            }
            else
            {
               Z27PromotionDescription = A27PromotionDescription;
               Z29PromotionDateStart = A29PromotionDateStart;
               Z30PromotionDateFinish = A30PromotionDateFinish;
            }
         }
         if ( GX_JID == -6 )
         {
            Z26PromotionId = A26PromotionId;
            Z27PromotionDescription = A27PromotionDescription;
            Z28PromotionImage = A28PromotionImage;
            Z40000PromotionImage_GXI = A40000PromotionImage_GXI;
            Z29PromotionDateStart = A29PromotionDateStart;
            Z30PromotionDateFinish = A30PromotionDateFinish;
         }
      }

      protected void standaloneNotModal( )
      {
         edtPromotionId_Enabled = 0;
         AssignProp("", false, edtPromotionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromotionId_Enabled), 5, 0), true);
         edtPromotionId_Enabled = 0;
         AssignProp("", false, edtPromotionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromotionId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7PromotionId) )
         {
            A26PromotionId = AV7PromotionId;
            AssignAttri("", false, "A26PromotionId", StringUtil.LTrimStr( (decimal)(A26PromotionId), 4, 0));
         }
      }

      protected void standaloneModal( )
      {
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
      }

      protected void Load088( )
      {
         /* Using cursor T00088 */
         pr_default.execute(6, new Object[] {A26PromotionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound8 = 1;
            A27PromotionDescription = T00088_A27PromotionDescription[0];
            AssignAttri("", false, "A27PromotionDescription", A27PromotionDescription);
            A40000PromotionImage_GXI = T00088_A40000PromotionImage_GXI[0];
            AssignProp("", false, imgPromotionImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28PromotionImage)) ? A40000PromotionImage_GXI : context.convertURL( context.PathToRelativeUrl( A28PromotionImage))), true);
            AssignProp("", false, imgPromotionImage_Internalname, "SrcSet", context.GetImageSrcSet( A28PromotionImage), true);
            A29PromotionDateStart = T00088_A29PromotionDateStart[0];
            AssignAttri("", false, "A29PromotionDateStart", context.localUtil.Format(A29PromotionDateStart, "99/99/99"));
            A30PromotionDateFinish = T00088_A30PromotionDateFinish[0];
            AssignAttri("", false, "A30PromotionDateFinish", context.localUtil.Format(A30PromotionDateFinish, "99/99/99"));
            A28PromotionImage = T00088_A28PromotionImage[0];
            AssignAttri("", false, "A28PromotionImage", A28PromotionImage);
            AssignProp("", false, imgPromotionImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28PromotionImage)) ? A40000PromotionImage_GXI : context.convertURL( context.PathToRelativeUrl( A28PromotionImage))), true);
            AssignProp("", false, imgPromotionImage_Internalname, "SrcSet", context.GetImageSrcSet( A28PromotionImage), true);
            ZM088( -6) ;
         }
         pr_default.close(6);
         OnLoadActions088( ) ;
      }

      protected void OnLoadActions088( )
      {
         AV11Pgmname = "Promotion";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable088( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "Promotion";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         if ( ! ( (DateTime.MinValue==A29PromotionDateStart) || ( DateTimeUtil.ResetTime ( A29PromotionDateStart ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Promotion Date Start fuera de rango", "OutOfRange", 1, "PROMOTIONDATESTART");
            AnyError = 1;
            GX_FocusControl = edtPromotionDateStart_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( DateTimeUtil.ResetTime ( A29PromotionDateStart ) > DateTimeUtil.ResetTime ( A30PromotionDateFinish ) )
         {
            GX_msglist.addItem("La fecha de inicio no puede ser mayor a la fecha de finalización", 1, "PROMOTIONDATESTART");
            AnyError = 1;
            GX_FocusControl = edtPromotionDateStart_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A30PromotionDateFinish) || ( DateTimeUtil.ResetTime ( A30PromotionDateFinish ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Promotion Date Finish fuera de rango", "OutOfRange", 1, "PROMOTIONDATEFINISH");
            AnyError = 1;
            GX_FocusControl = edtPromotionDateFinish_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors088( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey088( )
      {
         /* Using cursor T00089 */
         pr_default.execute(7, new Object[] {A26PromotionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00087 */
         pr_default.execute(5, new Object[] {A26PromotionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM088( 6) ;
            RcdFound8 = 1;
            A26PromotionId = T00087_A26PromotionId[0];
            AssignAttri("", false, "A26PromotionId", StringUtil.LTrimStr( (decimal)(A26PromotionId), 4, 0));
            A27PromotionDescription = T00087_A27PromotionDescription[0];
            AssignAttri("", false, "A27PromotionDescription", A27PromotionDescription);
            A40000PromotionImage_GXI = T00087_A40000PromotionImage_GXI[0];
            AssignProp("", false, imgPromotionImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28PromotionImage)) ? A40000PromotionImage_GXI : context.convertURL( context.PathToRelativeUrl( A28PromotionImage))), true);
            AssignProp("", false, imgPromotionImage_Internalname, "SrcSet", context.GetImageSrcSet( A28PromotionImage), true);
            A29PromotionDateStart = T00087_A29PromotionDateStart[0];
            AssignAttri("", false, "A29PromotionDateStart", context.localUtil.Format(A29PromotionDateStart, "99/99/99"));
            A30PromotionDateFinish = T00087_A30PromotionDateFinish[0];
            AssignAttri("", false, "A30PromotionDateFinish", context.localUtil.Format(A30PromotionDateFinish, "99/99/99"));
            A28PromotionImage = T00087_A28PromotionImage[0];
            AssignAttri("", false, "A28PromotionImage", A28PromotionImage);
            AssignProp("", false, imgPromotionImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28PromotionImage)) ? A40000PromotionImage_GXI : context.convertURL( context.PathToRelativeUrl( A28PromotionImage))), true);
            AssignProp("", false, imgPromotionImage_Internalname, "SrcSet", context.GetImageSrcSet( A28PromotionImage), true);
            Z26PromotionId = A26PromotionId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load088( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey088( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey088( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey088( ) ;
         if ( RcdFound8 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound8 = 0;
         /* Using cursor T000810 */
         pr_default.execute(8, new Object[] {A26PromotionId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000810_A26PromotionId[0] < A26PromotionId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000810_A26PromotionId[0] > A26PromotionId ) ) )
            {
               A26PromotionId = T000810_A26PromotionId[0];
               AssignAttri("", false, "A26PromotionId", StringUtil.LTrimStr( (decimal)(A26PromotionId), 4, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T000811 */
         pr_default.execute(9, new Object[] {A26PromotionId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000811_A26PromotionId[0] > A26PromotionId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000811_A26PromotionId[0] < A26PromotionId ) ) )
            {
               A26PromotionId = T000811_A26PromotionId[0];
               AssignAttri("", false, "A26PromotionId", StringUtil.LTrimStr( (decimal)(A26PromotionId), 4, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey088( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPromotionDescription_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert088( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A26PromotionId != Z26PromotionId )
               {
                  A26PromotionId = Z26PromotionId;
                  AssignAttri("", false, "A26PromotionId", StringUtil.LTrimStr( (decimal)(A26PromotionId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROMOTIONID");
                  AnyError = 1;
                  GX_FocusControl = edtPromotionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPromotionDescription_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update088( ) ;
                  GX_FocusControl = edtPromotionDescription_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A26PromotionId != Z26PromotionId )
               {
                  /* Insert record */
                  GX_FocusControl = edtPromotionDescription_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert088( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROMOTIONID");
                     AnyError = 1;
                     GX_FocusControl = edtPromotionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPromotionDescription_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert088( ) ;
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
         if ( A26PromotionId != Z26PromotionId )
         {
            A26PromotionId = Z26PromotionId;
            AssignAttri("", false, "A26PromotionId", StringUtil.LTrimStr( (decimal)(A26PromotionId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROMOTIONID");
            AnyError = 1;
            GX_FocusControl = edtPromotionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPromotionDescription_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency088( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00086 */
            pr_default.execute(4, new Object[] {A26PromotionId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Promotion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z27PromotionDescription, T00086_A27PromotionDescription[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z29PromotionDateStart ) != DateTimeUtil.ResetTime ( T00086_A29PromotionDateStart[0] ) ) || ( DateTimeUtil.ResetTime ( Z30PromotionDateFinish ) != DateTimeUtil.ResetTime ( T00086_A30PromotionDateFinish[0] ) ) )
            {
               if ( StringUtil.StrCmp(Z27PromotionDescription, T00086_A27PromotionDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("promotion:[seudo value changed for attri]"+"PromotionDescription");
                  GXUtil.WriteLogRaw("Old: ",Z27PromotionDescription);
                  GXUtil.WriteLogRaw("Current: ",T00086_A27PromotionDescription[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z29PromotionDateStart ) != DateTimeUtil.ResetTime ( T00086_A29PromotionDateStart[0] ) )
               {
                  GXUtil.WriteLog("promotion:[seudo value changed for attri]"+"PromotionDateStart");
                  GXUtil.WriteLogRaw("Old: ",Z29PromotionDateStart);
                  GXUtil.WriteLogRaw("Current: ",T00086_A29PromotionDateStart[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z30PromotionDateFinish ) != DateTimeUtil.ResetTime ( T00086_A30PromotionDateFinish[0] ) )
               {
                  GXUtil.WriteLog("promotion:[seudo value changed for attri]"+"PromotionDateFinish");
                  GXUtil.WriteLogRaw("Old: ",Z30PromotionDateFinish);
                  GXUtil.WriteLogRaw("Current: ",T00086_A30PromotionDateFinish[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Promotion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM088( 0) ;
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000812 */
                     pr_default.execute(10, new Object[] {A27PromotionDescription, A28PromotionImage, A40000PromotionImage_GXI, A29PromotionDateStart, A30PromotionDateFinish});
                     A26PromotionId = T000812_A26PromotionId[0];
                     AssignAttri("", false, "A26PromotionId", StringUtil.LTrimStr( (decimal)(A26PromotionId), 4, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Promotion");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel088( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption080( ) ;
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
               Load088( ) ;
            }
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void Update088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000813 */
                     pr_default.execute(11, new Object[] {A27PromotionDescription, A29PromotionDateStart, A30PromotionDateFinish, A26PromotionId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Promotion");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Promotion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate088( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel088( ) ;
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
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void DeferredUpdate088( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000814 */
            pr_default.execute(12, new Object[] {A28PromotionImage, A40000PromotionImage_GXI, A26PromotionId});
            pr_default.close(12);
            pr_default.SmartCacheProvider.SetUpdated("Promotion");
         }
      }

      protected void delete( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls088( ) ;
            AfterConfirm088( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete088( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0811( ) ;
                  while ( RcdFound11 != 0 )
                  {
                     getByPrimaryKey0811( ) ;
                     Delete0811( ) ;
                     ScanNext0811( ) ;
                  }
                  ScanEnd0811( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000815 */
                     pr_default.execute(13, new Object[] {A26PromotionId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Promotion");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel088( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls088( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "Promotion";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
      }

      protected void ProcessNestedLevel0811( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow0811( ) ;
            if ( ( nRcdExists_11 != 0 ) || ( nIsMod_11 != 0 ) )
            {
               standaloneNotModal0811( ) ;
               GetKey0811( ) ;
               if ( ( nRcdExists_11 == 0 ) && ( nRcdDeleted_11 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0811( ) ;
               }
               else
               {
                  if ( RcdFound11 != 0 )
                  {
                     if ( ( nRcdDeleted_11 != 0 ) && ( nRcdExists_11 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0811( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_11 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0811( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_11 == 0 )
                     {
                        GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
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
            ChangePostValue( edtCategoryName_Internalname, A5CategoryName) ;
            ChangePostValue( "ZT_"+"Z10ProductId_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ProductId), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_11_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_11), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_11_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_11), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_11_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_11), 4, 0, ",", ""))) ;
            if ( nIsMod_11 != 0 )
            {
               ChangePostValue( "PRODUCTID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTDESCRIPTION_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductDescription_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORYNAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0811( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_11 = 0;
         nIsMod_11 = 0;
         nRcdDeleted_11 = 0;
      }

      protected void ProcessLevel088( )
      {
         /* Save parent mode. */
         sMode8 = Gx_mode;
         ProcessNestedLevel0811( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel088( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete088( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("promotion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues080( ) ;
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
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("promotion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart088( )
      {
         /* Scan By routine */
         /* Using cursor T000816 */
         pr_default.execute(14);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound8 = 1;
            A26PromotionId = T000816_A26PromotionId[0];
            AssignAttri("", false, "A26PromotionId", StringUtil.LTrimStr( (decimal)(A26PromotionId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext088( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound8 = 1;
            A26PromotionId = T000816_A26PromotionId[0];
            AssignAttri("", false, "A26PromotionId", StringUtil.LTrimStr( (decimal)(A26PromotionId), 4, 0));
         }
      }

      protected void ScanEnd088( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm088( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert088( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate088( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete088( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete088( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate088( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes088( )
      {
         edtPromotionId_Enabled = 0;
         AssignProp("", false, edtPromotionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromotionId_Enabled), 5, 0), true);
         edtPromotionDescription_Enabled = 0;
         AssignProp("", false, edtPromotionDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromotionDescription_Enabled), 5, 0), true);
         imgPromotionImage_Enabled = 0;
         AssignProp("", false, imgPromotionImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgPromotionImage_Enabled), 5, 0), true);
         edtPromotionDateStart_Enabled = 0;
         AssignProp("", false, edtPromotionDateStart_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromotionDateStart_Enabled), 5, 0), true);
         edtPromotionDateFinish_Enabled = 0;
         AssignProp("", false, edtPromotionDateFinish_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromotionDateFinish_Enabled), 5, 0), true);
      }

      protected void ZM0811( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -7 )
         {
            Z26PromotionId = A26PromotionId;
            Z10ProductId = A10ProductId;
            Z4CategoryId = A4CategoryId;
            Z11ProductName = A11ProductName;
            Z12ProductDescription = A12ProductDescription;
            Z5CategoryName = A5CategoryName;
         }
      }

      protected void standaloneNotModal0811( )
      {
      }

      protected void standaloneModal0811( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProductId_Enabled = 0;
            AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
         else
         {
            edtProductId_Enabled = 1;
            AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
      }

      protected void Load0811( )
      {
         /* Using cursor T000817 */
         pr_default.execute(15, new Object[] {A26PromotionId, A10ProductId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound11 = 1;
            A4CategoryId = T000817_A4CategoryId[0];
            A11ProductName = T000817_A11ProductName[0];
            A12ProductDescription = T000817_A12ProductDescription[0];
            A5CategoryName = T000817_A5CategoryName[0];
            ZM0811( -7) ;
         }
         pr_default.close(15);
         OnLoadActions0811( ) ;
      }

      protected void OnLoadActions0811( )
      {
      }

      protected void CheckExtendedTable0811( )
      {
         nIsDirty_11 = 0;
         Gx_BScreen = 1;
         standaloneModal0811( ) ;
         /* Using cursor T00084 */
         pr_default.execute(2, new Object[] {A10ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
            GX_msglist.addItem("No existe 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A4CategoryId = T00084_A4CategoryId[0];
         A11ProductName = T00084_A11ProductName[0];
         A12ProductDescription = T00084_A12ProductDescription[0];
         pr_default.close(2);
         /* Using cursor T00085 */
         pr_default.execute(3, new Object[] {A4CategoryId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
         }
         A5CategoryName = T00085_A5CategoryName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0811( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0811( )
      {
      }

      protected void gxLoad_8( short A10ProductId )
      {
         /* Using cursor T000818 */
         pr_default.execute(16, new Object[] {A10ProductId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
            GX_msglist.addItem("No existe 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A4CategoryId = T000818_A4CategoryId[0];
         A11ProductName = T000818_A11ProductName[0];
         A12ProductDescription = T000818_A12ProductDescription[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoryId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A11ProductName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A12ProductDescription)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_9( short A4CategoryId )
      {
         /* Using cursor T000819 */
         pr_default.execute(17, new Object[] {A4CategoryId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
         }
         A5CategoryName = T000819_A5CategoryName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A5CategoryName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void GetKey0811( )
      {
         /* Using cursor T000820 */
         pr_default.execute(18, new Object[] {A26PromotionId, A10ProductId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(18);
      }

      protected void getByPrimaryKey0811( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {A26PromotionId, A10ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0811( 7) ;
            RcdFound11 = 1;
            InitializeNonKey0811( ) ;
            A10ProductId = T00083_A10ProductId[0];
            Z26PromotionId = A26PromotionId;
            Z10ProductId = A10ProductId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0811( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0811( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0811( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0811( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0811( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00082 */
            pr_default.execute(0, new Object[] {A26PromotionId, A10ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PromotionProduct"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PromotionProduct"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0811( )
      {
         BeforeValidate0811( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0811( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0811( 0) ;
            CheckOptimisticConcurrency0811( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0811( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0811( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000821 */
                     pr_default.execute(19, new Object[] {A26PromotionId, A10ProductId});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("PromotionProduct");
                     if ( (pr_default.getStatus(19) == 1) )
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
               Load0811( ) ;
            }
            EndLevel0811( ) ;
         }
         CloseExtendedTableCursors0811( ) ;
      }

      protected void Update0811( )
      {
         BeforeValidate0811( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0811( ) ;
         }
         if ( ( nIsMod_11 != 0 ) || ( nIsDirty_11 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0811( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0811( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0811( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [PromotionProduct] */
                        DeferredUpdate0811( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0811( ) ;
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
               EndLevel0811( ) ;
            }
         }
         CloseExtendedTableCursors0811( ) ;
      }

      protected void DeferredUpdate0811( )
      {
      }

      protected void Delete0811( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0811( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0811( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0811( ) ;
            AfterConfirm0811( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0811( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000822 */
                  pr_default.execute(20, new Object[] {A26PromotionId, A10ProductId});
                  pr_default.close(20);
                  pr_default.SmartCacheProvider.SetUpdated("PromotionProduct");
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0811( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0811( )
      {
         standaloneModal0811( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000823 */
            pr_default.execute(21, new Object[] {A10ProductId});
            A4CategoryId = T000823_A4CategoryId[0];
            A11ProductName = T000823_A11ProductName[0];
            A12ProductDescription = T000823_A12ProductDescription[0];
            pr_default.close(21);
            /* Using cursor T000824 */
            pr_default.execute(22, new Object[] {A4CategoryId});
            A5CategoryName = T000824_A5CategoryName[0];
            pr_default.close(22);
         }
      }

      protected void EndLevel0811( )
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

      public void ScanStart0811( )
      {
         /* Scan By routine */
         /* Using cursor T000825 */
         pr_default.execute(23, new Object[] {A26PromotionId});
         RcdFound11 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound11 = 1;
            A10ProductId = T000825_A10ProductId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0811( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound11 = 1;
            A10ProductId = T000825_A10ProductId[0];
         }
      }

      protected void ScanEnd0811( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm0811( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0811( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0811( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0811( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0811( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0811( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0811( )
      {
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtProductDescription_Enabled = 0;
         AssignProp("", false, edtProductDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductDescription_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtCategoryName_Enabled = 0;
         AssignProp("", false, edtCategoryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryName_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void send_integrity_lvl_hashes0811( )
      {
      }

      protected void send_integrity_lvl_hashes088( )
      {
      }

      protected void SubsflControlProps_6311( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_63_idx;
         imgprompt_10_Internalname = "PROMPT_10_"+sGXsfl_63_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_63_idx;
         edtProductDescription_Internalname = "PRODUCTDESCRIPTION_"+sGXsfl_63_idx;
         edtCategoryName_Internalname = "CATEGORYNAME_"+sGXsfl_63_idx;
      }

      protected void SubsflControlProps_fel_6311( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_63_fel_idx;
         imgprompt_10_Internalname = "PROMPT_10_"+sGXsfl_63_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_63_fel_idx;
         edtProductDescription_Internalname = "PRODUCTDESCRIPTION_"+sGXsfl_63_fel_idx;
         edtCategoryName_Internalname = "CATEGORYNAME_"+sGXsfl_63_fel_idx;
      }

      protected void AddRow0811( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_6311( ) ;
         SendRow0811( ) ;
      }

      protected void SendRow0811( )
      {
         Gridpromotion_productRow = GXWebRow.GetNew(context);
         if ( subGridpromotion_product_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridpromotion_product_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridpromotion_product_Class, "") != 0 )
            {
               subGridpromotion_product_Linesclass = subGridpromotion_product_Class+"Odd";
            }
         }
         else if ( subGridpromotion_product_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridpromotion_product_Backstyle = 0;
            subGridpromotion_product_Backcolor = subGridpromotion_product_Allbackcolor;
            if ( StringUtil.StrCmp(subGridpromotion_product_Class, "") != 0 )
            {
               subGridpromotion_product_Linesclass = subGridpromotion_product_Class+"Uniform";
            }
         }
         else if ( subGridpromotion_product_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridpromotion_product_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridpromotion_product_Class, "") != 0 )
            {
               subGridpromotion_product_Linesclass = subGridpromotion_product_Class+"Odd";
            }
            subGridpromotion_product_Backcolor = (int)(0x0);
         }
         else if ( subGridpromotion_product_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridpromotion_product_Backstyle = 1;
            if ( ((int)((nGXsfl_63_idx) % (2))) == 0 )
            {
               subGridpromotion_product_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpromotion_product_Class, "") != 0 )
               {
                  subGridpromotion_product_Linesclass = subGridpromotion_product_Class+"Even";
               }
            }
            else
            {
               subGridpromotion_product_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpromotion_product_Class, "") != 0 )
               {
                  subGridpromotion_product_Linesclass = subGridpromotion_product_Class+"Odd";
               }
            }
         }
         imgprompt_10_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTID_"+sGXsfl_63_idx+"'), id:'"+"PRODUCTID_"+sGXsfl_63_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_11_"+sGXsfl_63_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_11_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridpromotion_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A10ProductId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)63,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_10_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_10_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridpromotion_productRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_10_Internalname,(string)sImgUrl,(string)imgprompt_10_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_10_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_11_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridpromotion_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,(string)A11ProductName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)63,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_11_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridpromotion_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductDescription_Internalname,(string)A12ProductDescription,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductDescription_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)63,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_11_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridpromotion_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoryName_Internalname,(string)A5CategoryName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoryName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCategoryName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)63,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridpromotion_productRow);
         send_integrity_lvl_hashes0811( ) ;
         GXCCtl = "Z10ProductId_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ProductId), 4, 0, ",", "")));
         GXCCtl = "nRcdDeleted_11_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_11), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_11_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_11), 4, 0, ",", "")));
         GXCCtl = "nIsMod_11_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_11), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_63_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vPROMOTIONID_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PromotionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTDESCRIPTION_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductDescription_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CATEGORYNAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_10_"+sGXsfl_63_idx+"Link", StringUtil.RTrim( imgprompt_10_Link));
         ajax_sending_grid_row(null);
         Gridpromotion_productContainer.AddRow(Gridpromotion_productRow);
      }

      protected void ReadRow0811( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_6311( ) ;
         edtProductId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_63_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtProductName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_63_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtProductDescription_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTDESCRIPTION_"+sGXsfl_63_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtCategoryName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORYNAME_"+sGXsfl_63_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         imgprompt_10_Link = cgiGet( "PROMPT_10_"+sGXsfl_63_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
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
         A5CategoryName = cgiGet( edtCategoryName_Internalname);
         GXCCtl = "Z10ProductId_" + sGXsfl_63_idx;
         Z10ProductId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_11_" + sGXsfl_63_idx;
         nRcdDeleted_11 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_11_" + sGXsfl_63_idx;
         nRcdExists_11 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_11_" + sGXsfl_63_idx;
         nIsMod_11 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtProductId_Enabled = edtProductId_Enabled;
      }

      protected void ConfirmValues080( )
      {
         nGXsfl_63_idx = 0;
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_6311( ) ;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_6311( ) ;
            ChangePostValue( "Z10ProductId_"+sGXsfl_63_idx, cgiGet( "ZT_"+"Z10ProductId_"+sGXsfl_63_idx)) ;
            DeletePostValue( "ZT_"+"Z10ProductId_"+sGXsfl_63_idx) ;
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("promotion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7PromotionId,4,0))}, new string[] {"Gx_mode","PromotionId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Promotion");
         forbiddenHiddens.Add("PromotionId", context.localUtil.Format( (decimal)(A26PromotionId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("promotion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z26PromotionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26PromotionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z27PromotionDescription", Z27PromotionDescription);
         GxWebStd.gx_hidden_field( context, "Z29PromotionDateStart", context.localUtil.DToC( Z29PromotionDateStart, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z30PromotionDateFinish", context.localUtil.DToC( Z30PromotionDateFinish, 0, "/"));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_63", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_63_idx), 8, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vPROMOTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PromotionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PromotionId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROMOTIONIMAGE_GXI", A40000PromotionImage_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV11Pgmname));
         GxWebStd.gx_hidden_field( context, "CATEGORYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoryId), 4, 0, ",", "")));
         GXCCtlgxBlob = "PROMOTIONIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A28PromotionImage);
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
         return formatLink("promotion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7PromotionId,4,0))}, new string[] {"Gx_mode","PromotionId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Promotion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Promotion" ;
      }

      protected void InitializeNonKey088( )
      {
         A27PromotionDescription = "";
         AssignAttri("", false, "A27PromotionDescription", A27PromotionDescription);
         A28PromotionImage = "";
         AssignAttri("", false, "A28PromotionImage", A28PromotionImage);
         AssignProp("", false, imgPromotionImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28PromotionImage)) ? A40000PromotionImage_GXI : context.convertURL( context.PathToRelativeUrl( A28PromotionImage))), true);
         AssignProp("", false, imgPromotionImage_Internalname, "SrcSet", context.GetImageSrcSet( A28PromotionImage), true);
         A40000PromotionImage_GXI = "";
         AssignProp("", false, imgPromotionImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28PromotionImage)) ? A40000PromotionImage_GXI : context.convertURL( context.PathToRelativeUrl( A28PromotionImage))), true);
         AssignProp("", false, imgPromotionImage_Internalname, "SrcSet", context.GetImageSrcSet( A28PromotionImage), true);
         A29PromotionDateStart = DateTime.MinValue;
         AssignAttri("", false, "A29PromotionDateStart", context.localUtil.Format(A29PromotionDateStart, "99/99/99"));
         A30PromotionDateFinish = DateTime.MinValue;
         AssignAttri("", false, "A30PromotionDateFinish", context.localUtil.Format(A30PromotionDateFinish, "99/99/99"));
         Z27PromotionDescription = "";
         Z29PromotionDateStart = DateTime.MinValue;
         Z30PromotionDateFinish = DateTime.MinValue;
      }

      protected void InitAll088( )
      {
         A26PromotionId = 0;
         AssignAttri("", false, "A26PromotionId", StringUtil.LTrimStr( (decimal)(A26PromotionId), 4, 0));
         InitializeNonKey088( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0811( )
      {
         A4CategoryId = 0;
         AssignAttri("", false, "A4CategoryId", StringUtil.LTrimStr( (decimal)(A4CategoryId), 4, 0));
         A11ProductName = "";
         A12ProductDescription = "";
         A5CategoryName = "";
      }

      protected void InitAll0811( )
      {
         A10ProductId = 0;
         InitializeNonKey0811( ) ;
      }

      protected void StandaloneModalInsert0811( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024102517242517", true, true);
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
         context.AddJavascriptSource("promotion.js", "?2024102517242517", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties11( )
      {
         edtProductId_Enabled = defedtProductId_Enabled;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void StartGridControl63( )
      {
         Gridpromotion_productContainer.AddObjectProperty("GridName", "Gridpromotion_product");
         Gridpromotion_productContainer.AddObjectProperty("Header", subGridpromotion_product_Header);
         Gridpromotion_productContainer.AddObjectProperty("Class", "Grid");
         Gridpromotion_productContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Backcolorstyle), 1, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("CmpContext", "");
         Gridpromotion_productContainer.AddObjectProperty("InMasterPage", "false");
         Gridpromotion_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpromotion_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductId), 4, 0, ".", ""))));
         Gridpromotion_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         Gridpromotion_productContainer.AddColumnProperties(Gridpromotion_productColumn);
         Gridpromotion_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpromotion_productContainer.AddColumnProperties(Gridpromotion_productColumn);
         Gridpromotion_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpromotion_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11ProductName));
         Gridpromotion_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         Gridpromotion_productContainer.AddColumnProperties(Gridpromotion_productColumn);
         Gridpromotion_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpromotion_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A12ProductDescription));
         Gridpromotion_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductDescription_Enabled), 5, 0, ".", "")));
         Gridpromotion_productContainer.AddColumnProperties(Gridpromotion_productColumn);
         Gridpromotion_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpromotion_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A5CategoryName));
         Gridpromotion_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryName_Enabled), 5, 0, ".", "")));
         Gridpromotion_productContainer.AddColumnProperties(Gridpromotion_productColumn);
         Gridpromotion_productContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Selectedindex), 4, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Allowselection), 1, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Selectioncolor), 9, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Allowhovering), 1, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Hoveringcolor), 9, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Allowcollapsing), 1, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Collapsed), 1, 0, ".", "")));
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
         edtPromotionId_Internalname = "PROMOTIONID";
         edtPromotionDescription_Internalname = "PROMOTIONDESCRIPTION";
         imgPromotionImage_Internalname = "PROMOTIONIMAGE";
         edtPromotionDateStart_Internalname = "PROMOTIONDATESTART";
         edtPromotionDateFinish_Internalname = "PROMOTIONDATEFINISH";
         lblTitleproduct_Internalname = "TITLEPRODUCT";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductDescription_Internalname = "PRODUCTDESCRIPTION";
         edtCategoryName_Internalname = "CATEGORYNAME";
         divProducttable_Internalname = "PRODUCTTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_10_Internalname = "PROMPT_10";
         subGridpromotion_product_Internalname = "GRIDPROMOTION_PRODUCT";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("ObligatorioShop", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridpromotion_product_Allowcollapsing = 0;
         subGridpromotion_product_Allowselection = 0;
         subGridpromotion_product_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Promotion";
         edtCategoryName_Jsonclick = "";
         edtProductDescription_Jsonclick = "";
         edtProductName_Jsonclick = "";
         imgprompt_10_Visible = 1;
         imgprompt_10_Link = "";
         imgprompt_10_Visible = 1;
         edtProductId_Jsonclick = "";
         subGridpromotion_product_Class = "Grid";
         subGridpromotion_product_Backcolorstyle = 0;
         edtCategoryName_Enabled = 0;
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
         edtPromotionDateFinish_Jsonclick = "";
         edtPromotionDateFinish_Enabled = 1;
         edtPromotionDateStart_Jsonclick = "";
         edtPromotionDateStart_Enabled = 1;
         imgPromotionImage_Enabled = 1;
         edtPromotionDescription_Enabled = 1;
         edtPromotionId_Jsonclick = "";
         edtPromotionId_Enabled = 0;
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

      protected void gxnrGridpromotion_product_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_6311( ) ;
         while ( nGXsfl_63_idx <= nRC_GXsfl_63 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0811( ) ;
            standaloneModal0811( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0811( ) ;
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_6311( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridpromotion_productContainer)) ;
         /* End function gxnrGridpromotion_product_newrow */
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

      public void Valid_Productid( )
      {
         /* Using cursor T000823 */
         pr_default.execute(21, new Object[] {A10ProductId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
         }
         A4CategoryId = T000823_A4CategoryId[0];
         A11ProductName = T000823_A11ProductName[0];
         A12ProductDescription = T000823_A12ProductDescription[0];
         pr_default.close(21);
         /* Using cursor T000824 */
         pr_default.execute(22, new Object[] {A4CategoryId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
         }
         A5CategoryName = T000824_A5CategoryName[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A4CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoryId), 4, 0, ".", "")));
         AssignAttri("", false, "A11ProductName", A11ProductName);
         AssignAttri("", false, "A12ProductDescription", A12ProductDescription);
         AssignAttri("", false, "A5CategoryName", A5CategoryName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7PromotionId","fld":"vPROMOTIONID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7PromotionId","fld":"vPROMOTIONID","pic":"ZZZ9","hsh":true},{"av":"A26PromotionId","fld":"PROMOTIONID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12082","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_PROMOTIONID","""{"handler":"Valid_Promotionid","iparms":[]}""");
         setEventMetadata("VALID_PROMOTIONDATESTART","""{"handler":"Valid_Promotiondatestart","iparms":[]}""");
         setEventMetadata("VALID_PROMOTIONDATEFINISH","""{"handler":"Valid_Promotiondatefinish","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTID","""{"handler":"Valid_Productid","iparms":[{"av":"A10ProductId","fld":"PRODUCTID","pic":"ZZZ9"},{"av":"A4CategoryId","fld":"CATEGORYID","pic":"ZZZ9"},{"av":"A11ProductName","fld":"PRODUCTNAME"},{"av":"A12ProductDescription","fld":"PRODUCTDESCRIPTION"},{"av":"A5CategoryName","fld":"CATEGORYNAME"}]""");
         setEventMetadata("VALID_PRODUCTID",""","oparms":[{"av":"A4CategoryId","fld":"CATEGORYID","pic":"ZZZ9"},{"av":"A11ProductName","fld":"PRODUCTNAME"},{"av":"A12ProductDescription","fld":"PRODUCTDESCRIPTION"},{"av":"A5CategoryName","fld":"CATEGORYNAME"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Categoryname","iparms":[]}""");
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
         pr_default.close(21);
         pr_default.close(22);
         pr_default.close(5);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z27PromotionDescription = "";
         Z29PromotionDateStart = DateTime.MinValue;
         Z30PromotionDateFinish = DateTime.MinValue;
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
         A27PromotionDescription = "";
         A28PromotionImage = "";
         A40000PromotionImage_GXI = "";
         sImgUrl = "";
         A29PromotionDateStart = DateTime.MinValue;
         A30PromotionDateFinish = DateTime.MinValue;
         lblTitleproduct_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridpromotion_productContainer = new GXWebGrid( context);
         sMode11 = "";
         sStyleString = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode8 = "";
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
         Z28PromotionImage = "";
         Z40000PromotionImage_GXI = "";
         T00088_A26PromotionId = new short[1] ;
         T00088_A27PromotionDescription = new string[] {""} ;
         T00088_A40000PromotionImage_GXI = new string[] {""} ;
         T00088_A29PromotionDateStart = new DateTime[] {DateTime.MinValue} ;
         T00088_A30PromotionDateFinish = new DateTime[] {DateTime.MinValue} ;
         T00088_A28PromotionImage = new string[] {""} ;
         T00089_A26PromotionId = new short[1] ;
         T00087_A26PromotionId = new short[1] ;
         T00087_A27PromotionDescription = new string[] {""} ;
         T00087_A40000PromotionImage_GXI = new string[] {""} ;
         T00087_A29PromotionDateStart = new DateTime[] {DateTime.MinValue} ;
         T00087_A30PromotionDateFinish = new DateTime[] {DateTime.MinValue} ;
         T00087_A28PromotionImage = new string[] {""} ;
         T000810_A26PromotionId = new short[1] ;
         T000811_A26PromotionId = new short[1] ;
         T00086_A26PromotionId = new short[1] ;
         T00086_A27PromotionDescription = new string[] {""} ;
         T00086_A40000PromotionImage_GXI = new string[] {""} ;
         T00086_A29PromotionDateStart = new DateTime[] {DateTime.MinValue} ;
         T00086_A30PromotionDateFinish = new DateTime[] {DateTime.MinValue} ;
         T00086_A28PromotionImage = new string[] {""} ;
         T000812_A26PromotionId = new short[1] ;
         T000816_A26PromotionId = new short[1] ;
         Z11ProductName = "";
         Z12ProductDescription = "";
         Z5CategoryName = "";
         T000817_A4CategoryId = new short[1] ;
         T000817_A26PromotionId = new short[1] ;
         T000817_A11ProductName = new string[] {""} ;
         T000817_A12ProductDescription = new string[] {""} ;
         T000817_A5CategoryName = new string[] {""} ;
         T000817_A10ProductId = new short[1] ;
         T00084_A4CategoryId = new short[1] ;
         T00084_A11ProductName = new string[] {""} ;
         T00084_A12ProductDescription = new string[] {""} ;
         T00085_A5CategoryName = new string[] {""} ;
         T000818_A4CategoryId = new short[1] ;
         T000818_A11ProductName = new string[] {""} ;
         T000818_A12ProductDescription = new string[] {""} ;
         T000819_A5CategoryName = new string[] {""} ;
         T000820_A26PromotionId = new short[1] ;
         T000820_A10ProductId = new short[1] ;
         T00083_A26PromotionId = new short[1] ;
         T00083_A10ProductId = new short[1] ;
         T00082_A26PromotionId = new short[1] ;
         T00082_A10ProductId = new short[1] ;
         T000823_A4CategoryId = new short[1] ;
         T000823_A11ProductName = new string[] {""} ;
         T000823_A12ProductDescription = new string[] {""} ;
         T000824_A5CategoryName = new string[] {""} ;
         T000825_A26PromotionId = new short[1] ;
         T000825_A10ProductId = new short[1] ;
         Gridpromotion_productRow = new GXWebRow();
         subGridpromotion_product_Linesclass = "";
         ROClassString = "";
         imgprompt_10_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         Gridpromotion_productColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.promotion__default(),
            new Object[][] {
                new Object[] {
               T00082_A26PromotionId, T00082_A10ProductId
               }
               , new Object[] {
               T00083_A26PromotionId, T00083_A10ProductId
               }
               , new Object[] {
               T00084_A4CategoryId, T00084_A11ProductName, T00084_A12ProductDescription
               }
               , new Object[] {
               T00085_A5CategoryName
               }
               , new Object[] {
               T00086_A26PromotionId, T00086_A27PromotionDescription, T00086_A40000PromotionImage_GXI, T00086_A29PromotionDateStart, T00086_A30PromotionDateFinish, T00086_A28PromotionImage
               }
               , new Object[] {
               T00087_A26PromotionId, T00087_A27PromotionDescription, T00087_A40000PromotionImage_GXI, T00087_A29PromotionDateStart, T00087_A30PromotionDateFinish, T00087_A28PromotionImage
               }
               , new Object[] {
               T00088_A26PromotionId, T00088_A27PromotionDescription, T00088_A40000PromotionImage_GXI, T00088_A29PromotionDateStart, T00088_A30PromotionDateFinish, T00088_A28PromotionImage
               }
               , new Object[] {
               T00089_A26PromotionId
               }
               , new Object[] {
               T000810_A26PromotionId
               }
               , new Object[] {
               T000811_A26PromotionId
               }
               , new Object[] {
               T000812_A26PromotionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000816_A26PromotionId
               }
               , new Object[] {
               T000817_A4CategoryId, T000817_A26PromotionId, T000817_A11ProductName, T000817_A12ProductDescription, T000817_A5CategoryName, T000817_A10ProductId
               }
               , new Object[] {
               T000818_A4CategoryId, T000818_A11ProductName, T000818_A12ProductDescription
               }
               , new Object[] {
               T000819_A5CategoryName
               }
               , new Object[] {
               T000820_A26PromotionId, T000820_A10ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000823_A4CategoryId, T000823_A11ProductName, T000823_A12ProductDescription
               }
               , new Object[] {
               T000824_A5CategoryName
               }
               , new Object[] {
               T000825_A26PromotionId, T000825_A10ProductId
               }
            }
         );
         AV11Pgmname = "Promotion";
      }

      private short nIsMod_11 ;
      private short wcpOAV7PromotionId ;
      private short Z26PromotionId ;
      private short Z10ProductId ;
      private short nRcdDeleted_11 ;
      private short nRcdExists_11 ;
      private short GxWebError ;
      private short A10ProductId ;
      private short A4CategoryId ;
      private short AV7PromotionId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A26PromotionId ;
      private short nBlankRcdCount11 ;
      private short RcdFound11 ;
      private short nBlankRcdUsr11 ;
      private short RcdFound8 ;
      private short Gx_BScreen ;
      private short Z4CategoryId ;
      private short nIsDirty_11 ;
      private short subGridpromotion_product_Backcolorstyle ;
      private short subGridpromotion_product_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridpromotion_product_Allowselection ;
      private short subGridpromotion_product_Allowhovering ;
      private short subGridpromotion_product_Allowcollapsing ;
      private short subGridpromotion_product_Collapsed ;
      private int nRC_GXsfl_63 ;
      private int nGXsfl_63_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPromotionId_Enabled ;
      private int edtPromotionDescription_Enabled ;
      private int imgPromotionImage_Enabled ;
      private int edtPromotionDateStart_Enabled ;
      private int edtPromotionDateFinish_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtProductId_Enabled ;
      private int edtProductName_Enabled ;
      private int edtProductDescription_Enabled ;
      private int edtCategoryName_Enabled ;
      private int fRowAdded ;
      private int subGridpromotion_product_Backcolor ;
      private int subGridpromotion_product_Allbackcolor ;
      private int imgprompt_10_Visible ;
      private int defedtProductId_Enabled ;
      private int idxLst ;
      private int subGridpromotion_product_Selectedindex ;
      private int subGridpromotion_product_Selectioncolor ;
      private int subGridpromotion_product_Hoveringcolor ;
      private long GRIDPROMOTION_PRODUCT_nFirstRecordOnPage ;
      private string sPrefix ;
      private string sGXsfl_63_idx="0001" ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPromotionDescription_Internalname ;
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
      private string edtPromotionId_Internalname ;
      private string edtPromotionId_Jsonclick ;
      private string imgPromotionImage_Internalname ;
      private string sImgUrl ;
      private string edtPromotionDateStart_Internalname ;
      private string edtPromotionDateStart_Jsonclick ;
      private string edtPromotionDateFinish_Internalname ;
      private string edtPromotionDateFinish_Jsonclick ;
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
      private string sMode11 ;
      private string edtProductId_Internalname ;
      private string edtProductName_Internalname ;
      private string edtProductDescription_Internalname ;
      private string edtCategoryName_Internalname ;
      private string imgprompt_10_Link ;
      private string sStyleString ;
      private string subGridpromotion_product_Internalname ;
      private string AV11Pgmname ;
      private string hsh ;
      private string sMode8 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string imgprompt_10_Internalname ;
      private string sGXsfl_63_fel_idx="0001" ;
      private string subGridpromotion_product_Class ;
      private string subGridpromotion_product_Linesclass ;
      private string ROClassString ;
      private string edtProductId_Jsonclick ;
      private string imgprompt_10_gximage ;
      private string edtProductName_Jsonclick ;
      private string edtProductDescription_Jsonclick ;
      private string edtCategoryName_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string subGridpromotion_product_Header ;
      private DateTime Z29PromotionDateStart ;
      private DateTime Z30PromotionDateFinish ;
      private DateTime A29PromotionDateStart ;
      private DateTime A30PromotionDateFinish ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A28PromotionImage_IsBlob ;
      private bool bGXsfl_63_Refreshing=false ;
      private bool returnInSub ;
      private string Z27PromotionDescription ;
      private string A27PromotionDescription ;
      private string A40000PromotionImage_GXI ;
      private string A11ProductName ;
      private string A12ProductDescription ;
      private string A5CategoryName ;
      private string Z40000PromotionImage_GXI ;
      private string Z11ProductName ;
      private string Z12ProductDescription ;
      private string Z5CategoryName ;
      private string A28PromotionImage ;
      private string Z28PromotionImage ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridpromotion_productContainer ;
      private GXWebRow Gridpromotion_productRow ;
      private GXWebColumn Gridpromotion_productColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] T00088_A26PromotionId ;
      private string[] T00088_A27PromotionDescription ;
      private string[] T00088_A40000PromotionImage_GXI ;
      private DateTime[] T00088_A29PromotionDateStart ;
      private DateTime[] T00088_A30PromotionDateFinish ;
      private string[] T00088_A28PromotionImage ;
      private short[] T00089_A26PromotionId ;
      private short[] T00087_A26PromotionId ;
      private string[] T00087_A27PromotionDescription ;
      private string[] T00087_A40000PromotionImage_GXI ;
      private DateTime[] T00087_A29PromotionDateStart ;
      private DateTime[] T00087_A30PromotionDateFinish ;
      private string[] T00087_A28PromotionImage ;
      private short[] T000810_A26PromotionId ;
      private short[] T000811_A26PromotionId ;
      private short[] T00086_A26PromotionId ;
      private string[] T00086_A27PromotionDescription ;
      private string[] T00086_A40000PromotionImage_GXI ;
      private DateTime[] T00086_A29PromotionDateStart ;
      private DateTime[] T00086_A30PromotionDateFinish ;
      private string[] T00086_A28PromotionImage ;
      private short[] T000812_A26PromotionId ;
      private short[] T000816_A26PromotionId ;
      private short[] T000817_A4CategoryId ;
      private short[] T000817_A26PromotionId ;
      private string[] T000817_A11ProductName ;
      private string[] T000817_A12ProductDescription ;
      private string[] T000817_A5CategoryName ;
      private short[] T000817_A10ProductId ;
      private short[] T00084_A4CategoryId ;
      private string[] T00084_A11ProductName ;
      private string[] T00084_A12ProductDescription ;
      private string[] T00085_A5CategoryName ;
      private short[] T000818_A4CategoryId ;
      private string[] T000818_A11ProductName ;
      private string[] T000818_A12ProductDescription ;
      private string[] T000819_A5CategoryName ;
      private short[] T000820_A26PromotionId ;
      private short[] T000820_A10ProductId ;
      private short[] T00083_A26PromotionId ;
      private short[] T00083_A10ProductId ;
      private short[] T00082_A26PromotionId ;
      private short[] T00082_A10ProductId ;
      private short[] T000823_A4CategoryId ;
      private string[] T000823_A11ProductName ;
      private string[] T000823_A12ProductDescription ;
      private string[] T000824_A5CategoryName ;
      private short[] T000825_A26PromotionId ;
      private short[] T000825_A10ProductId ;
   }

   public class promotion__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00082;
          prmT00082 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00083;
          prmT00083 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00084;
          prmT00084 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00085;
          prmT00085 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT00086;
          prmT00086 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT00087;
          prmT00087 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT00088;
          prmT00088 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT00089;
          prmT00089 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000810;
          prmT000810 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000811;
          prmT000811 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000812;
          prmT000812 = new Object[] {
          new ParDef("@PromotionDescription",GXType.NVarChar,200,0) ,
          new ParDef("@PromotionImage",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@PromotionImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Promotion", Fld="PromotionImage"} ,
          new ParDef("@PromotionDateStart",GXType.Date,8,0) ,
          new ParDef("@PromotionDateFinish",GXType.Date,8,0)
          };
          Object[] prmT000813;
          prmT000813 = new Object[] {
          new ParDef("@PromotionDescription",GXType.NVarChar,200,0) ,
          new ParDef("@PromotionDateStart",GXType.Date,8,0) ,
          new ParDef("@PromotionDateFinish",GXType.Date,8,0) ,
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000814;
          prmT000814 = new Object[] {
          new ParDef("@PromotionImage",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@PromotionImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Promotion", Fld="PromotionImage"} ,
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000815;
          prmT000815 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000816;
          prmT000816 = new Object[] {
          };
          Object[] prmT000817;
          prmT000817 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000818;
          prmT000818 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000819;
          prmT000819 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT000820;
          prmT000820 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000821;
          prmT000821 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000822;
          prmT000822 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000823;
          prmT000823 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000824;
          prmT000824 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT000825;
          prmT000825 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00082", "SELECT [PromotionId], [ProductId] FROM [PromotionProduct] WITH (UPDLOCK) WHERE [PromotionId] = @PromotionId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00083", "SELECT [PromotionId], [ProductId] FROM [PromotionProduct] WHERE [PromotionId] = @PromotionId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00084", "SELECT [CategoryId], [ProductName], [ProductDescription] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00085", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00086", "SELECT [PromotionId], [PromotionDescription], [PromotionImage_GXI], [PromotionDateStart], [PromotionDateFinish], [PromotionImage] FROM [Promotion] WITH (UPDLOCK) WHERE [PromotionId] = @PromotionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00087", "SELECT [PromotionId], [PromotionDescription], [PromotionImage_GXI], [PromotionDateStart], [PromotionDateFinish], [PromotionImage] FROM [Promotion] WHERE [PromotionId] = @PromotionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00088", "SELECT TM1.[PromotionId], TM1.[PromotionDescription], TM1.[PromotionImage_GXI], TM1.[PromotionDateStart], TM1.[PromotionDateFinish], TM1.[PromotionImage] FROM [Promotion] TM1 WHERE TM1.[PromotionId] = @PromotionId ORDER BY TM1.[PromotionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00088,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00089", "SELECT [PromotionId] FROM [Promotion] WHERE [PromotionId] = @PromotionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00089,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000810", "SELECT TOP 1 [PromotionId] FROM [Promotion] WHERE ( [PromotionId] > @PromotionId) ORDER BY [PromotionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000810,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000811", "SELECT TOP 1 [PromotionId] FROM [Promotion] WHERE ( [PromotionId] < @PromotionId) ORDER BY [PromotionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000811,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000812", "INSERT INTO [Promotion]([PromotionDescription], [PromotionImage], [PromotionImage_GXI], [PromotionDateStart], [PromotionDateFinish]) VALUES(@PromotionDescription, @PromotionImage, @PromotionImage_GXI, @PromotionDateStart, @PromotionDateFinish); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000812,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000813", "UPDATE [Promotion] SET [PromotionDescription]=@PromotionDescription, [PromotionDateStart]=@PromotionDateStart, [PromotionDateFinish]=@PromotionDateFinish  WHERE [PromotionId] = @PromotionId", GxErrorMask.GX_NOMASK,prmT000813)
             ,new CursorDef("T000814", "UPDATE [Promotion] SET [PromotionImage]=@PromotionImage, [PromotionImage_GXI]=@PromotionImage_GXI  WHERE [PromotionId] = @PromotionId", GxErrorMask.GX_NOMASK,prmT000814)
             ,new CursorDef("T000815", "DELETE FROM [Promotion]  WHERE [PromotionId] = @PromotionId", GxErrorMask.GX_NOMASK,prmT000815)
             ,new CursorDef("T000816", "SELECT [PromotionId] FROM [Promotion] ORDER BY [PromotionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000816,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000817", "SELECT T2.[CategoryId], T1.[PromotionId], T2.[ProductName], T2.[ProductDescription], T3.[CategoryName], T1.[ProductId] FROM (([PromotionProduct] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) INNER JOIN [Category] T3 ON T3.[CategoryId] = T2.[CategoryId]) WHERE T1.[PromotionId] = @PromotionId and T1.[ProductId] = @ProductId ORDER BY T1.[PromotionId], T1.[ProductId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000817,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000818", "SELECT [CategoryId], [ProductName], [ProductDescription] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000818,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000819", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000819,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000820", "SELECT [PromotionId], [ProductId] FROM [PromotionProduct] WHERE [PromotionId] = @PromotionId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000820,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000821", "INSERT INTO [PromotionProduct]([PromotionId], [ProductId]) VALUES(@PromotionId, @ProductId)", GxErrorMask.GX_NOMASK,prmT000821)
             ,new CursorDef("T000822", "DELETE FROM [PromotionProduct]  WHERE [PromotionId] = @PromotionId AND [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000822)
             ,new CursorDef("T000823", "SELECT [CategoryId], [ProductName], [ProductDescription] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000823,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000824", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000824,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000825", "SELECT [PromotionId], [ProductId] FROM [PromotionProduct] WHERE [PromotionId] = @PromotionId ORDER BY [PromotionId], [ProductId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000825,11, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
