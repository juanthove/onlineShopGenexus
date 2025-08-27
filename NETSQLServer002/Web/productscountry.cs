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
   public class productscountry : GXDataArea
   {
      public productscountry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public productscountry( IGxContext context )
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
               GXDLVvCOUNTRYID1T2( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
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

      protected void gxnrGrid1_newrow_invoke( )
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
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         A11ProductName = GetPar( "ProductName");
         A41ProductCountryId = (short)(Math.Round(NumberUtil.Val( GetPar( "ProductCountryId"), "."), 18, MidpointRounding.ToEven));
         dynavCountryid.FromJSonString( GetNextPar( ));
         AV6CountryId = (short)(Math.Round(NumberUtil.Val( GetPar( "CountryId"), "."), 18, MidpointRounding.ToEven));
         A14ProductImage = GetPar( "ProductImage");
         A40000ProductImage_GXI = GetPar( "ProductImage_GXI");
         A13ProductPrice = NumberUtil.Val( GetPar( "ProductPrice"), ".");
         A42ProductCountryName = GetPar( "ProductCountryName");
         A5CategoryName = GetPar( "CategoryName");
         A8SellerPhoto = GetPar( "SellerPhoto");
         A40001SellerPhoto_GXI = GetPar( "SellerPhoto_GXI");
         A43ProductCountryFlag = GetPar( "ProductCountryFlag");
         A40002ProductCountryFlag_GXI = GetPar( "ProductCountryFlag_GXI");
         n40002ProductCountryFlag_GXI = false;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( A11ProductName, A41ProductCountryId, AV6CountryId, A14ProductImage, A40000ProductImage_GXI, A13ProductPrice, A42ProductCountryName, A5CategoryName, A8SellerPhoto, A40001SellerPhoto_GXI, A43ProductCountryFlag, A40002ProductCountryFlag_GXI) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
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
         PA1T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1T2( ) ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("productscountry.aspx") +"\">") ;
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
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_14", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_14), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME", A11ProductName);
         GxWebStd.gx_hidden_field( context, "PRODUCTCOUNTRYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41ProductCountryId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTIMAGE", A14ProductImage);
         GxWebStd.gx_hidden_field( context, "PRODUCTIMAGE_GXI", A40000ProductImage_GXI);
         GxWebStd.gx_hidden_field( context, "PRODUCTPRICE", StringUtil.LTrim( StringUtil.NToC( A13ProductPrice, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTCOUNTRYNAME", A42ProductCountryName);
         GxWebStd.gx_hidden_field( context, "CATEGORYNAME", A5CategoryName);
         GxWebStd.gx_hidden_field( context, "SELLERPHOTO", A8SellerPhoto);
         GxWebStd.gx_hidden_field( context, "SELLERPHOTO_GXI", A40001SellerPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "PRODUCTCOUNTRYFLAG", A43ProductCountryFlag);
         GxWebStd.gx_hidden_field( context, "PRODUCTCOUNTRYFLAG_GXI", A40002ProductCountryFlag_GXI);
         GxWebStd.gx_hidden_field( context, "subGrid1_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Recordcount), 5, 0, ",", "")));
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
            WE1T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1T2( ) ;
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
         return formatLink("productscountry.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ProductsCountry" ;
      }

      public override string GetPgmdesc( )
      {
         return "Products Country" ;
      }

      protected void WB1T0( )
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
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Products per Country", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_ProductsCountry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavCountryid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavCountryid_Internalname, "Country", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'" + sGXsfl_14_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCountryid, dynavCountryid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV6CountryId), 4, 0)), 1, dynavCountryid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavCountryid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,11);\"", "", false, 0, "HLP_ProductsCountry.htm");
            dynavCountryid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6CountryId), 4, 0));
            AssignProp("", false, dynavCountryid_Internalname, "Values", (string)(dynavCountryid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl14( ) ;
         }
         if ( wbEnd == 14 )
         {
            wbEnd = 0;
            nRC_GXsfl_14 = (int)(nGXsfl_14_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
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
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START1T2( )
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
         Form.Meta.addItem("description", "Products Country", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1T0( ) ;
      }

      protected void WS1T2( )
      {
         START1T2( ) ;
         EVT1T2( ) ;
      }

      protected void EVT1T2( )
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
                              AV8ProductName = cgiGet( edtavProductname_Internalname);
                              AssignAttri("", false, edtavProductname_Internalname, AV8ProductName);
                              AV9ProductImage = cgiGet( edtavProductimage_Internalname);
                              AssignProp("", false, edtavProductimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV9ProductImage)) ? AV19Productimage_GXI : context.convertURL( context.PathToRelativeUrl( AV9ProductImage))), !bGXsfl_14_Refreshing);
                              AssignProp("", false, edtavProductimage_Internalname, "SrcSet", context.GetImageSrcSet( AV9ProductImage), true);
                              AV17ProductPrice = context.localUtil.CToN( cgiGet( edtavProductprice_Internalname), ",", ".");
                              AssignAttri("", false, edtavProductprice_Internalname, StringUtil.LTrimStr( AV17ProductPrice, 18, 2));
                              AV11ProductCountryName = cgiGet( edtavProductcountryname_Internalname);
                              AssignAttri("", false, edtavProductcountryname_Internalname, AV11ProductCountryName);
                              AV16ProductCountryFlag = cgiGet( edtavProductcountryflag_Internalname);
                              AssignProp("", false, edtavProductcountryflag_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV16ProductCountryFlag)) ? AV21Productcountryflag_GXI : context.convertURL( context.PathToRelativeUrl( AV16ProductCountryFlag))), !bGXsfl_14_Refreshing);
                              AssignProp("", false, edtavProductcountryflag_Internalname, "SrcSet", context.GetImageSrcSet( AV16ProductCountryFlag), true);
                              AV12CategoryName = cgiGet( edtavCategoryname_Internalname);
                              AssignAttri("", false, edtavCategoryname_Internalname, AV12CategoryName);
                              AV13SellerPhoto = cgiGet( edtavSellerphoto_Internalname);
                              AssignProp("", false, edtavSellerphoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13SellerPhoto)) ? AV20Sellerphoto_GXI : context.convertURL( context.PathToRelativeUrl( AV13SellerPhoto))), !bGXsfl_14_Refreshing);
                              AssignProp("", false, edtavSellerphoto_Internalname, "SrcSet", context.GetImageSrcSet( AV13SellerPhoto), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E111T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
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

      protected void WE1T2( )
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

      protected void PA1T2( )
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

      protected void GXDLVvCOUNTRYID1T2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCOUNTRYID_data1T2( ) ;
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

      protected void GXVvCOUNTRYID_html1T2( )
      {
         short gxdynajaxvalue;
         GXDLVvCOUNTRYID_data1T2( ) ;
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

      protected void GXDLVvCOUNTRYID_data1T2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("All");
         /* Using cursor H001T2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H001T2_A1CountryId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H001T2_A2CountryName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_142( ) ;
         while ( nGXsfl_14_idx <= nRC_GXsfl_14 )
         {
            sendrow_142( ) ;
            nGXsfl_14_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_14_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_14_idx+1);
            sGXsfl_14_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_idx), 4, 0), 4, "0");
            SubsflControlProps_142( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( string A11ProductName ,
                                        short A41ProductCountryId ,
                                        short AV6CountryId ,
                                        string A14ProductImage ,
                                        string A40000ProductImage_GXI ,
                                        decimal A13ProductPrice ,
                                        string A42ProductCountryName ,
                                        string A5CategoryName ,
                                        string A8SellerPhoto ,
                                        string A40001SellerPhoto_GXI ,
                                        string A43ProductCountryFlag ,
                                        string A40002ProductCountryFlag_GXI )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF1T2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvCOUNTRYID_html1T2( ) ;
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
         RF1T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF1T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 14;
         nGXsfl_14_idx = 1;
         sGXsfl_14_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_idx), 4, 0), 4, "0");
         SubsflControlProps_142( ) ;
         bGXsfl_14_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "Grid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         if ( subGrid1_Islastpage != 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordcount( )-subGrid1_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
            Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_142( ) ;
            /* Execute user event: Load */
            E111T2 ();
            wbEnd = 14;
            WB1T0( ) ;
         }
         bGXsfl_14_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1T2( )
      {
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         GXVvCOUNTRYID_html1T2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1T0( )
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
            subGrid1_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGrid1_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      private void E111T2( )
      {
         /* Load Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV6CountryId ,
                                              A41ProductCountryId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor H001T3 */
         pr_default.execute(1, new Object[] {AV6CountryId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A6SellerId = H001T3_A6SellerId[0];
            A4CategoryId = H001T3_A4CategoryId[0];
            A41ProductCountryId = H001T3_A41ProductCountryId[0];
            A40000ProductImage_GXI = H001T3_A40000ProductImage_GXI[0];
            A40001SellerPhoto_GXI = H001T3_A40001SellerPhoto_GXI[0];
            A40002ProductCountryFlag_GXI = H001T3_A40002ProductCountryFlag_GXI[0];
            n40002ProductCountryFlag_GXI = H001T3_n40002ProductCountryFlag_GXI[0];
            A13ProductPrice = H001T3_A13ProductPrice[0];
            A42ProductCountryName = H001T3_A42ProductCountryName[0];
            A5CategoryName = H001T3_A5CategoryName[0];
            A11ProductName = H001T3_A11ProductName[0];
            A14ProductImage = H001T3_A14ProductImage[0];
            A8SellerPhoto = H001T3_A8SellerPhoto[0];
            A43ProductCountryFlag = H001T3_A43ProductCountryFlag[0];
            A40001SellerPhoto_GXI = H001T3_A40001SellerPhoto_GXI[0];
            A8SellerPhoto = H001T3_A8SellerPhoto[0];
            A5CategoryName = H001T3_A5CategoryName[0];
            A40002ProductCountryFlag_GXI = H001T3_A40002ProductCountryFlag_GXI[0];
            n40002ProductCountryFlag_GXI = H001T3_n40002ProductCountryFlag_GXI[0];
            A42ProductCountryName = H001T3_A42ProductCountryName[0];
            A43ProductCountryFlag = H001T3_A43ProductCountryFlag[0];
            AV8ProductName = A11ProductName;
            AssignAttri("", false, edtavProductname_Internalname, AV8ProductName);
            AV9ProductImage = A14ProductImage;
            AssignAttri("", false, edtavProductimage_Internalname, AV9ProductImage);
            AV19Productimage_GXI = A40000ProductImage_GXI;
            AV17ProductPrice = A13ProductPrice;
            AssignAttri("", false, edtavProductprice_Internalname, StringUtil.LTrimStr( AV17ProductPrice, 18, 2));
            AV11ProductCountryName = A42ProductCountryName;
            AssignAttri("", false, edtavProductcountryname_Internalname, AV11ProductCountryName);
            AV12CategoryName = A5CategoryName;
            AssignAttri("", false, edtavCategoryname_Internalname, AV12CategoryName);
            AV13SellerPhoto = A8SellerPhoto;
            AssignAttri("", false, edtavSellerphoto_Internalname, AV13SellerPhoto);
            AV20Sellerphoto_GXI = A40001SellerPhoto_GXI;
            AV16ProductCountryFlag = A43ProductCountryFlag;
            AssignAttri("", false, edtavProductcountryflag_Internalname, AV16ProductCountryFlag);
            AV21Productcountryflag_GXI = A40002ProductCountryFlag_GXI;
            sendrow_142( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_14_Refreshing )
            {
               DoAjaxLoad(14, Grid1Row);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         PA1T2( ) ;
         WS1T2( ) ;
         WE1T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411250211611", true, true);
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
            context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 239440), false, true);
            context.AddJavascriptSource("productscountry.js", "?202411250211612", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_142( )
      {
         edtavProductname_Internalname = "vPRODUCTNAME_"+sGXsfl_14_idx;
         edtavProductimage_Internalname = "vPRODUCTIMAGE_"+sGXsfl_14_idx;
         edtavProductprice_Internalname = "vPRODUCTPRICE_"+sGXsfl_14_idx;
         edtavProductcountryname_Internalname = "vPRODUCTCOUNTRYNAME_"+sGXsfl_14_idx;
         edtavProductcountryflag_Internalname = "vPRODUCTCOUNTRYFLAG_"+sGXsfl_14_idx;
         edtavCategoryname_Internalname = "vCATEGORYNAME_"+sGXsfl_14_idx;
         edtavSellerphoto_Internalname = "vSELLERPHOTO_"+sGXsfl_14_idx;
      }

      protected void SubsflControlProps_fel_142( )
      {
         edtavProductname_Internalname = "vPRODUCTNAME_"+sGXsfl_14_fel_idx;
         edtavProductimage_Internalname = "vPRODUCTIMAGE_"+sGXsfl_14_fel_idx;
         edtavProductprice_Internalname = "vPRODUCTPRICE_"+sGXsfl_14_fel_idx;
         edtavProductcountryname_Internalname = "vPRODUCTCOUNTRYNAME_"+sGXsfl_14_fel_idx;
         edtavProductcountryflag_Internalname = "vPRODUCTCOUNTRYFLAG_"+sGXsfl_14_fel_idx;
         edtavCategoryname_Internalname = "vCATEGORYNAME_"+sGXsfl_14_fel_idx;
         edtavSellerphoto_Internalname = "vSELLERPHOTO_"+sGXsfl_14_fel_idx;
      }

      protected void sendrow_142( )
      {
         sGXsfl_14_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_idx), 4, 0), 4, "0");
         SubsflControlProps_142( ) ;
         WB1T0( ) ;
         Grid1Row = GXWebRow.GetNew(context,Grid1Container);
         if ( subGrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
         }
         else if ( subGrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid1_Backstyle = 0;
            subGrid1_Backcolor = subGrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Uniform";
            }
         }
         else if ( subGrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
            subGrid1_Backcolor = (int)(0x0);
         }
         else if ( subGrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_14_idx) % (2))) == 0 )
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Even";
               }
            }
            else
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_14_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavProductname_Internalname,(string)AV8ProductName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavProductname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)14,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute" + " " + ((StringUtil.StrCmp(edtavProductimage_gximage, "")==0) ? "" : "GX_Image_"+edtavProductimage_gximage+"_Class");
         StyleString = "";
         AV9ProductImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV9ProductImage))&&String.IsNullOrEmpty(StringUtil.RTrim( AV19Productimage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV9ProductImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV9ProductImage)) ? AV19Productimage_GXI : context.PathToRelativeUrl( AV9ProductImage));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavProductimage_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV9ProductImage_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavProductprice_Internalname,StringUtil.LTrim( StringUtil.NToC( AV17ProductPrice, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( AV17ProductPrice, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavProductprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)14,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavProductcountryname_Internalname,(string)AV11ProductCountryName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavProductcountryname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)14,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute" + " " + ((StringUtil.StrCmp(edtavProductcountryflag_gximage, "")==0) ? "" : "GX_Image_"+edtavProductcountryflag_gximage+"_Class");
         StyleString = "";
         AV16ProductCountryFlag_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV16ProductCountryFlag))&&String.IsNullOrEmpty(StringUtil.RTrim( AV21Productcountryflag_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV16ProductCountryFlag)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV16ProductCountryFlag)) ? AV21Productcountryflag_GXI : context.PathToRelativeUrl( AV16ProductCountryFlag));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavProductcountryflag_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV16ProductCountryFlag_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCategoryname_Internalname,(string)AV12CategoryName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCategoryname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)14,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute" + " " + ((StringUtil.StrCmp(edtavSellerphoto_gximage, "")==0) ? "" : "GX_Image_"+edtavSellerphoto_gximage+"_Class");
         StyleString = "";
         AV13SellerPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV13SellerPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( AV20Sellerphoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV13SellerPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV13SellerPhoto)) ? AV20Sellerphoto_GXI : context.PathToRelativeUrl( AV13SellerPhoto));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavSellerphoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV13SellerPhoto_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes1T2( ) ;
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_14_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_14_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_14_idx+1);
         sGXsfl_14_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_14_idx), 4, 0), 4, "0");
         SubsflControlProps_142( ) ;
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
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"14\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+" "+((StringUtil.StrCmp(edtavProductimage_gximage, "")==0) ? "" : "GX_Image_"+edtavProductimage_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Image") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Product Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Country") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+" "+((StringUtil.StrCmp(edtavProductcountryflag_gximage, "")==0) ? "" : "GX_Image_"+edtavProductcountryflag_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Category") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+" "+((StringUtil.StrCmp(edtavSellerphoto_gximage, "")==0) ? "" : "GX_Image_"+edtavSellerphoto_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Seller") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "Grid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV8ProductName));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV9ProductImage));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( AV17ProductPrice, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV11ProductCountryName));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV16ProductCountryFlag));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV12CategoryName));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV13SellerPhoto));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         dynavCountryid_Internalname = "vCOUNTRYID";
         edtavProductname_Internalname = "vPRODUCTNAME";
         edtavProductimage_Internalname = "vPRODUCTIMAGE";
         edtavProductprice_Internalname = "vPRODUCTPRICE";
         edtavProductcountryname_Internalname = "vPRODUCTCOUNTRYNAME";
         edtavProductcountryflag_Internalname = "vPRODUCTCOUNTRYFLAG";
         edtavCategoryname_Internalname = "vCATEGORYNAME";
         edtavSellerphoto_Internalname = "vSELLERPHOTO";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("ObligatorioShop", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtavSellerphoto_gximage = "";
         edtavCategoryname_Jsonclick = "";
         edtavProductcountryflag_gximage = "";
         edtavProductcountryname_Jsonclick = "";
         edtavProductprice_Jsonclick = "";
         edtavProductimage_gximage = "";
         edtavProductname_Jsonclick = "";
         subGrid1_Class = "Grid";
         subGrid1_Backcolorstyle = 0;
         dynavCountryid_Jsonclick = "";
         dynavCountryid.Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Products Country";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"A11ProductName","fld":"PRODUCTNAME"},{"av":"A41ProductCountryId","fld":"PRODUCTCOUNTRYID","pic":"ZZZ9"},{"av":"A14ProductImage","fld":"PRODUCTIMAGE"},{"av":"A40000ProductImage_GXI","fld":"PRODUCTIMAGE_GXI"},{"av":"A13ProductPrice","fld":"PRODUCTPRICE","pic":"ZZZZZZZZZZZZZZ9.99"},{"av":"A42ProductCountryName","fld":"PRODUCTCOUNTRYNAME"},{"av":"A5CategoryName","fld":"CATEGORYNAME"},{"av":"A8SellerPhoto","fld":"SELLERPHOTO"},{"av":"A40001SellerPhoto_GXI","fld":"SELLERPHOTO_GXI"},{"av":"A43ProductCountryFlag","fld":"PRODUCTCOUNTRYFLAG"},{"av":"A40002ProductCountryFlag_GXI","fld":"PRODUCTCOUNTRYFLAG_GXI"},{"av":"dynavCountryid"},{"av":"AV6CountryId","fld":"vCOUNTRYID","pic":"ZZZ9"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Sellerphoto","iparms":[]}""");
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
         A11ProductName = "";
         A14ProductImage = "";
         A40000ProductImage_GXI = "";
         A42ProductCountryName = "";
         A5CategoryName = "";
         A8SellerPhoto = "";
         A40001SellerPhoto_GXI = "";
         A43ProductCountryFlag = "";
         A40002ProductCountryFlag_GXI = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV8ProductName = "";
         AV9ProductImage = "";
         AV19Productimage_GXI = "";
         AV11ProductCountryName = "";
         AV16ProductCountryFlag = "";
         AV21Productcountryflag_GXI = "";
         AV12CategoryName = "";
         AV13SellerPhoto = "";
         AV20Sellerphoto_GXI = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H001T2_A1CountryId = new short[1] ;
         H001T2_A2CountryName = new string[] {""} ;
         H001T3_A10ProductId = new short[1] ;
         H001T3_A6SellerId = new short[1] ;
         H001T3_A4CategoryId = new short[1] ;
         H001T3_A41ProductCountryId = new short[1] ;
         H001T3_A40000ProductImage_GXI = new string[] {""} ;
         H001T3_A40001SellerPhoto_GXI = new string[] {""} ;
         H001T3_A40002ProductCountryFlag_GXI = new string[] {""} ;
         H001T3_n40002ProductCountryFlag_GXI = new bool[] {false} ;
         H001T3_A13ProductPrice = new decimal[1] ;
         H001T3_A42ProductCountryName = new string[] {""} ;
         H001T3_A5CategoryName = new string[] {""} ;
         H001T3_A11ProductName = new string[] {""} ;
         H001T3_A14ProductImage = new string[] {""} ;
         H001T3_A8SellerPhoto = new string[] {""} ;
         H001T3_A43ProductCountryFlag = new string[] {""} ;
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         ROClassString = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productscountry__default(),
            new Object[][] {
                new Object[] {
               H001T2_A1CountryId, H001T2_A2CountryName
               }
               , new Object[] {
               H001T3_A10ProductId, H001T3_A6SellerId, H001T3_A4CategoryId, H001T3_A41ProductCountryId, H001T3_A40000ProductImage_GXI, H001T3_A40001SellerPhoto_GXI, H001T3_A40002ProductCountryFlag_GXI, H001T3_n40002ProductCountryFlag_GXI, H001T3_A13ProductPrice, H001T3_A42ProductCountryName,
               H001T3_A5CategoryName, H001T3_A11ProductName, H001T3_A14ProductImage, H001T3_A8SellerPhoto, H001T3_A43ProductCountryFlag
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short A41ProductCountryId ;
      private short AV6CountryId ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short A6SellerId ;
      private short A4CategoryId ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short GRID1_nEOF ;
      private int nRC_GXsfl_14 ;
      private int subGrid1_Recordcount ;
      private int nGXsfl_14_idx=1 ;
      private int gxdynajaxindex ;
      private int subGrid1_Islastpage ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nFirstRecordOnPage ;
      private decimal A13ProductPrice ;
      private decimal AV17ProductPrice ;
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
      private string subGrid1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavProductname_Internalname ;
      private string edtavProductimage_Internalname ;
      private string edtavProductprice_Internalname ;
      private string edtavProductcountryname_Internalname ;
      private string edtavProductcountryflag_Internalname ;
      private string edtavCategoryname_Internalname ;
      private string edtavSellerphoto_Internalname ;
      private string gxwrpcisep ;
      private string sGXsfl_14_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtavProductname_Jsonclick ;
      private string ClassString ;
      private string edtavProductimage_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string edtavProductprice_Jsonclick ;
      private string edtavProductcountryname_Jsonclick ;
      private string edtavProductcountryflag_gximage ;
      private string edtavCategoryname_Jsonclick ;
      private string edtavSellerphoto_gximage ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n40002ProductCountryFlag_GXI ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_14_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9ProductImage_IsBlob ;
      private bool AV16ProductCountryFlag_IsBlob ;
      private bool AV13SellerPhoto_IsBlob ;
      private string A11ProductName ;
      private string A40000ProductImage_GXI ;
      private string A42ProductCountryName ;
      private string A5CategoryName ;
      private string A40001SellerPhoto_GXI ;
      private string A40002ProductCountryFlag_GXI ;
      private string AV8ProductName ;
      private string AV19Productimage_GXI ;
      private string AV11ProductCountryName ;
      private string AV21Productcountryflag_GXI ;
      private string AV12CategoryName ;
      private string AV20Sellerphoto_GXI ;
      private string A14ProductImage ;
      private string A8SellerPhoto ;
      private string A43ProductCountryFlag ;
      private string AV9ProductImage ;
      private string AV16ProductCountryFlag ;
      private string AV13SellerPhoto ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavCountryid ;
      private IDataStoreProvider pr_default ;
      private short[] H001T2_A1CountryId ;
      private string[] H001T2_A2CountryName ;
      private short[] H001T3_A10ProductId ;
      private short[] H001T3_A6SellerId ;
      private short[] H001T3_A4CategoryId ;
      private short[] H001T3_A41ProductCountryId ;
      private string[] H001T3_A40000ProductImage_GXI ;
      private string[] H001T3_A40001SellerPhoto_GXI ;
      private string[] H001T3_A40002ProductCountryFlag_GXI ;
      private bool[] H001T3_n40002ProductCountryFlag_GXI ;
      private decimal[] H001T3_A13ProductPrice ;
      private string[] H001T3_A42ProductCountryName ;
      private string[] H001T3_A5CategoryName ;
      private string[] H001T3_A11ProductName ;
      private string[] H001T3_A14ProductImage ;
      private string[] H001T3_A8SellerPhoto ;
      private string[] H001T3_A43ProductCountryFlag ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class productscountry__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001T3( IGxContext context ,
                                             short AV6CountryId ,
                                             short A41ProductCountryId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ProductId], T1.[SellerId], T1.[CategoryId], T1.[ProductCountryId] AS ProductCountryId, T1.[ProductImage_GXI], T2.[SellerPhoto_GXI], T4.[CountryFlag_GXI] AS ProductCountryFlag_GXI, T1.[ProductPrice], T4.[CountryName] AS ProductCountryName, T3.[CategoryName], T1.[ProductName], T1.[ProductImage], T2.[SellerPhoto], T4.[CountryFlag] AS ProductCountryFlag FROM ((([Product] T1 INNER JOIN [Seller] T2 ON T2.[SellerId] = T1.[SellerId]) INNER JOIN [Category] T3 ON T3.[CategoryId] = T1.[CategoryId]) INNER JOIN [Country] T4 ON T4.[CountryId] = T1.[ProductCountryId])";
         if ( ! (0==AV6CountryId) )
         {
            AddWhere(sWhereString, "(T1.[ProductCountryId] = @AV6CountryId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProductName]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H001T3(context, (short)dynConstraints[0] , (short)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH001T2;
          prmH001T2 = new Object[] {
          };
          Object[] prmH001T3;
          prmH001T3 = new Object[] {
          new ParDef("@AV6CountryId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001T2", "SELECT [CountryId], [CountryName] FROM [Country] ORDER BY [CountryName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001T2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001T3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001T3,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(5));
                ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(6));
                ((string[]) buf[14])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(7));
                return;
       }
    }

 }

}
