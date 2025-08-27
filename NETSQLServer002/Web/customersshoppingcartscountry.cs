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
   public class customersshoppingcartscountry : GXDataArea
   {
      public customersshoppingcartscountry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public customersshoppingcartscountry( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavCountryid = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vCOUNTRYID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvCOUNTRYID1S2( ) ;
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridcustomer") == 0 )
            {
               gxnrGridcustomer_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridcustomer") == 0 )
            {
               gxgrGridcustomer_refresh_invoke( ) ;
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
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridcustomer_newrow_invoke( )
      {
         nRC_GXsfl_14 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_14"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_14_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_14_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_14_idx = GetPar( "sGXsfl_14_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridcustomer_newrow( ) ;
         /* End function gxnrGridcustomer_newrow_invoke */
      }

      protected void gxgrGridcustomer_refresh_invoke( )
      {
         subGridcustomer_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridcustomer_Rows"), "."), 18, MidpointRounding.ToEven));
         dynavCountryid.FromJSonString( GetNextPar( ));
         AV6CountryId = (short)(Math.Round(NumberUtil.Val( GetPar( "CountryId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridcustomer_refresh( subGridcustomer_Rows, AV6CountryId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridcustomer_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA1S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1S2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("customersshoppingcartscountry.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCOUNTRYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6CountryId), 4, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_14", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_14), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDCUSTOMER_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDCUSTOMER_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDCUSTOMER_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDCUSTOMER_nEOF), 1, 0, ",", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE1S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1S2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("customersshoppingcartscountry.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CustomersShoppingCartsCountry" ;
      }

      public override string GetPgmdesc( )
      {
         return "Customers Shopping Carts Country" ;
      }

      protected void WB1S0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Customers and Shopping Carts", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_CustomersShoppingCartsCountry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavCountryid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavCountryid_Internalname, "Country", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'" + sGXsfl_14_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCountryid, dynavCountryid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV6CountryId), 4, 0)), 1, dynavCountryid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavCountryid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,11);\"", "", true, 0, "HLP_CustomersShoppingCartsCountry.htm");
            dynavCountryid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6CountryId), 4, 0));
            AssignProp("", false, dynavCountryid_Internalname, "Values", (string)(dynavCountryid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridcustomerContainer.SetWrapped(nGXWrapped);
            StartGridControl14( ) ;
         }
         if ( wbEnd == 14 )
         {
            wbEnd = 0;
            nRC_GXsfl_14 = (int)(nGXsfl_14_idx-1);
            if ( GridcustomerContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridcustomerContainer.AddObjectProperty("GRIDCUSTOMER_nEOF", GRIDCUSTOMER_nEOF);
               GridcustomerContainer.AddObjectProperty("GRIDCUSTOMER_nFirstRecordOnPage", GRIDCUSTOMER_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridcustomerContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridcustomer", GridcustomerContainer, subGridcustomer_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridcustomerContainerData", GridcustomerContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridcustomerContainerData"+"V", GridcustomerContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridcustomerContainerData"+"V"+"\" value='"+GridcustomerContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 14 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridcustomerContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridcustomerContainer.AddObjectProperty("GRIDCUSTOMER_nEOF", GRIDCUSTOMER_nEOF);
                  GridcustomerContainer.AddObjectProperty("GRIDCUSTOMER_nFirstRecordOnPage", GRIDCUSTOMER_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridcustomerContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridcustomer", GridcustomerContainer, subGridcustomer_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridcustomerContainerData", GridcustomerContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridcustomerContainerData"+"V", GridcustomerContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridcustomerContainerData"+"V"+"\" value='"+GridcustomerContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START1S2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Customers Shopping Carts Country", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1S0( ) ;
      }

      protected void WS1S2( )
      {
         START1S2( ) ;
         EVT1S2( ) ;
      }

      protected void EVT1S2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDCUSTOMERPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDCUSTOMERPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridcustomer_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridcustomer_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridcustomer_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridcustomer_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_14_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_14_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_idx), 4, 0), 4, "0");
                              SubsflControlProps_142( ) ;
                              A15CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A16CustomerName = cgiGet( edtCustomerName_Internalname);
                              A17CustomerDirectionDestination = cgiGet( edtCustomerDirectionDestination_Internalname);
                              A3CountryFlag = cgiGet( edtCountryFlag_Internalname);
                              AssignProp("", false, edtCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A3CountryFlag)) ? A40001CountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A3CountryFlag))), !bGXsfl_14_Refreshing);
                              AssignProp("", false, edtCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A3CountryFlag), true);
                              A2CountryName = cgiGet( edtCountryName_Internalname);
                              AV5cartsQty = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCartsqty_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, edtavCartsqty_Internalname, StringUtil.LTrimStr( (decimal)(AV5cartsQty), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E111S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Countryid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCOUNTRYID"), ",", ".") != Convert.ToDecimal( AV6CountryId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE1S2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA1S2( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = dynavCountryid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvCOUNTRYID1S2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCOUNTRYID_data1S2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvCOUNTRYID_html1S2( )
      {
         short gxdynajaxvalue;
         GXDLVvCOUNTRYID_data1S2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavCountryid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavCountryid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvCOUNTRYID_data1S2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("All");
         /* Using cursor H001S2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H001S2_A1CountryId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H001S2_A2CountryName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGridcustomer_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_142( ) ;
         while ( nGXsfl_14_idx <= nRC_GXsfl_14 )
         {
            sendrow_142( ) ;
            nGXsfl_14_idx = ((subGridcustomer_Islastpage==1)&&(nGXsfl_14_idx+1>subGridcustomer_fnc_Recordsperpage( )) ? 1 : nGXsfl_14_idx+1);
            sGXsfl_14_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_idx), 4, 0), 4, "0");
            SubsflControlProps_142( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridcustomerContainer)) ;
         /* End function gxnrGridcustomer_newrow */
      }

      protected void gxgrGridcustomer_refresh( int subGridcustomer_Rows ,
                                               short AV6CountryId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDCUSTOMER_nCurrentRecord = 0;
         RF1S2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridcustomer_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvCOUNTRYID_html1S2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavCountryid.ItemCount > 0 )
         {
            AV6CountryId = (short)(Math.Round(NumberUtil.Val( dynavCountryid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6CountryId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV6CountryId", StringUtil.LTrimStr( (decimal)(AV6CountryId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCountryid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6CountryId), 4, 0));
            AssignProp("", false, dynavCountryid_Internalname, "Values", dynavCountryid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF1S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridcustomerContainer.ClearRows();
         }
         wbStart = 14;
         nGXsfl_14_idx = 1;
         sGXsfl_14_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_idx), 4, 0), 4, "0");
         SubsflControlProps_142( ) ;
         bGXsfl_14_Refreshing = true;
         GridcustomerContainer.AddObjectProperty("GridName", "Gridcustomer");
         GridcustomerContainer.AddObjectProperty("CmpContext", "");
         GridcustomerContainer.AddObjectProperty("InMasterPage", "false");
         GridcustomerContainer.AddObjectProperty("Class", "Grid");
         GridcustomerContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridcustomerContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridcustomerContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcustomer_Backcolorstyle), 1, 0, ".", "")));
         GridcustomerContainer.PageSize = subGridcustomer_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_142( ) ;
            GXPagingFrom2 = (int)(GRIDCUSTOMER_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGridcustomer_fnc_Recordsperpage( )+1);
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV6CountryId ,
                                                 A1CountryId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor H001S4 */
            pr_default.execute(1, new Object[] {AV6CountryId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_14_idx = 1;
            sGXsfl_14_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_idx), 4, 0), 4, "0");
            SubsflControlProps_142( ) ;
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( GRIDCUSTOMER_nCurrentRecord < subGridcustomer_fnc_Recordsperpage( ) ) ) )
            {
               A1CountryId = H001S4_A1CountryId[0];
               A2CountryName = H001S4_A2CountryName[0];
               A40001CountryFlag_GXI = H001S4_A40001CountryFlag_GXI[0];
               AssignProp("", false, edtCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A3CountryFlag)) ? A40001CountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A3CountryFlag))), !bGXsfl_14_Refreshing);
               AssignProp("", false, edtCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A3CountryFlag), true);
               A17CustomerDirectionDestination = H001S4_A17CustomerDirectionDestination[0];
               A16CustomerName = H001S4_A16CustomerName[0];
               A15CustomerId = H001S4_A15CustomerId[0];
               A40000GXC1 = H001S4_A40000GXC1[0];
               n40000GXC1 = H001S4_n40000GXC1[0];
               A3CountryFlag = H001S4_A3CountryFlag[0];
               AssignProp("", false, edtCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A3CountryFlag)) ? A40001CountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A3CountryFlag))), !bGXsfl_14_Refreshing);
               AssignProp("", false, edtCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A3CountryFlag), true);
               A2CountryName = H001S4_A2CountryName[0];
               A40001CountryFlag_GXI = H001S4_A40001CountryFlag_GXI[0];
               AssignProp("", false, edtCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A3CountryFlag)) ? A40001CountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A3CountryFlag))), !bGXsfl_14_Refreshing);
               AssignProp("", false, edtCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A3CountryFlag), true);
               A3CountryFlag = H001S4_A3CountryFlag[0];
               AssignProp("", false, edtCountryFlag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A3CountryFlag)) ? A40001CountryFlag_GXI : context.convertURL( context.PathToRelativeUrl( A3CountryFlag))), !bGXsfl_14_Refreshing);
               AssignProp("", false, edtCountryFlag_Internalname, "SrcSet", context.GetImageSrcSet( A3CountryFlag), true);
               A40000GXC1 = H001S4_A40000GXC1[0];
               n40000GXC1 = H001S4_n40000GXC1[0];
               /* Execute user event: Load */
               E111S2 ();
               pr_default.readNext(1);
            }
            GRIDCUSTOMER_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDCUSTOMER_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDCUSTOMER_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 14;
            WB1S0( ) ;
         }
         bGXsfl_14_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1S2( )
      {
      }

      protected int subGridcustomer_fnc_Pagecount( )
      {
         GRIDCUSTOMER_nRecordCount = subGridcustomer_fnc_Recordcount( );
         if ( ((int)((GRIDCUSTOMER_nRecordCount) % (subGridcustomer_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDCUSTOMER_nRecordCount/ (decimal)(subGridcustomer_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDCUSTOMER_nRecordCount/ (decimal)(subGridcustomer_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridcustomer_fnc_Recordcount( )
      {
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV6CountryId ,
                                              A1CountryId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor H001S6 */
         pr_default.execute(2, new Object[] {AV6CountryId});
         GRIDCUSTOMER_nRecordCount = H001S6_AGRIDCUSTOMER_nRecordCount[0];
         pr_default.close(2);
         return (int)(GRIDCUSTOMER_nRecordCount) ;
      }

      protected int subGridcustomer_fnc_Recordsperpage( )
      {
         return (int)(5*1) ;
      }

      protected int subGridcustomer_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDCUSTOMER_nFirstRecordOnPage/ (decimal)(subGridcustomer_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridcustomer_firstpage( )
      {
         GRIDCUSTOMER_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDCUSTOMER_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDCUSTOMER_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridcustomer_refresh( subGridcustomer_Rows, AV6CountryId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridcustomer_nextpage( )
      {
         GRIDCUSTOMER_nRecordCount = subGridcustomer_fnc_Recordcount( );
         if ( ( GRIDCUSTOMER_nRecordCount >= subGridcustomer_fnc_Recordsperpage( ) ) && ( GRIDCUSTOMER_nEOF == 0 ) )
         {
            GRIDCUSTOMER_nFirstRecordOnPage = (long)(GRIDCUSTOMER_nFirstRecordOnPage+subGridcustomer_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDCUSTOMER_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDCUSTOMER_nFirstRecordOnPage), 15, 0, ".", "")));
         GridcustomerContainer.AddObjectProperty("GRIDCUSTOMER_nFirstRecordOnPage", GRIDCUSTOMER_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridcustomer_refresh( subGridcustomer_Rows, AV6CountryId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDCUSTOMER_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridcustomer_previouspage( )
      {
         if ( GRIDCUSTOMER_nFirstRecordOnPage >= subGridcustomer_fnc_Recordsperpage( ) )
         {
            GRIDCUSTOMER_nFirstRecordOnPage = (long)(GRIDCUSTOMER_nFirstRecordOnPage-subGridcustomer_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDCUSTOMER_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDCUSTOMER_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridcustomer_refresh( subGridcustomer_Rows, AV6CountryId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridcustomer_lastpage( )
      {
         GRIDCUSTOMER_nRecordCount = subGridcustomer_fnc_Recordcount( );
         if ( GRIDCUSTOMER_nRecordCount > subGridcustomer_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDCUSTOMER_nRecordCount) % (subGridcustomer_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDCUSTOMER_nFirstRecordOnPage = (long)(GRIDCUSTOMER_nRecordCount-subGridcustomer_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDCUSTOMER_nFirstRecordOnPage = (long)(GRIDCUSTOMER_nRecordCount-((int)((GRIDCUSTOMER_nRecordCount) % (subGridcustomer_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDCUSTOMER_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDCUSTOMER_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDCUSTOMER_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridcustomer_refresh( subGridcustomer_Rows, AV6CountryId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridcustomer_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDCUSTOMER_nFirstRecordOnPage = (long)(subGridcustomer_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDCUSTOMER_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDCUSTOMER_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDCUSTOMER_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridcustomer_refresh( subGridcustomer_Rows, AV6CountryId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         GXVvCOUNTRYID_html1S2( ) ;
         edtCustomerId_Enabled = 0;
         edtCustomerName_Enabled = 0;
         edtCustomerDirectionDestination_Enabled = 0;
         edtCountryFlag_Enabled = 0;
         edtCountryName_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_14 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_14"), ",", "."), 18, MidpointRounding.ToEven));
            GRIDCUSTOMER_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDCUSTOMER_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRIDCUSTOMER_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDCUSTOMER_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            dynavCountryid.Name = dynavCountryid_Internalname;
            dynavCountryid.CurrentValue = cgiGet( dynavCountryid_Internalname);
            AV6CountryId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavCountryid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV6CountryId", StringUtil.LTrimStr( (decimal)(AV6CountryId), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCOUNTRYID"), ",", ".") != Convert.ToDecimal( AV6CountryId )) )
            {
               GRIDCUSTOMER_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      private void E111S2( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5cartsQty = (short)(A40000GXC1);
         AssignAttri("", false, edtavCartsqty_Internalname, StringUtil.LTrimStr( (decimal)(AV5cartsQty), 4, 0));
         sendrow_142( ) ;
         GRIDCUSTOMER_nCurrentRecord = (long)(GRIDCUSTOMER_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_14_Refreshing )
         {
            DoAjaxLoad(14, GridcustomerRow);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA1S2( ) ;
         WS1S2( ) ;
         WE1S2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411816153739", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("customersshoppingcartscountry.js", "?202411816153739", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_142( )
      {
         edtCustomerId_Internalname = "CUSTOMERID_"+sGXsfl_14_idx;
         edtCustomerName_Internalname = "CUSTOMERNAME_"+sGXsfl_14_idx;
         edtCustomerDirectionDestination_Internalname = "CUSTOMERDIRECTIONDESTINATION_"+sGXsfl_14_idx;
         edtCountryFlag_Internalname = "COUNTRYFLAG_"+sGXsfl_14_idx;
         edtCountryName_Internalname = "COUNTRYNAME_"+sGXsfl_14_idx;
         edtavCartsqty_Internalname = "vCARTSQTY_"+sGXsfl_14_idx;
      }

      protected void SubsflControlProps_fel_142( )
      {
         edtCustomerId_Internalname = "CUSTOMERID_"+sGXsfl_14_fel_idx;
         edtCustomerName_Internalname = "CUSTOMERNAME_"+sGXsfl_14_fel_idx;
         edtCustomerDirectionDestination_Internalname = "CUSTOMERDIRECTIONDESTINATION_"+sGXsfl_14_fel_idx;
         edtCountryFlag_Internalname = "COUNTRYFLAG_"+sGXsfl_14_fel_idx;
         edtCountryName_Internalname = "COUNTRYNAME_"+sGXsfl_14_fel_idx;
         edtavCartsqty_Internalname = "vCARTSQTY_"+sGXsfl_14_fel_idx;
      }

      protected void sendrow_142( )
      {
         sGXsfl_14_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_idx), 4, 0), 4, "0");
         SubsflControlProps_142( ) ;
         WB1S0( ) ;
         if ( ( 5 * 1 == 0 ) || ( nGXsfl_14_idx <= subGridcustomer_fnc_Recordsperpage( ) * 1 ) )
         {
            GridcustomerRow = GXWebRow.GetNew(context,GridcustomerContainer);
            if ( subGridcustomer_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridcustomer_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridcustomer_Class, "") != 0 )
               {
                  subGridcustomer_Linesclass = subGridcustomer_Class+"Odd";
               }
            }
            else if ( subGridcustomer_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridcustomer_Backstyle = 0;
               subGridcustomer_Backcolor = subGridcustomer_Allbackcolor;
               if ( StringUtil.StrCmp(subGridcustomer_Class, "") != 0 )
               {
                  subGridcustomer_Linesclass = subGridcustomer_Class+"Uniform";
               }
            }
            else if ( subGridcustomer_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridcustomer_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridcustomer_Class, "") != 0 )
               {
                  subGridcustomer_Linesclass = subGridcustomer_Class+"Odd";
               }
               subGridcustomer_Backcolor = (int)(0x0);
            }
            else if ( subGridcustomer_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridcustomer_Backstyle = 1;
               if ( ((int)((nGXsfl_14_idx) % (2))) == 0 )
               {
                  subGridcustomer_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridcustomer_Class, "") != 0 )
                  {
                     subGridcustomer_Linesclass = subGridcustomer_Class+"Even";
                  }
               }
               else
               {
                  subGridcustomer_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridcustomer_Class, "") != 0 )
                  {
                     subGridcustomer_Linesclass = subGridcustomer_Class+"Odd";
                  }
               }
            }
            if ( GridcustomerContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_14_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridcustomerContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridcustomerRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CustomerId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15CustomerId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)14,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridcustomerContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridcustomerRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerName_Internalname,(string)A16CustomerName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)14,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridcustomerContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridcustomerRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerDirectionDestination_Internalname,(string)A17CustomerDirectionDestination,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerDirectionDestination_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)14,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridcustomerContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A3CountryFlag_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A3CountryFlag))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001CountryFlag_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A3CountryFlag)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A3CountryFlag)) ? A40001CountryFlag_GXI : context.PathToRelativeUrl( A3CountryFlag));
            GridcustomerRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtCountryFlag_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A3CountryFlag_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridcustomerContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridcustomerRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCountryName_Internalname,(string)A2CountryName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCountryName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)14,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridcustomerContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridcustomerRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCartsqty_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5cartsQty), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5cartsQty), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCartsqty_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)14,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes1S2( ) ;
            GridcustomerContainer.AddRow(GridcustomerRow);
            nGXsfl_14_idx = ((subGridcustomer_Islastpage==1)&&(nGXsfl_14_idx+1>subGridcustomer_fnc_Recordsperpage( )) ? 1 : nGXsfl_14_idx+1);
            sGXsfl_14_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_idx), 4, 0), 4, "0");
            SubsflControlProps_142( ) ;
         }
         /* End function sendrow_142 */
      }

      protected void init_web_controls( )
      {
         dynavCountryid.Name = "vCOUNTRYID";
         dynavCountryid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void StartGridControl14( )
      {
         if ( GridcustomerContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridcustomerContainer"+"DivS\" data-gxgridid=\"14\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridcustomer_Internalname, subGridcustomer_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridcustomer_Backcolorstyle == 0 )
            {
               subGridcustomer_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridcustomer_Class) > 0 )
               {
                  subGridcustomer_Linesclass = subGridcustomer_Class+"Title";
               }
            }
            else
            {
               subGridcustomer_Titlebackstyle = 1;
               if ( subGridcustomer_Backcolorstyle == 1 )
               {
                  subGridcustomer_Titlebackcolor = subGridcustomer_Allbackcolor;
                  if ( StringUtil.Len( subGridcustomer_Class) > 0 )
                  {
                     subGridcustomer_Linesclass = subGridcustomer_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridcustomer_Class) > 0 )
                  {
                     subGridcustomer_Linesclass = subGridcustomer_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Customer Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Customer") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Direction Destination") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Country") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Carts Qty") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridcustomerContainer.AddObjectProperty("GridName", "Gridcustomer");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridcustomerContainer = new GXWebGrid( context);
            }
            else
            {
               GridcustomerContainer.Clear();
            }
            GridcustomerContainer.SetWrapped(nGXWrapped);
            GridcustomerContainer.AddObjectProperty("GridName", "Gridcustomer");
            GridcustomerContainer.AddObjectProperty("Header", subGridcustomer_Header);
            GridcustomerContainer.AddObjectProperty("Class", "Grid");
            GridcustomerContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridcustomerContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridcustomerContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcustomer_Backcolorstyle), 1, 0, ".", "")));
            GridcustomerContainer.AddObjectProperty("CmpContext", "");
            GridcustomerContainer.AddObjectProperty("InMasterPage", "false");
            GridcustomerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridcustomerColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CustomerId), 4, 0, ".", ""))));
            GridcustomerContainer.AddColumnProperties(GridcustomerColumn);
            GridcustomerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridcustomerColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A16CustomerName));
            GridcustomerContainer.AddColumnProperties(GridcustomerColumn);
            GridcustomerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridcustomerColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A17CustomerDirectionDestination));
            GridcustomerContainer.AddColumnProperties(GridcustomerColumn);
            GridcustomerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridcustomerColumn.AddObjectProperty("Value", context.convertURL( A3CountryFlag));
            GridcustomerContainer.AddColumnProperties(GridcustomerColumn);
            GridcustomerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridcustomerColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A2CountryName));
            GridcustomerContainer.AddColumnProperties(GridcustomerColumn);
            GridcustomerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridcustomerColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5cartsQty), 4, 0, ".", ""))));
            GridcustomerContainer.AddColumnProperties(GridcustomerColumn);
            GridcustomerContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcustomer_Selectedindex), 4, 0, ".", "")));
            GridcustomerContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcustomer_Allowselection), 1, 0, ".", "")));
            GridcustomerContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcustomer_Selectioncolor), 9, 0, ".", "")));
            GridcustomerContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcustomer_Allowhovering), 1, 0, ".", "")));
            GridcustomerContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcustomer_Hoveringcolor), 9, 0, ".", "")));
            GridcustomerContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcustomer_Allowcollapsing), 1, 0, ".", "")));
            GridcustomerContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcustomer_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         dynavCountryid_Internalname = "vCOUNTRYID";
         edtCustomerId_Internalname = "CUSTOMERID";
         edtCustomerName_Internalname = "CUSTOMERNAME";
         edtCustomerDirectionDestination_Internalname = "CUSTOMERDIRECTIONDESTINATION";
         edtCountryFlag_Internalname = "COUNTRYFLAG";
         edtCountryName_Internalname = "COUNTRYNAME";
         edtavCartsqty_Internalname = "vCARTSQTY";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridcustomer_Internalname = "GRIDCUSTOMER";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("ObligatorioShop", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridcustomer_Allowcollapsing = 0;
         subGridcustomer_Allowselection = 0;
         subGridcustomer_Header = "";
         edtavCartsqty_Jsonclick = "";
         edtCountryName_Jsonclick = "";
         edtCustomerDirectionDestination_Jsonclick = "";
         edtCustomerName_Jsonclick = "";
         edtCustomerId_Jsonclick = "";
         subGridcustomer_Class = "Grid";
         subGridcustomer_Backcolorstyle = 0;
         edtCountryName_Enabled = 0;
         edtCountryFlag_Enabled = 0;
         edtCustomerDirectionDestination_Enabled = 0;
         edtCustomerName_Enabled = 0;
         edtCustomerId_Enabled = 0;
         dynavCountryid_Jsonclick = "";
         dynavCountryid.Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Customers Shopping Carts Country";
         subGridcustomer_Rows = 5;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDCUSTOMER_nFirstRecordOnPage"},{"av":"GRIDCUSTOMER_nEOF"},{"av":"subGridcustomer_Rows","ctrl":"GRIDCUSTOMER","prop":"Rows"},{"av":"dynavCountryid"},{"av":"AV6CountryId","fld":"vCOUNTRYID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRIDCUSTOMER_FIRSTPAGE","""{"handler":"subgridcustomer_firstpage","iparms":[{"av":"GRIDCUSTOMER_nFirstRecordOnPage"},{"av":"GRIDCUSTOMER_nEOF"},{"av":"subGridcustomer_Rows","ctrl":"GRIDCUSTOMER","prop":"Rows"},{"av":"dynavCountryid"},{"av":"AV6CountryId","fld":"vCOUNTRYID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRIDCUSTOMER_PREVPAGE","""{"handler":"subgridcustomer_previouspage","iparms":[{"av":"GRIDCUSTOMER_nFirstRecordOnPage"},{"av":"GRIDCUSTOMER_nEOF"},{"av":"subGridcustomer_Rows","ctrl":"GRIDCUSTOMER","prop":"Rows"},{"av":"dynavCountryid"},{"av":"AV6CountryId","fld":"vCOUNTRYID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRIDCUSTOMER_NEXTPAGE","""{"handler":"subgridcustomer_nextpage","iparms":[{"av":"GRIDCUSTOMER_nFirstRecordOnPage"},{"av":"GRIDCUSTOMER_nEOF"},{"av":"subGridcustomer_Rows","ctrl":"GRIDCUSTOMER","prop":"Rows"},{"av":"dynavCountryid"},{"av":"AV6CountryId","fld":"vCOUNTRYID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRIDCUSTOMER_LASTPAGE","""{"handler":"subgridcustomer_lastpage","iparms":[{"av":"GRIDCUSTOMER_nFirstRecordOnPage"},{"av":"GRIDCUSTOMER_nEOF"},{"av":"subGridcustomer_Rows","ctrl":"GRIDCUSTOMER","prop":"Rows"},{"av":"dynavCountryid"},{"av":"AV6CountryId","fld":"vCOUNTRYID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_CUSTOMERID","""{"handler":"Valid_Customerid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Cartsqty","iparms":[]}""");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         GridcustomerContainer = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A16CustomerName = "";
         A17CustomerDirectionDestination = "";
         A3CountryFlag = "";
         A40001CountryFlag_GXI = "";
         A2CountryName = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H001S2_A1CountryId = new short[1] ;
         H001S2_A2CountryName = new string[] {""} ;
         H001S4_A1CountryId = new short[1] ;
         H001S4_A2CountryName = new string[] {""} ;
         H001S4_A40001CountryFlag_GXI = new string[] {""} ;
         H001S4_A17CustomerDirectionDestination = new string[] {""} ;
         H001S4_A16CustomerName = new string[] {""} ;
         H001S4_A15CustomerId = new short[1] ;
         H001S4_A40000GXC1 = new int[1] ;
         H001S4_n40000GXC1 = new bool[] {false} ;
         H001S4_A3CountryFlag = new string[] {""} ;
         H001S6_AGRIDCUSTOMER_nRecordCount = new long[1] ;
         GridcustomerRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridcustomer_Linesclass = "";
         ROClassString = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         GridcustomerColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.customersshoppingcartscountry__default(),
            new Object[][] {
                new Object[] {
               H001S2_A1CountryId, H001S2_A2CountryName
               }
               , new Object[] {
               H001S4_A1CountryId, H001S4_A2CountryName, H001S4_A40001CountryFlag_GXI, H001S4_A17CustomerDirectionDestination, H001S4_A16CustomerName, H001S4_A15CustomerId, H001S4_A40000GXC1, H001S4_n40000GXC1, H001S4_A3CountryFlag
               }
               , new Object[] {
               H001S6_AGRIDCUSTOMER_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRIDCUSTOMER_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6CountryId ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short A15CustomerId ;
      private short AV5cartsQty ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridcustomer_Backcolorstyle ;
      private short A1CountryId ;
      private short subGridcustomer_Backstyle ;
      private short subGridcustomer_Titlebackstyle ;
      private short subGridcustomer_Allowselection ;
      private short subGridcustomer_Allowhovering ;
      private short subGridcustomer_Allowcollapsing ;
      private short subGridcustomer_Collapsed ;
      private int nRC_GXsfl_14 ;
      private int subGridcustomer_Rows ;
      private int nGXsfl_14_idx=1 ;
      private int gxdynajaxindex ;
      private int subGridcustomer_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A40000GXC1 ;
      private int edtCustomerId_Enabled ;
      private int edtCustomerName_Enabled ;
      private int edtCustomerDirectionDestination_Enabled ;
      private int edtCountryFlag_Enabled ;
      private int edtCountryName_Enabled ;
      private int idxLst ;
      private int subGridcustomer_Backcolor ;
      private int subGridcustomer_Allbackcolor ;
      private int subGridcustomer_Titlebackcolor ;
      private int subGridcustomer_Selectedindex ;
      private int subGridcustomer_Selectioncolor ;
      private int subGridcustomer_Hoveringcolor ;
      private long GRIDCUSTOMER_nFirstRecordOnPage ;
      private long GRIDCUSTOMER_nCurrentRecord ;
      private long GRIDCUSTOMER_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_14_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string dynavCountryid_Internalname ;
      private string TempTags ;
      private string dynavCountryid_Jsonclick ;
      private string sStyleString ;
      private string subGridcustomer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtCustomerId_Internalname ;
      private string edtCustomerName_Internalname ;
      private string edtCustomerDirectionDestination_Internalname ;
      private string edtCountryFlag_Internalname ;
      private string edtCountryName_Internalname ;
      private string edtavCartsqty_Internalname ;
      private string gxwrpcisep ;
      private string sGXsfl_14_fel_idx="0001" ;
      private string subGridcustomer_Class ;
      private string subGridcustomer_Linesclass ;
      private string ROClassString ;
      private string edtCustomerId_Jsonclick ;
      private string edtCustomerName_Jsonclick ;
      private string edtCustomerDirectionDestination_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string edtCountryName_Jsonclick ;
      private string edtavCartsqty_Jsonclick ;
      private string subGridcustomer_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_14_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n40000GXC1 ;
      private bool returnInSub ;
      private bool A3CountryFlag_IsBlob ;
      private string A16CustomerName ;
      private string A17CustomerDirectionDestination ;
      private string A40001CountryFlag_GXI ;
      private string A2CountryName ;
      private string A3CountryFlag ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridcustomerContainer ;
      private GXWebRow GridcustomerRow ;
      private GXWebColumn GridcustomerColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavCountryid ;
      private IDataStoreProvider pr_default ;
      private short[] H001S2_A1CountryId ;
      private string[] H001S2_A2CountryName ;
      private short[] H001S4_A1CountryId ;
      private string[] H001S4_A2CountryName ;
      private string[] H001S4_A40001CountryFlag_GXI ;
      private string[] H001S4_A17CustomerDirectionDestination ;
      private string[] H001S4_A16CustomerName ;
      private short[] H001S4_A15CustomerId ;
      private int[] H001S4_A40000GXC1 ;
      private bool[] H001S4_n40000GXC1 ;
      private string[] H001S4_A3CountryFlag ;
      private long[] H001S6_AGRIDCUSTOMER_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class customersshoppingcartscountry__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001S4( IGxContext context ,
                                             short AV6CountryId ,
                                             short A1CountryId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[CountryId], T2.[CountryName], T2.[CountryFlag_GXI], T1.[CustomerDirectionDestination], T1.[CustomerName], T1.[CustomerId], COALESCE( T3.[GXC1], 0) AS GXC1, T2.[CountryFlag]";
         sFromString = " FROM (([Customer] T1 INNER JOIN [Country] T2 ON T2.[CountryId] = T1.[CountryId]) LEFT JOIN (SELECT COUNT(*) AS GXC1, [CustomerId] FROM [ShoppingCart] GROUP BY [CustomerId] ) T3 ON T3.[CustomerId] = T1.[CustomerId])";
         sOrderString = "";
         if ( ! (0==AV6CountryId) )
         {
            AddWhere(sWhereString, "(T1.[CountryId] = @AV6CountryId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY T1.[CustomerId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H001S6( IGxContext context ,
                                             short AV6CountryId ,
                                             short A1CountryId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (([Customer] T1 INNER JOIN [Country] T2 ON T2.[CountryId] = T1.[CountryId]) LEFT JOIN (SELECT COUNT(*) AS GXC1, [CustomerId] FROM [ShoppingCart] GROUP BY [CustomerId] ) T3 ON T3.[CustomerId] = T1.[CustomerId])";
         if ( ! (0==AV6CountryId) )
         {
            AddWhere(sWhereString, "(T1.[CountryId] = @AV6CountryId)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H001S4(context, (short)dynConstraints[0] , (short)dynConstraints[1] );
               case 2 :
                     return conditional_H001S6(context, (short)dynConstraints[0] , (short)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH001S2;
          prmH001S2 = new Object[] {
          };
          Object[] prmH001S4;
          prmH001S4 = new Object[] {
          new ParDef("@AV6CountryId",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001S6;
          prmH001S6 = new Object[] {
          new ParDef("@AV6CountryId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001S2", "SELECT [CountryId], [CountryName] FROM [Country] ORDER BY [CountryName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001S2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001S4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001S4,6, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001S6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001S6,1, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
