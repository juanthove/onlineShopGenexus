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
   public class sellerproducts : GXDataArea
   {
      public sellerproducts( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public sellerproducts( IGxContext context )
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridproduct") == 0 )
            {
               gxnrGridproduct_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridproduct") == 0 )
            {
               gxgrGridproduct_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridseller") == 0 )
            {
               gxnrGridseller_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridseller") == 0 )
            {
               gxgrGridseller_refresh_invoke( ) ;
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

      protected void gxnrGridproduct_newrow_invoke( )
      {
         nRC_GXsfl_22 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_22"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_22_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_22_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_22_idx = GetPar( "sGXsfl_22_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridproduct_newrow( ) ;
         /* End function gxnrGridproduct_newrow_invoke */
      }

      protected void gxgrGridproduct_refresh_invoke( )
      {
         A6SellerId = (short)(Math.Round(NumberUtil.Val( GetPar( "SellerId"), "."), 18, MidpointRounding.ToEven));
         AV5Total = (short)(Math.Round(NumberUtil.Val( GetPar( "Total"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridproduct_refresh( A6SellerId, AV5Total) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridproduct_refresh_invoke */
      }

      protected void gxnrGridseller_newrow_invoke( )
      {
         nRC_GXsfl_9 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_9"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_9_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_9_idx = GetPar( "sGXsfl_9_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridseller_newrow( ) ;
         /* End function gxnrGridseller_newrow_invoke */
      }

      protected void gxgrGridseller_refresh_invoke( )
      {
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridseller_refresh( ) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridseller_refresh_invoke */
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
         PA1N2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1N2( ) ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sellerproducts.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_9", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_9), 8, 0, ",", "")));
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
            WE1N2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1N2( ) ;
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
         return formatLink("sellerproducts.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SellerProducts" ;
      }

      public override string GetPgmdesc( )
      {
         return "Seller Products" ;
      }

      protected void WB1N0( )
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
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Sellers and Products", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_SellerProducts.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridsellerContainer.SetIsFreestyle(true);
            GridsellerContainer.SetWrapped(nGXWrapped);
            StartGridControl9( ) ;
         }
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            nRC_GXsfl_9 = (int)(nGXsfl_9_idx-1);
            if ( GridsellerContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridsellerContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridseller", GridsellerContainer, subGridseller_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsellerContainerData", GridsellerContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsellerContainerData"+"V", GridsellerContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsellerContainerData"+"V"+"\" value='"+GridsellerContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridsellerContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridsellerContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridseller", GridsellerContainer, subGridseller_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsellerContainerData", GridsellerContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsellerContainerData"+"V", GridsellerContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsellerContainerData"+"V"+"\" value='"+GridsellerContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 22 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridproductContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridproductContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridproduct", GridproductContainer, subGridproduct_Internalname);
                  if ( ! isAjaxCallMode( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridproductContainerData", GridproductContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridproductContainerData"+"V", GridproductContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridproductContainerData"+"V"+"\" value='"+GridproductContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START1N2( )
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
         Form.Meta.addItem("description", "Seller Products", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1N0( ) ;
      }

      protected void WS1N2( )
      {
         START1N2( ) ;
         EVT1N2( ) ;
      }

      protected void EVT1N2( )
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "GRIDSELLER.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "GRIDPRODUCT.LOAD") == 0 ) )
                           {
                              nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
                              SubsflControlProps_92( ) ;
                              A8SellerPhoto = cgiGet( edtSellerPhoto_Internalname);
                              AssignProp("", false, edtSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8SellerPhoto)) ? A40000SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A8SellerPhoto))), !bGXsfl_9_Refreshing);
                              AssignProp("", false, edtSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A8SellerPhoto), true);
                              A7SellerName = cgiGet( edtSellerName_Internalname);
                              AV5Total = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavTotal_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, edtavTotal_Internalname, StringUtil.LTrimStr( (decimal)(AV5Total), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRIDSELLER.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridseller.Load */
                                    E111N2 ();
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
                                 sEvtType = StringUtil.Right( sEvt, 4);
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                                 if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "GRIDPRODUCT.LOAD") == 0 )
                                 {
                                    nGXsfl_22_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                                    sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0") + sGXsfl_9_idx;
                                    SubsflControlProps_223( ) ;
                                    A10ProductId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                    A11ProductName = cgiGet( edtProductName_Internalname);
                                    A14ProductImage = cgiGet( edtProductImage_Internalname);
                                    AssignProp("", false, edtProductImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage)) ? A40002ProductImage_GXI : context.convertURL( context.PathToRelativeUrl( A14ProductImage))), !bGXsfl_22_Refreshing);
                                    AssignProp("", false, edtProductImage_Internalname, "SrcSet", context.GetImageSrcSet( A14ProductImage), true);
                                    A5CategoryName = cgiGet( edtCategoryName_Internalname);
                                    A13ProductPrice = context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ",", ".");
                                    sEvtType = StringUtil.Right( sEvt, 1);
                                    if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                                    {
                                       sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                       if ( StringUtil.StrCmp(sEvt, "GRIDPRODUCT.LOAD") == 0 )
                                       {
                                          context.wbHandled = 1;
                                          dynload_actions( ) ;
                                          /* Execute user event: Gridproduct.Load */
                                          E121N3 ();
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
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE1N2( )
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

      protected void PA1N2( )
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridseller_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_92( ) ;
         while ( nGXsfl_9_idx <= nRC_GXsfl_9 )
         {
            sendrow_92( ) ;
            nGXsfl_9_idx = ((subGridseller_Islastpage==1)&&(nGXsfl_9_idx+1>subGridseller_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsellerContainer)) ;
         /* End function gxnrGridseller_newrow */
      }

      protected void gxnrGridproduct_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_223( ) ;
         while ( nGXsfl_22_idx <= nRC_GXsfl_22 )
         {
            sendrow_223( ) ;
            nGXsfl_22_idx = ((subGridproduct_Islastpage==1)&&(nGXsfl_22_idx+1>subGridproduct_fnc_Recordsperpage( )) ? 1 : nGXsfl_22_idx+1);
            sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0") + sGXsfl_9_idx;
            SubsflControlProps_223( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridproductContainer)) ;
         /* End function gxnrGridproduct_newrow */
      }

      protected void gxgrGridproduct_refresh( short A6SellerId ,
                                              short AV5Total )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDPRODUCT_nCurrentRecord = 0;
         RF1N3( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridproduct_refresh */
      }

      protected void gxgrGridseller_refresh( )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDSELLER_nCurrentRecord = 0;
         RF1N2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridseller_refresh */
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
         RF1N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF1N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsellerContainer.ClearRows();
         }
         wbStart = 9;
         nGXsfl_9_idx = 1;
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         bGXsfl_9_Refreshing = true;
         GridsellerContainer.AddObjectProperty("GridName", "Gridseller");
         GridsellerContainer.AddObjectProperty("CmpContext", "");
         GridsellerContainer.AddObjectProperty("InMasterPage", "false");
         GridsellerContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridsellerContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridsellerContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridsellerContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridsellerContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridseller_Backcolorstyle), 1, 0, ".", "")));
         GridsellerContainer.PageSize = subGridseller_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_92( ) ;
            /* Using cursor H001N2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A6SellerId = H001N2_A6SellerId[0];
               A7SellerName = H001N2_A7SellerName[0];
               A40000SellerPhoto_GXI = H001N2_A40000SellerPhoto_GXI[0];
               AssignProp("", false, edtSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8SellerPhoto)) ? A40000SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A8SellerPhoto))), !bGXsfl_9_Refreshing);
               AssignProp("", false, edtSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A8SellerPhoto), true);
               A8SellerPhoto = H001N2_A8SellerPhoto[0];
               AssignProp("", false, edtSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8SellerPhoto)) ? A40000SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A8SellerPhoto))), !bGXsfl_9_Refreshing);
               AssignProp("", false, edtSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A8SellerPhoto), true);
               /* Execute user event: Gridseller.Load */
               E111N2 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 9;
            WB1N0( ) ;
         }
         bGXsfl_9_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1N2( )
      {
      }

      protected void RF1N3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridproductContainer.ClearRows();
         }
         wbStart = 22;
         nGXsfl_22_idx = 1;
         sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0") + sGXsfl_9_idx;
         SubsflControlProps_223( ) ;
         bGXsfl_22_Refreshing = true;
         GridproductContainer.AddObjectProperty("GridName", "Gridproduct");
         GridproductContainer.AddObjectProperty("CmpContext", "");
         GridproductContainer.AddObjectProperty("InMasterPage", "false");
         GridproductContainer.AddObjectProperty("Class", "Grid");
         GridproductContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridproductContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridproductContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproduct_Backcolorstyle), 1, 0, ".", "")));
         GridproductContainer.PageSize = subGridproduct_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_223( ) ;
            /* Using cursor H001N3 */
            pr_default.execute(1, new Object[] {A6SellerId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A4CategoryId = H001N3_A4CategoryId[0];
               A13ProductPrice = H001N3_A13ProductPrice[0];
               A5CategoryName = H001N3_A5CategoryName[0];
               A40002ProductImage_GXI = H001N3_A40002ProductImage_GXI[0];
               AssignProp("", false, edtProductImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage)) ? A40002ProductImage_GXI : context.convertURL( context.PathToRelativeUrl( A14ProductImage))), !bGXsfl_22_Refreshing);
               AssignProp("", false, edtProductImage_Internalname, "SrcSet", context.GetImageSrcSet( A14ProductImage), true);
               A11ProductName = H001N3_A11ProductName[0];
               A10ProductId = H001N3_A10ProductId[0];
               A14ProductImage = H001N3_A14ProductImage[0];
               AssignProp("", false, edtProductImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage)) ? A40002ProductImage_GXI : context.convertURL( context.PathToRelativeUrl( A14ProductImage))), !bGXsfl_22_Refreshing);
               AssignProp("", false, edtProductImage_Internalname, "SrcSet", context.GetImageSrcSet( A14ProductImage), true);
               A5CategoryName = H001N3_A5CategoryName[0];
               /* Execute user event: Gridproduct.Load */
               E121N3 ();
               pr_default.readNext(1);
            }
            pr_default.close(1);
            wbEnd = 22;
            WB1N0( ) ;
         }
         bGXsfl_22_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1N3( )
      {
      }

      protected int subGridseller_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridseller_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridseller_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridseller_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridproduct_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridproduct_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridproduct_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridproduct_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         edtSellerPhoto_Enabled = 0;
         edtSellerName_Enabled = 0;
         edtProductId_Enabled = 0;
         edtProductName_Enabled = 0;
         edtProductImage_Enabled = 0;
         edtCategoryName_Enabled = 0;
         edtProductPrice_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_9"), ",", "."), 18, MidpointRounding.ToEven));
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

      private void E111N2( )
      {
         /* Gridseller_Load Routine */
         returnInSub = false;
         AV5Total = 0;
         AssignAttri("", false, edtavTotal_Internalname, StringUtil.LTrimStr( (decimal)(AV5Total), 4, 0));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 9;
         }
         sendrow_92( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
         {
            DoAjaxLoad(9, GridsellerRow);
         }
         /*  Sending Event outputs  */
      }

      private void E121N3( )
      {
         /* Gridproduct_Load Routine */
         returnInSub = false;
         AV5Total = (short)(AV5Total+1);
         AssignAttri("", false, edtavTotal_Internalname, StringUtil.LTrimStr( (decimal)(AV5Total), 4, 0));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 22;
         }
         sendrow_223( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_22_Refreshing )
         {
            DoAjaxLoad(22, GridproductRow);
         }
         /*  Sending Event outputs  */
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
         PA1N2( ) ;
         WS1N2( ) ;
         WE1N2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024111118355313", true, true);
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
            context.AddJavascriptSource("sellerproducts.js", "?2024111118355314", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_223( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_22_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_22_idx;
         edtProductImage_Internalname = "PRODUCTIMAGE_"+sGXsfl_22_idx;
         edtCategoryName_Internalname = "CATEGORYNAME_"+sGXsfl_22_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_22_idx;
      }

      protected void SubsflControlProps_fel_223( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_22_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_22_fel_idx;
         edtProductImage_Internalname = "PRODUCTIMAGE_"+sGXsfl_22_fel_idx;
         edtCategoryName_Internalname = "CATEGORYNAME_"+sGXsfl_22_fel_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_22_fel_idx;
      }

      protected void sendrow_223( )
      {
         sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0") + sGXsfl_9_idx;
         SubsflControlProps_223( ) ;
         WB1N0( ) ;
         GridproductRow = GXWebRow.GetNew(context,GridproductContainer);
         if ( subGridproduct_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridproduct_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridproduct_Class, "") != 0 )
            {
               subGridproduct_Linesclass = subGridproduct_Class+"Odd";
            }
         }
         else if ( subGridproduct_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridproduct_Backstyle = 0;
            subGridproduct_Backcolor = subGridproduct_Allbackcolor;
            if ( StringUtil.StrCmp(subGridproduct_Class, "") != 0 )
            {
               subGridproduct_Linesclass = subGridproduct_Class+"Uniform";
            }
         }
         else if ( subGridproduct_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridproduct_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridproduct_Class, "") != 0 )
            {
               subGridproduct_Linesclass = subGridproduct_Class+"Odd";
            }
            subGridproduct_Backcolor = (int)(0x0);
         }
         else if ( subGridproduct_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridproduct_Backstyle = 1;
            if ( ((int)((nGXsfl_22_idx) % (2))) == 0 )
            {
               subGridproduct_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridproduct_Class, "") != 0 )
               {
                  subGridproduct_Linesclass = subGridproduct_Class+"Even";
               }
            }
            else
            {
               subGridproduct_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridproduct_Class, "") != 0 )
               {
                  subGridproduct_Linesclass = subGridproduct_Class+"Odd";
               }
            }
         }
         if ( GridproductContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_22_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridproductContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridproductRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A10ProductId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)59,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)false,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridproductContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridproductRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,(string)A11ProductName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)290,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridproductContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A14ProductImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40002ProductImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A14ProductImage)) ? A40002ProductImage_GXI : context.PathToRelativeUrl( A14ProductImage));
         GridproductRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProductImage_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A14ProductImage_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridproductContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridproductRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoryName_Internalname,(string)A5CategoryName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoryName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)290,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridproductContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridproductRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A13ProductPrice, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A13ProductPrice, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)136,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
         send_integrity_lvl_hashes1N3( ) ;
         GridproductContainer.AddRow(GridproductRow);
         nGXsfl_22_idx = ((subGridproduct_Islastpage==1)&&(nGXsfl_22_idx+1>subGridproduct_fnc_Recordsperpage( )) ? 1 : nGXsfl_22_idx+1);
         sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0") + sGXsfl_9_idx;
         SubsflControlProps_223( ) ;
         /* End function sendrow_223 */
      }

      protected void SubsflControlProps_92( )
      {
         edtSellerPhoto_Internalname = "SELLERPHOTO_"+sGXsfl_9_idx;
         edtSellerName_Internalname = "SELLERNAME_"+sGXsfl_9_idx;
         edtavTotal_Internalname = "vTOTAL_"+sGXsfl_9_idx;
         subGridproduct_Internalname = "GRIDPRODUCT_"+sGXsfl_9_idx;
      }

      protected void SubsflControlProps_fel_92( )
      {
         edtSellerPhoto_Internalname = "SELLERPHOTO_"+sGXsfl_9_fel_idx;
         edtSellerName_Internalname = "SELLERNAME_"+sGXsfl_9_fel_idx;
         edtavTotal_Internalname = "vTOTAL_"+sGXsfl_9_fel_idx;
         subGridproduct_Internalname = "GRIDPRODUCT_"+sGXsfl_9_fel_idx;
      }

      protected void sendrow_92( )
      {
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         WB1N0( ) ;
         GridsellerRow = GXWebRow.GetNew(context,GridsellerContainer);
         if ( subGridseller_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridseller_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridseller_Class, "") != 0 )
            {
               subGridseller_Linesclass = subGridseller_Class+"Odd";
            }
         }
         else if ( subGridseller_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridseller_Backstyle = 0;
            subGridseller_Backcolor = subGridseller_Allbackcolor;
            if ( StringUtil.StrCmp(subGridseller_Class, "") != 0 )
            {
               subGridseller_Linesclass = subGridseller_Class+"Uniform";
            }
         }
         else if ( subGridseller_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridseller_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridseller_Class, "") != 0 )
            {
               subGridseller_Linesclass = subGridseller_Class+"Odd";
            }
            subGridseller_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridseller_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridseller_Backstyle = 1;
            if ( ((int)((nGXsfl_9_idx) % (2))) == 0 )
            {
               subGridseller_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridseller_Class, "") != 0 )
               {
                  subGridseller_Linesclass = subGridseller_Class+"Even";
               }
            }
            else
            {
               subGridseller_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGridseller_Class, "") != 0 )
               {
                  subGridseller_Linesclass = subGridseller_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( GridsellerContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGridseller_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_9_idx+"\">") ;
         }
         /* Div Control */
         GridsellerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid3table_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsellerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsellerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsellerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtSellerPhoto_Internalname+"\"",(string)"",(string)"div"});
         /* Div Control */
         GridsellerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A8SellerPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A8SellerPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000SellerPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A8SellerPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A8SellerPhoto)) ? A40000SellerPhoto_GXI : context.PathToRelativeUrl( A8SellerPhoto));
         GridsellerRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtSellerPhoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A8SellerPhoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
         GridsellerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridsellerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridsellerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         GridsellerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsellerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtSellerName_Internalname+"\"",(string)"",(string)"div"});
         /* Div Control */
         GridsellerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "Attribute";
         GridsellerRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSellerName_Internalname,(string)A7SellerName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSellerName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         GridsellerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridsellerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridsellerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridsellerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         GridsellerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsellerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /*  Child Grid Control  */
         GridsellerRow.AddColumnProperties("subfile", -1, isAjaxCallMode( ), new Object[] {(string)"GridproductContainer"});
         if ( isAjaxCallMode( ) )
         {
            GridproductContainer = new GXWebGrid( context);
         }
         else
         {
            GridproductContainer.Clear();
         }
         GridproductContainer.SetWrapped(nGXWrapped);
         StartGridControl22( ) ;
         RF1N3( ) ;
         nRC_GXsfl_22 = (int)(nGXsfl_22_idx-1);
         GXCCtl = "nRC_GXsfl_22_" + sGXsfl_9_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_22), 8, 0, ",", "")));
         if ( GridproductContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "</table>") ;
         }
         else
         {
            if ( ! isAjaxCallMode( ) )
            {
               GxWebStd.gx_hidden_field( context, "GridproductContainerData"+"_"+sGXsfl_9_idx, GridproductContainer.ToJavascriptSource());
            }
            if ( isAjaxCallMode( ) )
            {
               GridsellerRow.AddGrid("Gridproduct", GridproductContainer);
            }
            if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
            {
               GxWebStd.gx_hidden_field( context, "GridproductContainerData"+"V_"+sGXsfl_9_idx, GridproductContainer.GridValuesHidden());
            }
            else
            {
               context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridproductContainerData"+"V_"+sGXsfl_9_idx+"\" value='"+GridproductContainer.GridValuesHidden()+"'/>") ;
            }
         }
         GridsellerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridsellerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         GridsellerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsellerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"end",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridsellerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtavTotal_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridsellerRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavTotal_Internalname,(string)"Total",(string)"col-sm-3 AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         GridsellerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "Attribute";
         GridsellerRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavTotal_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Total), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Total), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavTotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         GridsellerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridsellerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridsellerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"end",(string)"top",(string)"div"});
         GridsellerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridsellerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes1N2( ) ;
         /* End of Columns property logic. */
         GridsellerContainer.AddRow(GridsellerRow);
         nGXsfl_9_idx = ((subGridseller_Islastpage==1)&&(nGXsfl_9_idx+1>subGridseller_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         /* End function sendrow_92 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl9( )
      {
         if ( GridsellerContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridsellerContainer"+"DivS\" data-gxgridid=\"9\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridseller_Internalname, subGridseller_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            GridsellerContainer.AddObjectProperty("GridName", "Gridseller");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridsellerContainer = new GXWebGrid( context);
            }
            else
            {
               GridsellerContainer.Clear();
            }
            GridsellerContainer.SetIsFreestyle(true);
            GridsellerContainer.SetWrapped(nGXWrapped);
            GridsellerContainer.AddObjectProperty("GridName", "Gridseller");
            GridsellerContainer.AddObjectProperty("Header", subGridseller_Header);
            GridsellerContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            GridsellerContainer.AddObjectProperty("Class", "FreeStyleGrid");
            GridsellerContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridsellerContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridsellerContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridseller_Backcolorstyle), 1, 0, ".", "")));
            GridsellerContainer.AddObjectProperty("CmpContext", "");
            GridsellerContainer.AddObjectProperty("InMasterPage", "false");
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerColumn.AddObjectProperty("Value", context.convertURL( A8SellerPhoto));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A7SellerName));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Total), 4, 0, ".", ""))));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsellerContainer.AddColumnProperties(GridsellerColumn);
            GridsellerContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridseller_Selectedindex), 4, 0, ".", "")));
            GridsellerContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridseller_Allowselection), 1, 0, ".", "")));
            GridsellerContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridseller_Selectioncolor), 9, 0, ".", "")));
            GridsellerContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridseller_Allowhovering), 1, 0, ".", "")));
            GridsellerContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridseller_Hoveringcolor), 9, 0, ".", "")));
            GridsellerContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridseller_Allowcollapsing), 1, 0, ".", "")));
            GridsellerContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridseller_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl22( )
      {
         if ( GridproductContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridproductContainer"+"DivS\" data-gxgridid=\"22\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridproduct_Internalname, subGridproduct_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridproduct_Backcolorstyle == 0 )
            {
               subGridproduct_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridproduct_Class) > 0 )
               {
                  subGridproduct_Linesclass = subGridproduct_Class+"Title";
               }
            }
            else
            {
               subGridproduct_Titlebackstyle = 1;
               if ( subGridproduct_Backcolorstyle == 1 )
               {
                  subGridproduct_Titlebackcolor = subGridproduct_Allbackcolor;
                  if ( StringUtil.Len( subGridproduct_Class) > 0 )
                  {
                     subGridproduct_Linesclass = subGridproduct_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridproduct_Class) > 0 )
                  {
                     subGridproduct_Linesclass = subGridproduct_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(59), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Product Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(290), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Product") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(41), 4, 0)+"px"+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(290), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Category") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(136), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridproductContainer.AddObjectProperty("GridName", "Gridproduct");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridproductContainer = new GXWebGrid( context);
            }
            else
            {
               GridproductContainer.Clear();
            }
            GridproductContainer.SetWrapped(nGXWrapped);
            GridproductContainer.AddObjectProperty("GridName", "Gridproduct");
            GridproductContainer.AddObjectProperty("Header", subGridproduct_Header);
            GridproductContainer.AddObjectProperty("Class", "Grid");
            GridproductContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridproductContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridproductContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproduct_Backcolorstyle), 1, 0, ".", "")));
            GridproductContainer.AddObjectProperty("CmpContext", "");
            GridproductContainer.AddObjectProperty("InMasterPage", "false");
            GridproductColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridproductColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductId), 4, 0, ".", ""))));
            GridproductContainer.AddColumnProperties(GridproductColumn);
            GridproductColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridproductColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11ProductName));
            GridproductContainer.AddColumnProperties(GridproductColumn);
            GridproductColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridproductColumn.AddObjectProperty("Value", context.convertURL( A14ProductImage));
            GridproductContainer.AddColumnProperties(GridproductColumn);
            GridproductColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridproductColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A5CategoryName));
            GridproductContainer.AddColumnProperties(GridproductColumn);
            GridproductColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridproductColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A13ProductPrice, 18, 2, ".", ""))));
            GridproductContainer.AddColumnProperties(GridproductColumn);
            GridproductContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproduct_Selectedindex), 4, 0, ".", "")));
            GridproductContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproduct_Allowselection), 1, 0, ".", "")));
            GridproductContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproduct_Selectioncolor), 9, 0, ".", "")));
            GridproductContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproduct_Allowhovering), 1, 0, ".", "")));
            GridproductContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproduct_Hoveringcolor), 9, 0, ".", "")));
            GridproductContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproduct_Allowcollapsing), 1, 0, ".", "")));
            GridproductContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproduct_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtSellerPhoto_Internalname = "SELLERPHOTO";
         edtSellerName_Internalname = "SELLERNAME";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductImage_Internalname = "PRODUCTIMAGE";
         edtCategoryName_Internalname = "CATEGORYNAME";
         edtProductPrice_Internalname = "PRODUCTPRICE";
         edtavTotal_Internalname = "vTOTAL";
         divGrid3table_Internalname = "GRID3TABLE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridproduct_Internalname = "GRIDPRODUCT";
         subGridseller_Internalname = "GRIDSELLER";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("ObligatorioShop", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridproduct_Allowcollapsing = 0;
         subGridproduct_Allowselection = 0;
         subGridproduct_Header = "";
         subGridseller_Allowcollapsing = 0;
         edtavTotal_Jsonclick = "";
         edtSellerName_Jsonclick = "";
         subGridseller_Class = "FreeStyleGrid";
         edtProductPrice_Jsonclick = "";
         edtCategoryName_Jsonclick = "";
         edtProductName_Jsonclick = "";
         edtProductId_Jsonclick = "";
         subGridproduct_Class = "Grid";
         subGridproduct_Backcolorstyle = 0;
         edtProductPrice_Enabled = 0;
         edtCategoryName_Enabled = 0;
         edtProductImage_Enabled = 0;
         edtProductName_Enabled = 0;
         edtProductId_Enabled = 0;
         edtSellerName_Enabled = 0;
         edtSellerPhoto_Enabled = 0;
         subGridseller_Backcolorstyle = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Seller Products";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDSELLER_nFirstRecordOnPage"},{"av":"GRIDSELLER_nEOF"},{"av":"GRIDPRODUCT_nFirstRecordOnPage"},{"av":"GRIDPRODUCT_nEOF"},{"av":"A6SellerId","fld":"SELLERID","pic":"ZZZ9"},{"av":"AV5Total","fld":"vTOTAL","pic":"ZZZ9"}]}""");
         setEventMetadata("GRIDPRODUCT.LOAD","""{"handler":"E121N3","iparms":[{"av":"AV5Total","fld":"vTOTAL","pic":"ZZZ9"}]""");
         setEventMetadata("GRIDPRODUCT.LOAD",""","oparms":[{"av":"AV5Total","fld":"vTOTAL","pic":"ZZZ9"}]}""");
         setEventMetadata("GRIDSELLER.LOAD","""{"handler":"E111N2","iparms":[]""");
         setEventMetadata("GRIDSELLER.LOAD",""","oparms":[{"av":"AV5Total","fld":"vTOTAL","pic":"ZZZ9"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Productprice","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Total","iparms":[]}""");
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
         GridsellerContainer = new GXWebGrid( context);
         sStyleString = "";
         GridproductContainer = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A8SellerPhoto = "";
         A40000SellerPhoto_GXI = "";
         A7SellerName = "";
         A11ProductName = "";
         A14ProductImage = "";
         A40002ProductImage_GXI = "";
         A5CategoryName = "";
         H001N2_A6SellerId = new short[1] ;
         H001N2_A7SellerName = new string[] {""} ;
         H001N2_A40000SellerPhoto_GXI = new string[] {""} ;
         H001N2_A8SellerPhoto = new string[] {""} ;
         H001N3_A4CategoryId = new short[1] ;
         H001N3_A6SellerId = new short[1] ;
         H001N3_A13ProductPrice = new decimal[1] ;
         H001N3_A5CategoryName = new string[] {""} ;
         H001N3_A40002ProductImage_GXI = new string[] {""} ;
         H001N3_A11ProductName = new string[] {""} ;
         H001N3_A10ProductId = new short[1] ;
         H001N3_A14ProductImage = new string[] {""} ;
         GridsellerRow = new GXWebRow();
         GridproductRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridproduct_Linesclass = "";
         ROClassString = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         subGridseller_Linesclass = "";
         GXCCtl = "";
         subGridseller_Header = "";
         GridsellerColumn = new GXWebColumn();
         GridproductColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sellerproducts__default(),
            new Object[][] {
                new Object[] {
               H001N2_A6SellerId, H001N2_A7SellerName, H001N2_A40000SellerPhoto_GXI, H001N2_A8SellerPhoto
               }
               , new Object[] {
               H001N3_A4CategoryId, H001N3_A6SellerId, H001N3_A13ProductPrice, H001N3_A5CategoryName, H001N3_A40002ProductImage_GXI, H001N3_A11ProductName, H001N3_A10ProductId, H001N3_A14ProductImage
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short A6SellerId ;
      private short AV5Total ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short A10ProductId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridseller_Backcolorstyle ;
      private short subGridproduct_Backcolorstyle ;
      private short A4CategoryId ;
      private short subGridproduct_Backstyle ;
      private short subGridseller_Backstyle ;
      private short subGridseller_Allowselection ;
      private short subGridseller_Allowhovering ;
      private short subGridseller_Allowcollapsing ;
      private short subGridseller_Collapsed ;
      private short subGridproduct_Titlebackstyle ;
      private short subGridproduct_Allowselection ;
      private short subGridproduct_Allowhovering ;
      private short subGridproduct_Allowcollapsing ;
      private short subGridproduct_Collapsed ;
      private short GRIDSELLER_nEOF ;
      private short GRIDPRODUCT_nEOF ;
      private int nRC_GXsfl_22 ;
      private int nGXsfl_22_idx=1 ;
      private int nRC_GXsfl_9 ;
      private int nGXsfl_9_idx=1 ;
      private int subGridseller_Islastpage ;
      private int subGridproduct_Islastpage ;
      private int edtSellerPhoto_Enabled ;
      private int edtSellerName_Enabled ;
      private int edtProductId_Enabled ;
      private int edtProductName_Enabled ;
      private int edtProductImage_Enabled ;
      private int edtCategoryName_Enabled ;
      private int edtProductPrice_Enabled ;
      private int idxLst ;
      private int subGridproduct_Backcolor ;
      private int subGridproduct_Allbackcolor ;
      private int subGridseller_Backcolor ;
      private int subGridseller_Allbackcolor ;
      private int subGridseller_Selectedindex ;
      private int subGridseller_Selectioncolor ;
      private int subGridseller_Hoveringcolor ;
      private int subGridproduct_Titlebackcolor ;
      private int subGridproduct_Selectedindex ;
      private int subGridproduct_Selectioncolor ;
      private int subGridproduct_Hoveringcolor ;
      private long GRIDPRODUCT_nCurrentRecord ;
      private long GRIDSELLER_nCurrentRecord ;
      private long GRIDSELLER_nFirstRecordOnPage ;
      private long GRIDPRODUCT_nFirstRecordOnPage ;
      private decimal A13ProductPrice ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_22_idx="0001" ;
      private string sGXsfl_9_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string sStyleString ;
      private string subGridseller_Internalname ;
      private string subGridproduct_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtSellerPhoto_Internalname ;
      private string edtSellerName_Internalname ;
      private string edtavTotal_Internalname ;
      private string edtProductId_Internalname ;
      private string edtProductName_Internalname ;
      private string edtProductImage_Internalname ;
      private string edtCategoryName_Internalname ;
      private string edtProductPrice_Internalname ;
      private string sGXsfl_22_fel_idx="0001" ;
      private string subGridproduct_Class ;
      private string subGridproduct_Linesclass ;
      private string ROClassString ;
      private string edtProductId_Jsonclick ;
      private string edtProductName_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string edtCategoryName_Jsonclick ;
      private string edtProductPrice_Jsonclick ;
      private string sGXsfl_9_fel_idx="0001" ;
      private string subGridseller_Class ;
      private string subGridseller_Linesclass ;
      private string divGrid3table_Internalname ;
      private string edtSellerName_Jsonclick ;
      private string GXCCtl ;
      private string edtavTotal_Jsonclick ;
      private string subGridseller_Header ;
      private string subGridproduct_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_9_Refreshing=false ;
      private bool bGXsfl_22_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A14ProductImage_IsBlob ;
      private bool A8SellerPhoto_IsBlob ;
      private string A40000SellerPhoto_GXI ;
      private string A7SellerName ;
      private string A11ProductName ;
      private string A40002ProductImage_GXI ;
      private string A5CategoryName ;
      private string A8SellerPhoto ;
      private string A14ProductImage ;
      private GXWebGrid GridsellerContainer ;
      private GXWebGrid GridproductContainer ;
      private GXWebRow GridsellerRow ;
      private GXWebRow GridproductRow ;
      private GXWebColumn GridsellerColumn ;
      private GXWebColumn GridproductColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H001N2_A6SellerId ;
      private string[] H001N2_A7SellerName ;
      private string[] H001N2_A40000SellerPhoto_GXI ;
      private string[] H001N2_A8SellerPhoto ;
      private short[] H001N3_A4CategoryId ;
      private short[] H001N3_A6SellerId ;
      private decimal[] H001N3_A13ProductPrice ;
      private string[] H001N3_A5CategoryName ;
      private string[] H001N3_A40002ProductImage_GXI ;
      private string[] H001N3_A11ProductName ;
      private short[] H001N3_A10ProductId ;
      private string[] H001N3_A14ProductImage ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class sellerproducts__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH001N2;
          prmH001N2 = new Object[] {
          };
          Object[] prmH001N3;
          prmH001N3 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001N2", "SELECT [SellerId], [SellerName], [SellerPhoto_GXI], [SellerPhoto] FROM [Seller] ORDER BY [SellerId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001N2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001N3", "SELECT T1.[CategoryId], T1.[SellerId], T1.[ProductPrice], T2.[CategoryName], T1.[ProductImage_GXI], T1.[ProductName], T1.[ProductId], T1.[ProductImage] FROM ([Product] T1 INNER JOIN [Category] T2 ON T2.[CategoryId] = T1.[CategoryId]) WHERE T1.[SellerId] = @SellerId ORDER BY T1.[SellerId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001N3,11, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(5));
                return;
       }
    }

 }

}
