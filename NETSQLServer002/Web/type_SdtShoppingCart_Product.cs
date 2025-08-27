using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "ShoppingCart.Product" )]
   [XmlType(TypeName =  "ShoppingCart.Product" , Namespace = "ObligatorioShop" )]
   [Serializable]
   public class SdtShoppingCart_Product : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtShoppingCart_Product( )
      {
      }

      public SdtShoppingCart_Product( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProductId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Product");
         metadata.Set("BT", "ShoppingCartProducts");
         metadata.Set("PK", "[ \"ProductId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ProductId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ShoppingCartId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Productid_Z");
         state.Add("gxTpr_Productname_Z");
         state.Add("gxTpr_Productdescription_Z");
         state.Add("gxTpr_Productprice_Z");
         state.Add("gxTpr_Categoryid_Z");
         state.Add("gxTpr_Categoryname_Z");
         state.Add("gxTpr_Productfinalprice_Z");
         state.Add("gxTpr_Productquantity_Z");
         state.Add("gxTpr_Producttotalcost_Z");
         state.Add("gxTpr_Productfinalprice_N");
         state.Add("gxTpr_Producttotalcost_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtShoppingCart_Product sdt;
         sdt = (SdtShoppingCart_Product)(source);
         gxTv_SdtShoppingCart_Product_Productid = sdt.gxTv_SdtShoppingCart_Product_Productid ;
         gxTv_SdtShoppingCart_Product_Productname = sdt.gxTv_SdtShoppingCart_Product_Productname ;
         gxTv_SdtShoppingCart_Product_Productdescription = sdt.gxTv_SdtShoppingCart_Product_Productdescription ;
         gxTv_SdtShoppingCart_Product_Productprice = sdt.gxTv_SdtShoppingCart_Product_Productprice ;
         gxTv_SdtShoppingCart_Product_Categoryid = sdt.gxTv_SdtShoppingCart_Product_Categoryid ;
         gxTv_SdtShoppingCart_Product_Categoryname = sdt.gxTv_SdtShoppingCart_Product_Categoryname ;
         gxTv_SdtShoppingCart_Product_Productfinalprice = sdt.gxTv_SdtShoppingCart_Product_Productfinalprice ;
         gxTv_SdtShoppingCart_Product_Productquantity = sdt.gxTv_SdtShoppingCart_Product_Productquantity ;
         gxTv_SdtShoppingCart_Product_Producttotalcost = sdt.gxTv_SdtShoppingCart_Product_Producttotalcost ;
         gxTv_SdtShoppingCart_Product_Mode = sdt.gxTv_SdtShoppingCart_Product_Mode ;
         gxTv_SdtShoppingCart_Product_Modified = sdt.gxTv_SdtShoppingCart_Product_Modified ;
         gxTv_SdtShoppingCart_Product_Initialized = sdt.gxTv_SdtShoppingCart_Product_Initialized ;
         gxTv_SdtShoppingCart_Product_Productid_Z = sdt.gxTv_SdtShoppingCart_Product_Productid_Z ;
         gxTv_SdtShoppingCart_Product_Productname_Z = sdt.gxTv_SdtShoppingCart_Product_Productname_Z ;
         gxTv_SdtShoppingCart_Product_Productdescription_Z = sdt.gxTv_SdtShoppingCart_Product_Productdescription_Z ;
         gxTv_SdtShoppingCart_Product_Productprice_Z = sdt.gxTv_SdtShoppingCart_Product_Productprice_Z ;
         gxTv_SdtShoppingCart_Product_Categoryid_Z = sdt.gxTv_SdtShoppingCart_Product_Categoryid_Z ;
         gxTv_SdtShoppingCart_Product_Categoryname_Z = sdt.gxTv_SdtShoppingCart_Product_Categoryname_Z ;
         gxTv_SdtShoppingCart_Product_Productfinalprice_Z = sdt.gxTv_SdtShoppingCart_Product_Productfinalprice_Z ;
         gxTv_SdtShoppingCart_Product_Productquantity_Z = sdt.gxTv_SdtShoppingCart_Product_Productquantity_Z ;
         gxTv_SdtShoppingCart_Product_Producttotalcost_Z = sdt.gxTv_SdtShoppingCart_Product_Producttotalcost_Z ;
         gxTv_SdtShoppingCart_Product_Productfinalprice_N = sdt.gxTv_SdtShoppingCart_Product_Productfinalprice_N ;
         gxTv_SdtShoppingCart_Product_Producttotalcost_N = sdt.gxTv_SdtShoppingCart_Product_Producttotalcost_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("ProductId", gxTv_SdtShoppingCart_Product_Productid, false, includeNonInitialized);
         AddObjectProperty("ProductName", gxTv_SdtShoppingCart_Product_Productname, false, includeNonInitialized);
         AddObjectProperty("ProductDescription", gxTv_SdtShoppingCart_Product_Productdescription, false, includeNonInitialized);
         AddObjectProperty("ProductPrice", StringUtil.LTrim( StringUtil.Str( gxTv_SdtShoppingCart_Product_Productprice, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("CategoryId", gxTv_SdtShoppingCart_Product_Categoryid, false, includeNonInitialized);
         AddObjectProperty("CategoryName", gxTv_SdtShoppingCart_Product_Categoryname, false, includeNonInitialized);
         AddObjectProperty("ProductFinalPrice", StringUtil.LTrim( StringUtil.Str( gxTv_SdtShoppingCart_Product_Productfinalprice, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ProductFinalPrice_N", gxTv_SdtShoppingCart_Product_Productfinalprice_N, false, includeNonInitialized);
         AddObjectProperty("ProductQuantity", gxTv_SdtShoppingCart_Product_Productquantity, false, includeNonInitialized);
         AddObjectProperty("ProductTotalCost", StringUtil.LTrim( StringUtil.Str( gxTv_SdtShoppingCart_Product_Producttotalcost, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ProductTotalCost_N", gxTv_SdtShoppingCart_Product_Producttotalcost_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtShoppingCart_Product_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtShoppingCart_Product_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtShoppingCart_Product_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProductId_Z", gxTv_SdtShoppingCart_Product_Productid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductName_Z", gxTv_SdtShoppingCart_Product_Productname_Z, false, includeNonInitialized);
            AddObjectProperty("ProductDescription_Z", gxTv_SdtShoppingCart_Product_Productdescription_Z, false, includeNonInitialized);
            AddObjectProperty("ProductPrice_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtShoppingCart_Product_Productprice_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("CategoryId_Z", gxTv_SdtShoppingCart_Product_Categoryid_Z, false, includeNonInitialized);
            AddObjectProperty("CategoryName_Z", gxTv_SdtShoppingCart_Product_Categoryname_Z, false, includeNonInitialized);
            AddObjectProperty("ProductFinalPrice_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtShoppingCart_Product_Productfinalprice_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ProductQuantity_Z", gxTv_SdtShoppingCart_Product_Productquantity_Z, false, includeNonInitialized);
            AddObjectProperty("ProductTotalCost_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtShoppingCart_Product_Producttotalcost_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ProductFinalPrice_N", gxTv_SdtShoppingCart_Product_Productfinalprice_N, false, includeNonInitialized);
            AddObjectProperty("ProductTotalCost_N", gxTv_SdtShoppingCart_Product_Producttotalcost_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtShoppingCart_Product sdt )
      {
         if ( sdt.IsDirty("ProductId") )
         {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productid = sdt.gxTv_SdtShoppingCart_Product_Productid ;
         }
         if ( sdt.IsDirty("ProductName") )
         {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productname = sdt.gxTv_SdtShoppingCart_Product_Productname ;
         }
         if ( sdt.IsDirty("ProductDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productdescription = sdt.gxTv_SdtShoppingCart_Product_Productdescription ;
         }
         if ( sdt.IsDirty("ProductPrice") )
         {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productprice = sdt.gxTv_SdtShoppingCart_Product_Productprice ;
         }
         if ( sdt.IsDirty("CategoryId") )
         {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Categoryid = sdt.gxTv_SdtShoppingCart_Product_Categoryid ;
         }
         if ( sdt.IsDirty("CategoryName") )
         {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Categoryname = sdt.gxTv_SdtShoppingCart_Product_Categoryname ;
         }
         if ( sdt.IsDirty("ProductFinalPrice") )
         {
            gxTv_SdtShoppingCart_Product_Productfinalprice_N = (short)(sdt.gxTv_SdtShoppingCart_Product_Productfinalprice_N);
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productfinalprice = sdt.gxTv_SdtShoppingCart_Product_Productfinalprice ;
         }
         if ( sdt.IsDirty("ProductQuantity") )
         {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productquantity = sdt.gxTv_SdtShoppingCart_Product_Productquantity ;
         }
         if ( sdt.IsDirty("ProductTotalCost") )
         {
            gxTv_SdtShoppingCart_Product_Producttotalcost_N = (short)(sdt.gxTv_SdtShoppingCart_Product_Producttotalcost_N);
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Producttotalcost = sdt.gxTv_SdtShoppingCart_Product_Producttotalcost ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProductId" )]
      [  XmlElement( ElementName = "ProductId"   )]
      public short gxTpr_Productid
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productid = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productid");
         }

      }

      [  SoapElement( ElementName = "ProductName" )]
      [  XmlElement( ElementName = "ProductName"   )]
      public string gxTpr_Productname
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productname = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productname");
         }

      }

      [  SoapElement( ElementName = "ProductDescription" )]
      [  XmlElement( ElementName = "ProductDescription"   )]
      public string gxTpr_Productdescription
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productdescription = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productdescription");
         }

      }

      [  SoapElement( ElementName = "ProductPrice" )]
      [  XmlElement( ElementName = "ProductPrice"   )]
      public decimal gxTpr_Productprice
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productprice ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productprice = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productprice");
         }

      }

      [  SoapElement( ElementName = "CategoryId" )]
      [  XmlElement( ElementName = "CategoryId"   )]
      public short gxTpr_Categoryid
      {
         get {
            return gxTv_SdtShoppingCart_Product_Categoryid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Categoryid = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Categoryid");
         }

      }

      [  SoapElement( ElementName = "CategoryName" )]
      [  XmlElement( ElementName = "CategoryName"   )]
      public string gxTpr_Categoryname
      {
         get {
            return gxTv_SdtShoppingCart_Product_Categoryname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Categoryname = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Categoryname");
         }

      }

      [  SoapElement( ElementName = "ProductFinalPrice" )]
      [  XmlElement( ElementName = "ProductFinalPrice"   )]
      public decimal gxTpr_Productfinalprice
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productfinalprice ;
         }

         set {
            gxTv_SdtShoppingCart_Product_Productfinalprice_N = 0;
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productfinalprice = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productfinalprice");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Productfinalprice_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Productfinalprice_N = 1;
         gxTv_SdtShoppingCart_Product_Productfinalprice = 0;
         SetDirty("Productfinalprice");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Productfinalprice_IsNull( )
      {
         return (gxTv_SdtShoppingCart_Product_Productfinalprice_N==1) ;
      }

      [  SoapElement( ElementName = "ProductQuantity" )]
      [  XmlElement( ElementName = "ProductQuantity"   )]
      public long gxTpr_Productquantity
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productquantity ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productquantity = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productquantity");
         }

      }

      [  SoapElement( ElementName = "ProductTotalCost" )]
      [  XmlElement( ElementName = "ProductTotalCost"   )]
      public decimal gxTpr_Producttotalcost
      {
         get {
            return gxTv_SdtShoppingCart_Product_Producttotalcost ;
         }

         set {
            gxTv_SdtShoppingCart_Product_Producttotalcost_N = 0;
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Producttotalcost = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Producttotalcost");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Producttotalcost_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Producttotalcost_N = 1;
         gxTv_SdtShoppingCart_Product_Producttotalcost = 0;
         SetDirty("Producttotalcost");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Producttotalcost_IsNull( )
      {
         return (gxTv_SdtShoppingCart_Product_Producttotalcost_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtShoppingCart_Product_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Mode_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtShoppingCart_Product_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Modified_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtShoppingCart_Product_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Initialized = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Initialized_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductId_Z" )]
      [  XmlElement( ElementName = "ProductId_Z"   )]
      public short gxTpr_Productid_Z
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productid_Z = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productid_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Productid_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Productid_Z = 0;
         SetDirty("Productid_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Productid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductName_Z" )]
      [  XmlElement( ElementName = "ProductName_Z"   )]
      public string gxTpr_Productname_Z
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productname_Z = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productname_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Productname_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Productname_Z = "";
         SetDirty("Productname_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Productname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductDescription_Z" )]
      [  XmlElement( ElementName = "ProductDescription_Z"   )]
      public string gxTpr_Productdescription_Z
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productdescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productdescription_Z = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productdescription_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Productdescription_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Productdescription_Z = "";
         SetDirty("Productdescription_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Productdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductPrice_Z" )]
      [  XmlElement( ElementName = "ProductPrice_Z"   )]
      public decimal gxTpr_Productprice_Z
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productprice_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productprice_Z = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productprice_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Productprice_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Productprice_Z = 0;
         SetDirty("Productprice_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Productprice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryId_Z" )]
      [  XmlElement( ElementName = "CategoryId_Z"   )]
      public short gxTpr_Categoryid_Z
      {
         get {
            return gxTv_SdtShoppingCart_Product_Categoryid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Categoryid_Z = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Categoryid_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Categoryid_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Categoryid_Z = 0;
         SetDirty("Categoryid_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Categoryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryName_Z" )]
      [  XmlElement( ElementName = "CategoryName_Z"   )]
      public string gxTpr_Categoryname_Z
      {
         get {
            return gxTv_SdtShoppingCart_Product_Categoryname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Categoryname_Z = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Categoryname_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Categoryname_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Categoryname_Z = "";
         SetDirty("Categoryname_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Categoryname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductFinalPrice_Z" )]
      [  XmlElement( ElementName = "ProductFinalPrice_Z"   )]
      public decimal gxTpr_Productfinalprice_Z
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productfinalprice_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productfinalprice_Z = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productfinalprice_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Productfinalprice_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Productfinalprice_Z = 0;
         SetDirty("Productfinalprice_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Productfinalprice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductQuantity_Z" )]
      [  XmlElement( ElementName = "ProductQuantity_Z"   )]
      public long gxTpr_Productquantity_Z
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productquantity_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productquantity_Z = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productquantity_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Productquantity_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Productquantity_Z = 0;
         SetDirty("Productquantity_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Productquantity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductTotalCost_Z" )]
      [  XmlElement( ElementName = "ProductTotalCost_Z"   )]
      public decimal gxTpr_Producttotalcost_Z
      {
         get {
            return gxTv_SdtShoppingCart_Product_Producttotalcost_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Producttotalcost_Z = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Producttotalcost_Z");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Producttotalcost_Z_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Producttotalcost_Z = 0;
         SetDirty("Producttotalcost_Z");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Producttotalcost_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductFinalPrice_N" )]
      [  XmlElement( ElementName = "ProductFinalPrice_N"   )]
      public short gxTpr_Productfinalprice_N
      {
         get {
            return gxTv_SdtShoppingCart_Product_Productfinalprice_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Productfinalprice_N = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Productfinalprice_N");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Productfinalprice_N_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Productfinalprice_N = 0;
         SetDirty("Productfinalprice_N");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Productfinalprice_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductTotalCost_N" )]
      [  XmlElement( ElementName = "ProductTotalCost_N"   )]
      public short gxTpr_Producttotalcost_N
      {
         get {
            return gxTv_SdtShoppingCart_Product_Producttotalcost_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtShoppingCart_Product_Producttotalcost_N = value;
            gxTv_SdtShoppingCart_Product_Modified = 1;
            SetDirty("Producttotalcost_N");
         }

      }

      public void gxTv_SdtShoppingCart_Product_Producttotalcost_N_SetNull( )
      {
         gxTv_SdtShoppingCart_Product_Producttotalcost_N = 0;
         SetDirty("Producttotalcost_N");
         return  ;
      }

      public bool gxTv_SdtShoppingCart_Product_Producttotalcost_N_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtShoppingCart_Product_Productname = "";
         gxTv_SdtShoppingCart_Product_Productdescription = "";
         gxTv_SdtShoppingCart_Product_Categoryname = "";
         gxTv_SdtShoppingCart_Product_Mode = "";
         gxTv_SdtShoppingCart_Product_Productname_Z = "";
         gxTv_SdtShoppingCart_Product_Productdescription_Z = "";
         gxTv_SdtShoppingCart_Product_Categoryname_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtShoppingCart_Product_Productid ;
      private short sdtIsNull ;
      private short gxTv_SdtShoppingCart_Product_Categoryid ;
      private short gxTv_SdtShoppingCart_Product_Modified ;
      private short gxTv_SdtShoppingCart_Product_Initialized ;
      private short gxTv_SdtShoppingCart_Product_Productid_Z ;
      private short gxTv_SdtShoppingCart_Product_Categoryid_Z ;
      private short gxTv_SdtShoppingCart_Product_Productfinalprice_N ;
      private short gxTv_SdtShoppingCart_Product_Producttotalcost_N ;
      private long gxTv_SdtShoppingCart_Product_Productquantity ;
      private long gxTv_SdtShoppingCart_Product_Productquantity_Z ;
      private decimal gxTv_SdtShoppingCart_Product_Productprice ;
      private decimal gxTv_SdtShoppingCart_Product_Productfinalprice ;
      private decimal gxTv_SdtShoppingCart_Product_Producttotalcost ;
      private decimal gxTv_SdtShoppingCart_Product_Productprice_Z ;
      private decimal gxTv_SdtShoppingCart_Product_Productfinalprice_Z ;
      private decimal gxTv_SdtShoppingCart_Product_Producttotalcost_Z ;
      private string gxTv_SdtShoppingCart_Product_Mode ;
      private string gxTv_SdtShoppingCart_Product_Productname ;
      private string gxTv_SdtShoppingCart_Product_Productdescription ;
      private string gxTv_SdtShoppingCart_Product_Categoryname ;
      private string gxTv_SdtShoppingCart_Product_Productname_Z ;
      private string gxTv_SdtShoppingCart_Product_Productdescription_Z ;
      private string gxTv_SdtShoppingCart_Product_Categoryname_Z ;
   }

   [DataContract(Name = @"ShoppingCart.Product", Namespace = "ObligatorioShop")]
   [GxJsonSerialization("default")]
   public class SdtShoppingCart_Product_RESTInterface : GxGenericCollectionItem<SdtShoppingCart_Product>
   {
      public SdtShoppingCart_Product_RESTInterface( ) : base()
      {
      }

      public SdtShoppingCart_Product_RESTInterface( SdtShoppingCart_Product psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProductId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Productid
      {
         get {
            return sdt.gxTpr_Productid ;
         }

         set {
            sdt.gxTpr_Productid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProductName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Productname
      {
         get {
            return sdt.gxTpr_Productname ;
         }

         set {
            sdt.gxTpr_Productname = value;
         }

      }

      [DataMember( Name = "ProductDescription" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Productdescription
      {
         get {
            return sdt.gxTpr_Productdescription ;
         }

         set {
            sdt.gxTpr_Productdescription = value;
         }

      }

      [DataMember( Name = "ProductPrice" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Productprice
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Productprice, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Productprice = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "CategoryId" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Categoryid
      {
         get {
            return sdt.gxTpr_Categoryid ;
         }

         set {
            sdt.gxTpr_Categoryid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CategoryName" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Categoryname
      {
         get {
            return sdt.gxTpr_Categoryname ;
         }

         set {
            sdt.gxTpr_Categoryname = value;
         }

      }

      [DataMember( Name = "ProductFinalPrice" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Productfinalprice
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Productfinalprice, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Productfinalprice = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ProductQuantity" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Productquantity
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Productquantity), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Productquantity = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ProductTotalCost" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Producttotalcost
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Producttotalcost, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Producttotalcost = NumberUtil.Val( value, ".");
         }

      }

      public SdtShoppingCart_Product sdt
      {
         get {
            return (SdtShoppingCart_Product)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtShoppingCart_Product() ;
         }
      }

   }

   [DataContract(Name = @"ShoppingCart.Product", Namespace = "ObligatorioShop")]
   [GxJsonSerialization("default")]
   public class SdtShoppingCart_Product_RESTLInterface : GxGenericCollectionItem<SdtShoppingCart_Product>
   {
      public SdtShoppingCart_Product_RESTLInterface( ) : base()
      {
      }

      public SdtShoppingCart_Product_RESTLInterface( SdtShoppingCart_Product psdt ) : base(psdt)
      {
      }

      public SdtShoppingCart_Product sdt
      {
         get {
            return (SdtShoppingCart_Product)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtShoppingCart_Product() ;
         }
      }

   }

}
