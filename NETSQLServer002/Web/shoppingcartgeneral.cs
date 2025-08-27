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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class shoppingcartgeneral : GXWebComponent
   {
      public shoppingcartgeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("ObligatorioShop", true);
         }
      }

      public shoppingcartgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_ShoppingCartId )
      {
         this.A31ShoppingCartId = aP0_ShoppingCartId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ShoppingCartId");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A31ShoppingCartId = (short)(Math.Round(NumberUtil.Val( GetPar( "ShoppingCartId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A31ShoppingCartId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "ShoppingCartId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ShoppingCartId");
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
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA152( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV11Pgmname = "ShoppingCartGeneral";
               /* Using cursor H00159 */
               pr_default.execute(0, new Object[] {A31ShoppingCartId});
               if ( (pr_default.getStatus(0) != 101) )
               {
                  A33ShoppingCartTotalCost = H00159_A33ShoppingCartTotalCost[0];
                  n33ShoppingCartTotalCost = H00159_n33ShoppingCartTotalCost[0];
                  AssignAttri(sPrefix, false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
               }
               else
               {
                  A33ShoppingCartTotalCost = 0;
                  n33ShoppingCartTotalCost = false;
                  AssignAttri(sPrefix, false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
               }
               pr_default.close(0);
               WS152( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Shopping Cart General") ;
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
         }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
            {
               context.WriteHtmlText( " dir=\"rtl\" ") ;
            }
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("shoppingcartgeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A31ShoppingCartId,4,0))}, new string[] {"ShoppingCartId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ShoppingCartGeneral");
         forbiddenHiddens.Add("CustomerId", context.localUtil.Format( (decimal)(A15CustomerId), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("shoppingcartgeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA31ShoppingCartId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA31ShoppingCartId), 4, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm152( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "ShoppingCartGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Shopping Cart General" ;
      }

      protected void WB150( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "shoppingcartgeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ww__view__actions-cell", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ww__view__actions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Modificar", bttBtnupdate_Jsonclick, 7, "Modificar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11151_client"+"'", TempTags, "", 2, "HLP_ShoppingCartGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Eliminar", bttBtndelete_Jsonclick, 7, "Eliminar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e12151_client"+"'", TempTags, "", 2, "HLP_ShoppingCartGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtShoppingCartId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtShoppingCartId_Internalname, "Cart Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtShoppingCartId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A31ShoppingCartId), 4, 0, ",", "")), StringUtil.LTrim( ((edtShoppingCartId_Enabled!=0) ? context.localUtil.Format( (decimal)(A31ShoppingCartId), "ZZZ9") : context.localUtil.Format( (decimal)(A31ShoppingCartId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtShoppingCartId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCustomerId_Internalname, "Customer Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCustomerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CustomerId), 4, 0, ",", "")), StringUtil.LTrim( ((edtCustomerId_Enabled!=0) ? context.localUtil.Format( (decimal)(A15CustomerId), "ZZZ9") : context.localUtil.Format( (decimal)(A15CustomerId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCustomerId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCustomerName_Internalname, "Customer Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCustomerName_Internalname, A16CustomerName, StringUtil.RTrim( context.localUtil.Format( A16CustomerName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtCustomerName_Link, "", "", "", edtCustomerName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCustomerName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCustomerDirectionDestination_Internalname, "Customer Direction Destination", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCustomerDirectionDestination_Internalname, A17CustomerDirectionDestination, StringUtil.RTrim( context.localUtil.Format( A17CustomerDirectionDestination, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerDirectionDestination_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCustomerDirectionDestination_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCountryId_Internalname, "Country Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CountryId), 4, 0, ",", "")), StringUtil.LTrim( ((edtCountryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1CountryId), "ZZZ9") : context.localUtil.Format( (decimal)(A1CountryId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCountryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCountryName_Internalname, "Country Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCountryName_Internalname, A2CountryName, StringUtil.RTrim( context.localUtil.Format( A2CountryName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtCountryName_Link, "", "", "", edtCountryName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCountryName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtShoppingCartTotalCost_Internalname, "Total Cost", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtShoppingCartTotalCost_Internalname, StringUtil.LTrim( StringUtil.NToC( A33ShoppingCartTotalCost, 18, 2, ",", "")), StringUtil.LTrim( ((edtShoppingCartTotalCost_Enabled!=0) ? context.localUtil.Format( A33ShoppingCartTotalCost, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A33ShoppingCartTotalCost, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,48);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartTotalCost_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtShoppingCartTotalCost_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtShoppingCartDate_Internalname, "Cart Date", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtShoppingCartDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtShoppingCartDate_Internalname, context.localUtil.Format(A34ShoppingCartDate, "99/99/99"), context.localUtil.Format( A34ShoppingCartDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,53);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartDate_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtShoppingCartDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ShoppingCartGeneral.htm");
            GxWebStd.gx_bitmap( context, edtShoppingCartDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtShoppingCartDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtShoppingCartDeliveryDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtShoppingCartDeliveryDate_Internalname, "Delivery Date", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtShoppingCartDeliveryDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtShoppingCartDeliveryDate_Internalname, context.localUtil.Format(A35ShoppingCartDeliveryDate, "99/99/99"), context.localUtil.Format( A35ShoppingCartDeliveryDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,58);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartDeliveryDate_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtShoppingCartDeliveryDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ShoppingCartGeneral.htm");
            GxWebStd.gx_bitmap( context, edtShoppingCartDeliveryDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtShoppingCartDeliveryDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ShoppingCartGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START152( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", "Shopping Cart General", 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP150( ) ;
            }
         }
      }

      protected void WS152( )
      {
         START152( ) ;
         EVT152( ) ;
      }

      protected void EVT152( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP150( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP150( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13152 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP150( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E14152 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP150( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP150( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
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
      }

      protected void WE152( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm152( ) ;
            }
         }
      }

      protected void PA152( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF152( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV11Pgmname = "ShoppingCartGeneral";
      }

      protected void RF152( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H001517 */
            pr_default.execute(1, new Object[] {A31ShoppingCartId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A2CountryName = H001517_A2CountryName[0];
               AssignAttri(sPrefix, false, "A2CountryName", A2CountryName);
               A1CountryId = H001517_A1CountryId[0];
               AssignAttri(sPrefix, false, "A1CountryId", StringUtil.LTrimStr( (decimal)(A1CountryId), 4, 0));
               A17CustomerDirectionDestination = H001517_A17CustomerDirectionDestination[0];
               AssignAttri(sPrefix, false, "A17CustomerDirectionDestination", A17CustomerDirectionDestination);
               A16CustomerName = H001517_A16CustomerName[0];
               AssignAttri(sPrefix, false, "A16CustomerName", A16CustomerName);
               A15CustomerId = H001517_A15CustomerId[0];
               AssignAttri(sPrefix, false, "A15CustomerId", StringUtil.LTrimStr( (decimal)(A15CustomerId), 4, 0));
               A33ShoppingCartTotalCost = H001517_A33ShoppingCartTotalCost[0];
               n33ShoppingCartTotalCost = H001517_n33ShoppingCartTotalCost[0];
               AssignAttri(sPrefix, false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
               A34ShoppingCartDate = H001517_A34ShoppingCartDate[0];
               AssignAttri(sPrefix, false, "A34ShoppingCartDate", context.localUtil.Format(A34ShoppingCartDate, "99/99/99"));
               A1CountryId = H001517_A1CountryId[0];
               AssignAttri(sPrefix, false, "A1CountryId", StringUtil.LTrimStr( (decimal)(A1CountryId), 4, 0));
               A17CustomerDirectionDestination = H001517_A17CustomerDirectionDestination[0];
               AssignAttri(sPrefix, false, "A17CustomerDirectionDestination", A17CustomerDirectionDestination);
               A16CustomerName = H001517_A16CustomerName[0];
               AssignAttri(sPrefix, false, "A16CustomerName", A16CustomerName);
               A2CountryName = H001517_A2CountryName[0];
               AssignAttri(sPrefix, false, "A2CountryName", A2CountryName);
               A33ShoppingCartTotalCost = H001517_A33ShoppingCartTotalCost[0];
               n33ShoppingCartTotalCost = H001517_n33ShoppingCartTotalCost[0];
               AssignAttri(sPrefix, false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
               A35ShoppingCartDeliveryDate = DateTimeUtil.DAdd(A34ShoppingCartDate,+((int)(5)));
               AssignAttri(sPrefix, false, "A35ShoppingCartDeliveryDate", context.localUtil.Format(A35ShoppingCartDeliveryDate, "99/99/99"));
               /* Execute user event: Load */
               E14152 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WB150( ) ;
         }
      }

      protected void send_integrity_lvl_hashes152( )
      {
      }

      protected void before_start_formulas( )
      {
         AV11Pgmname = "ShoppingCartGeneral";
         /* Using cursor H001525 */
         pr_default.execute(2, new Object[] {A31ShoppingCartId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A33ShoppingCartTotalCost = H001525_A33ShoppingCartTotalCost[0];
            n33ShoppingCartTotalCost = H001525_n33ShoppingCartTotalCost[0];
            AssignAttri(sPrefix, false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         }
         else
         {
            A33ShoppingCartTotalCost = 0;
            n33ShoppingCartTotalCost = false;
            AssignAttri(sPrefix, false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
         }
         pr_default.close(2);
         edtShoppingCartId_Enabled = 0;
         AssignProp(sPrefix, false, edtShoppingCartId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartId_Enabled), 5, 0), true);
         edtCustomerId_Enabled = 0;
         AssignProp(sPrefix, false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         edtCustomerName_Enabled = 0;
         AssignProp(sPrefix, false, edtCustomerName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerName_Enabled), 5, 0), true);
         edtCustomerDirectionDestination_Enabled = 0;
         AssignProp(sPrefix, false, edtCustomerDirectionDestination_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerDirectionDestination_Enabled), 5, 0), true);
         edtCountryId_Enabled = 0;
         AssignProp(sPrefix, false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         edtCountryName_Enabled = 0;
         AssignProp(sPrefix, false, edtCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryName_Enabled), 5, 0), true);
         edtShoppingCartTotalCost_Enabled = 0;
         AssignProp(sPrefix, false, edtShoppingCartTotalCost_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartTotalCost_Enabled), 5, 0), true);
         edtShoppingCartDate_Enabled = 0;
         AssignProp(sPrefix, false, edtShoppingCartDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartDate_Enabled), 5, 0), true);
         edtShoppingCartDeliveryDate_Enabled = 0;
         AssignProp(sPrefix, false, edtShoppingCartDeliveryDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartDeliveryDate_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP150( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13152 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA31ShoppingCartId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA31ShoppingCartId"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A15CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A15CustomerId", StringUtil.LTrimStr( (decimal)(A15CustomerId), 4, 0));
            A16CustomerName = cgiGet( edtCustomerName_Internalname);
            AssignAttri(sPrefix, false, "A16CustomerName", A16CustomerName);
            A17CustomerDirectionDestination = cgiGet( edtCustomerDirectionDestination_Internalname);
            AssignAttri(sPrefix, false, "A17CustomerDirectionDestination", A17CustomerDirectionDestination);
            A1CountryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A1CountryId", StringUtil.LTrimStr( (decimal)(A1CountryId), 4, 0));
            A2CountryName = cgiGet( edtCountryName_Internalname);
            AssignAttri(sPrefix, false, "A2CountryName", A2CountryName);
            A33ShoppingCartTotalCost = context.localUtil.CToN( cgiGet( edtShoppingCartTotalCost_Internalname), ",", ".");
            n33ShoppingCartTotalCost = false;
            AssignAttri(sPrefix, false, "A33ShoppingCartTotalCost", StringUtil.LTrimStr( A33ShoppingCartTotalCost, 18, 2));
            A34ShoppingCartDate = context.localUtil.CToD( cgiGet( edtShoppingCartDate_Internalname), 2);
            AssignAttri(sPrefix, false, "A34ShoppingCartDate", context.localUtil.Format(A34ShoppingCartDate, "99/99/99"));
            A35ShoppingCartDeliveryDate = context.localUtil.CToD( cgiGet( edtShoppingCartDeliveryDate_Internalname), 2);
            AssignAttri(sPrefix, false, "A35ShoppingCartDeliveryDate", context.localUtil.Format(A35ShoppingCartDeliveryDate, "99/99/99"));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ShoppingCartGeneral");
            A15CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A15CustomerId", StringUtil.LTrimStr( (decimal)(A15CustomerId), 4, 0));
            forbiddenHiddens.Add("CustomerId", context.localUtil.Format( (decimal)(A15CustomerId), "ZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("shoppingcartgeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E13152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13152( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E14152( )
      {
         /* Load Routine */
         returnInSub = false;
         edtCustomerName_Link = formatLink("viewcustomer.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A15CustomerId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"CustomerId","TabCode"}) ;
         AssignProp(sPrefix, false, edtCustomerName_Internalname, "Link", edtCustomerName_Link, true);
         edtCountryName_Link = formatLink("viewcountry.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1CountryId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"CountryId","TabCode"}) ;
         AssignProp(sPrefix, false, edtCountryName_Internalname, "Link", edtCountryName_Link, true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV11Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "ShoppingCart";
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "ShoppingCartId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6ShoppingCartId), 4, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A31ShoppingCartId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA152( ) ;
         WS152( ) ;
         WE152( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA31ShoppingCartId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA152( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "shoppingcartgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA152( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A31ShoppingCartId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
         }
         wcpOA31ShoppingCartId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA31ShoppingCartId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A31ShoppingCartId != wcpOA31ShoppingCartId ) ) )
         {
            setjustcreated();
         }
         wcpOA31ShoppingCartId = A31ShoppingCartId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA31ShoppingCartId = cgiGet( sPrefix+"A31ShoppingCartId_CTRL");
         if ( StringUtil.Len( sCtrlA31ShoppingCartId) > 0 )
         {
            A31ShoppingCartId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA31ShoppingCartId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A31ShoppingCartId", StringUtil.LTrimStr( (decimal)(A31ShoppingCartId), 4, 0));
         }
         else
         {
            A31ShoppingCartId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A31ShoppingCartId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA152( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS152( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS152( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A31ShoppingCartId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A31ShoppingCartId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA31ShoppingCartId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A31ShoppingCartId_CTRL", StringUtil.RTrim( sCtrlA31ShoppingCartId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE152( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411817223358", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("shoppingcartgeneral.js", "?202411817223358", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         edtShoppingCartId_Internalname = sPrefix+"SHOPPINGCARTID";
         edtCustomerId_Internalname = sPrefix+"CUSTOMERID";
         edtCustomerName_Internalname = sPrefix+"CUSTOMERNAME";
         edtCustomerDirectionDestination_Internalname = sPrefix+"CUSTOMERDIRECTIONDESTINATION";
         edtCountryId_Internalname = sPrefix+"COUNTRYID";
         edtCountryName_Internalname = sPrefix+"COUNTRYNAME";
         edtShoppingCartTotalCost_Internalname = sPrefix+"SHOPPINGCARTTOTALCOST";
         edtShoppingCartDate_Internalname = sPrefix+"SHOPPINGCARTDATE";
         edtShoppingCartDeliveryDate_Internalname = sPrefix+"SHOPPINGCARTDELIVERYDATE";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("ObligatorioShop", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtShoppingCartDeliveryDate_Jsonclick = "";
         edtShoppingCartDeliveryDate_Enabled = 0;
         edtShoppingCartDate_Jsonclick = "";
         edtShoppingCartDate_Enabled = 0;
         edtShoppingCartTotalCost_Jsonclick = "";
         edtShoppingCartTotalCost_Enabled = 0;
         edtCountryName_Jsonclick = "";
         edtCountryName_Link = "";
         edtCountryName_Enabled = 0;
         edtCountryId_Jsonclick = "";
         edtCountryId_Enabled = 0;
         edtCustomerDirectionDestination_Jsonclick = "";
         edtCustomerDirectionDestination_Enabled = 0;
         edtCustomerName_Jsonclick = "";
         edtCustomerName_Link = "";
         edtCustomerName_Enabled = 0;
         edtCustomerId_Jsonclick = "";
         edtCustomerId_Enabled = 0;
         edtShoppingCartId_Jsonclick = "";
         edtShoppingCartId_Enabled = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A31ShoppingCartId","fld":"SHOPPINGCARTID","pic":"ZZZ9"},{"av":"A15CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"}]}""");
         setEventMetadata("'DOUPDATE'","""{"handler":"E11151","iparms":[{"av":"A31ShoppingCartId","fld":"SHOPPINGCARTID","pic":"ZZZ9"}]}""");
         setEventMetadata("'DODELETE'","""{"handler":"E12151","iparms":[{"av":"A31ShoppingCartId","fld":"SHOPPINGCARTID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_SHOPPINGCARTID","""{"handler":"Valid_Shoppingcartid","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERID","""{"handler":"Valid_Customerid","iparms":[]}""");
         setEventMetadata("VALID_COUNTRYID","""{"handler":"Valid_Countryid","iparms":[]}""");
         setEventMetadata("VALID_SHOPPINGCARTDATE","""{"handler":"Valid_Shoppingcartdate","iparms":[]}""");
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

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV11Pgmname = "";
         H00159_A33ShoppingCartTotalCost = new decimal[1] ;
         H00159_n33ShoppingCartTotalCost = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A16CustomerName = "";
         A17CustomerDirectionDestination = "";
         A2CountryName = "";
         A34ShoppingCartDate = DateTime.MinValue;
         A35ShoppingCartDeliveryDate = DateTime.MinValue;
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H001517_A31ShoppingCartId = new short[1] ;
         H001517_A2CountryName = new string[] {""} ;
         H001517_A1CountryId = new short[1] ;
         H001517_A17CustomerDirectionDestination = new string[] {""} ;
         H001517_A16CustomerName = new string[] {""} ;
         H001517_A15CustomerId = new short[1] ;
         H001517_A33ShoppingCartTotalCost = new decimal[1] ;
         H001517_n33ShoppingCartTotalCost = new bool[] {false} ;
         H001517_A34ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         H001525_A33ShoppingCartTotalCost = new decimal[1] ;
         H001525_n33ShoppingCartTotalCost = new bool[] {false} ;
         hsh = "";
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA31ShoppingCartId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.shoppingcartgeneral__default(),
            new Object[][] {
                new Object[] {
               H00159_A33ShoppingCartTotalCost, H00159_n33ShoppingCartTotalCost
               }
               , new Object[] {
               H001517_A31ShoppingCartId, H001517_A2CountryName, H001517_A1CountryId, H001517_A17CustomerDirectionDestination, H001517_A16CustomerName, H001517_A15CustomerId, H001517_A33ShoppingCartTotalCost, H001517_n33ShoppingCartTotalCost, H001517_A34ShoppingCartDate
               }
               , new Object[] {
               H001525_A33ShoppingCartTotalCost, H001525_n33ShoppingCartTotalCost
               }
            }
         );
         AV11Pgmname = "ShoppingCartGeneral";
         /* GeneXus formulas. */
         AV11Pgmname = "ShoppingCartGeneral";
      }

      private short A31ShoppingCartId ;
      private short wcpOA31ShoppingCartId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short A15CustomerId ;
      private short wbEnd ;
      private short wbStart ;
      private short A1CountryId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV6ShoppingCartId ;
      private short nGXWrapped ;
      private int edtShoppingCartId_Enabled ;
      private int edtCustomerId_Enabled ;
      private int edtCustomerName_Enabled ;
      private int edtCustomerDirectionDestination_Enabled ;
      private int edtCountryId_Enabled ;
      private int edtCountryName_Enabled ;
      private int edtShoppingCartTotalCost_Enabled ;
      private int edtShoppingCartDate_Enabled ;
      private int edtShoppingCartDeliveryDate_Enabled ;
      private int idxLst ;
      private decimal A33ShoppingCartTotalCost ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV11Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtShoppingCartId_Internalname ;
      private string edtShoppingCartId_Jsonclick ;
      private string edtCustomerId_Internalname ;
      private string edtCustomerId_Jsonclick ;
      private string edtCustomerName_Internalname ;
      private string edtCustomerName_Link ;
      private string edtCustomerName_Jsonclick ;
      private string edtCustomerDirectionDestination_Internalname ;
      private string edtCustomerDirectionDestination_Jsonclick ;
      private string edtCountryId_Internalname ;
      private string edtCountryId_Jsonclick ;
      private string edtCountryName_Internalname ;
      private string edtCountryName_Link ;
      private string edtCountryName_Jsonclick ;
      private string edtShoppingCartTotalCost_Internalname ;
      private string edtShoppingCartTotalCost_Jsonclick ;
      private string edtShoppingCartDate_Internalname ;
      private string edtShoppingCartDate_Jsonclick ;
      private string edtShoppingCartDeliveryDate_Internalname ;
      private string edtShoppingCartDeliveryDate_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string hsh ;
      private string sCtrlA31ShoppingCartId ;
      private DateTime A34ShoppingCartDate ;
      private DateTime A35ShoppingCartDeliveryDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n33ShoppingCartTotalCost ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A16CustomerName ;
      private string A17CustomerDirectionDestination ;
      private string A2CountryName ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] H00159_A33ShoppingCartTotalCost ;
      private bool[] H00159_n33ShoppingCartTotalCost ;
      private short[] H001517_A31ShoppingCartId ;
      private string[] H001517_A2CountryName ;
      private short[] H001517_A1CountryId ;
      private string[] H001517_A17CustomerDirectionDestination ;
      private string[] H001517_A16CustomerName ;
      private short[] H001517_A15CustomerId ;
      private decimal[] H001517_A33ShoppingCartTotalCost ;
      private bool[] H001517_n33ShoppingCartTotalCost ;
      private DateTime[] H001517_A34ShoppingCartDate ;
      private decimal[] H001525_A33ShoppingCartTotalCost ;
      private bool[] H001525_n33ShoppingCartTotalCost ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV7TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV8TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class shoppingcartgeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00159;
          prmH00159 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmH001517;
          prmH001517 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          string cmdBufferH001517;
          cmdBufferH001517=" SELECT T1.[ShoppingCartId], T3.[CountryName], T2.[CountryId], T2.[CustomerDirectionDestination], T2.[CustomerName], T1.[CustomerId], COALESCE( T4.[ShoppingCartTotalCost], 0) AS ShoppingCartTotalCost, T1.[ShoppingCartDate] FROM ((([ShoppingCart] T1 INNER JOIN [Customer] T2 ON T2.[CustomerId] = T1.[CustomerId]) INNER JOIN [Country] T3 ON T3.[CountryId] = T2.[CountryId]) LEFT JOIN (SELECT SUM(COALESCE( T6.[ProductTotalCost], 0)) AS ShoppingCartTotalCost, T5.[ShoppingCartId] FROM ([ShoppingCartProducts] T5 INNER JOIN (SELECT ( COALESCE( T8.[ProductFinalPrice], 0)) * CAST(T7.[ProductQuantity] AS decimal( 28, 10)) AS ProductTotalCost, T7.[ShoppingCartId], T7.[ProductId] FROM ([ShoppingCartProducts] T7 INNER JOIN (SELECT CASE  WHEN T12.[CategoryId] = COALESCE( T11.[CategoryId], 0) THEN T12.[ProductPrice] + ( T12.[ProductPrice] * CAST(0.05 AS decimal( 28, 10))) WHEN T12.[CategoryId] = COALESCE( T10.[CategoryId], 0) THEN T12.[ProductPrice] - ( T12.[ProductPrice] * CAST(0.1 AS decimal( 28, 10))) ELSE T12.[ProductPrice] END AS ProductFinalPrice, T9.[ShoppingCartId], T9.[ProductId] FROM ((([ShoppingCartProducts] T9 INNER JOIN [Product] T12 ON T12.[ProductId] = T9.[ProductId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Entretenimiento' ) T10 ON T10.[CategoryId] = T12.[CategoryId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Joyeria' ) T11 ON T11.[CategoryId] = T12.[CategoryId]) ) T8 ON T8.[ShoppingCartId] = T7.[ShoppingCartId] AND T8.[ProductId] = T7.[ProductId]) ) T6 ON T6.[ShoppingCartId] = T5.[ShoppingCartId] AND T6.[ProductId] = T5.[ProductId]) GROUP BY T5.[ShoppingCartId] ) T4 ON T4.[ShoppingCartId] = T1.[ShoppingCartId]) WHERE T1.[ShoppingCartId] = @ShoppingCartId "
          + " ORDER BY T1.[ShoppingCartId]" ;
          Object[] prmH001525;
          prmH001525 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00159", "SELECT COALESCE( T1.[ShoppingCartTotalCost], 0) AS ShoppingCartTotalCost FROM (SELECT SUM(COALESCE( T3.[ProductTotalCost], 0)) AS ShoppingCartTotalCost, T2.[ShoppingCartId] FROM ([ShoppingCartProducts] T2 INNER JOIN (SELECT ( COALESCE( T5.[ProductFinalPrice], 0)) * CAST(T4.[ProductQuantity] AS decimal( 28, 10)) AS ProductTotalCost, T4.[ShoppingCartId], T4.[ProductId] FROM ([ShoppingCartProducts] T4 INNER JOIN (SELECT CASE  WHEN T9.[CategoryId] = COALESCE( T8.[CategoryId], 0) THEN T9.[ProductPrice] + ( T9.[ProductPrice] * CAST(0.05 AS decimal( 28, 10))) WHEN T9.[CategoryId] = COALESCE( T7.[CategoryId], 0) THEN T9.[ProductPrice] - ( T9.[ProductPrice] * CAST(0.1 AS decimal( 28, 10))) ELSE T9.[ProductPrice] END AS ProductFinalPrice, T6.[ShoppingCartId], T6.[ProductId] FROM ((([ShoppingCartProducts] T6 INNER JOIN [Product] T9 ON T9.[ProductId] = T6.[ProductId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Entretenimiento' ) T7 ON T7.[CategoryId] = T9.[CategoryId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Joyeria' ) T8 ON T8.[CategoryId] = T9.[CategoryId]) ) T5 ON T5.[ShoppingCartId] = T4.[ShoppingCartId] AND T5.[ProductId] = T4.[ProductId]) ) T3 ON T3.[ShoppingCartId] = T2.[ShoppingCartId] AND T3.[ProductId] = T2.[ProductId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00159,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H001517", cmdBufferH001517,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001517,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H001525", "SELECT COALESCE( T1.[ShoppingCartTotalCost], 0) AS ShoppingCartTotalCost FROM (SELECT SUM(COALESCE( T3.[ProductTotalCost], 0)) AS ShoppingCartTotalCost, T2.[ShoppingCartId] FROM ([ShoppingCartProducts] T2 INNER JOIN (SELECT ( COALESCE( T5.[ProductFinalPrice], 0)) * CAST(T4.[ProductQuantity] AS decimal( 28, 10)) AS ProductTotalCost, T4.[ShoppingCartId], T4.[ProductId] FROM ([ShoppingCartProducts] T4 INNER JOIN (SELECT CASE  WHEN T9.[CategoryId] = COALESCE( T8.[CategoryId], 0) THEN T9.[ProductPrice] + ( T9.[ProductPrice] * CAST(0.05 AS decimal( 28, 10))) WHEN T9.[CategoryId] = COALESCE( T7.[CategoryId], 0) THEN T9.[ProductPrice] - ( T9.[ProductPrice] * CAST(0.1 AS decimal( 28, 10))) ELSE T9.[ProductPrice] END AS ProductFinalPrice, T6.[ShoppingCartId], T6.[ProductId] FROM ((([ShoppingCartProducts] T6 INNER JOIN [Product] T9 ON T9.[ProductId] = T6.[ProductId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Entretenimiento' ) T7 ON T7.[CategoryId] = T9.[CategoryId]) LEFT JOIN (SELECT [CategoryId] AS CategoryId, [CategoryName] FROM [Category] WHERE [CategoryName] = 'Joyeria' ) T8 ON T8.[CategoryId] = T9.[CategoryId]) ) T5 ON T5.[ShoppingCartId] = T4.[ShoppingCartId] AND T5.[ProductId] = T4.[ProductId]) ) T3 ON T3.[ShoppingCartId] = T2.[ShoppingCartId] AND T3.[ProductId] = T2.[ProductId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001525,1, GxCacheFrequency.OFF ,true,true )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
