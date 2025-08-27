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
   [XmlRoot(ElementName = "Product" )]
   [XmlType(TypeName =  "Product" , Namespace = "ObligatorioShop" )]
   [Serializable]
   public class SdtProduct : GxSilentTrnSdt
   {
      public SdtProduct( )
      {
      }

      public SdtProduct( IGxContext context )
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

      public void Load( short AV10ProductId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV10ProductId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProductId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Product");
         metadata.Set("BT", "Product");
         metadata.Set("PK", "[ \"ProductId\" ]");
         metadata.Set("PKAssigned", "[ \"ProductId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CategoryId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"CountryId\" ],\"FKMap\":[ \"ProductCountryId-CountryId\" ] },{ \"FK\":[ \"SellerId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SupplierId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Productimage_gxi");
         state.Add("gxTpr_Productcountryflag_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Productid_Z");
         state.Add("gxTpr_Productname_Z");
         state.Add("gxTpr_Productdescription_Z");
         state.Add("gxTpr_Productprice_Z");
         state.Add("gxTpr_Sellerid_Z");
         state.Add("gxTpr_Sellername_Z");
         state.Add("gxTpr_Productcountryid_Z");
         state.Add("gxTpr_Productcountryname_Z");
         state.Add("gxTpr_Supplierid_Z");
         state.Add("gxTpr_Suppliername_Z");
         state.Add("gxTpr_Categoryid_Z");
         state.Add("gxTpr_Categoryname_Z");
         state.Add("gxTpr_Productimage_gxi_Z");
         state.Add("gxTpr_Productcountryflag_gxi_Z");
         state.Add("gxTpr_Productcountryflag_gxi_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProduct sdt;
         sdt = (SdtProduct)(source);
         gxTv_SdtProduct_Productid = sdt.gxTv_SdtProduct_Productid ;
         gxTv_SdtProduct_Productname = sdt.gxTv_SdtProduct_Productname ;
         gxTv_SdtProduct_Productdescription = sdt.gxTv_SdtProduct_Productdescription ;
         gxTv_SdtProduct_Productprice = sdt.gxTv_SdtProduct_Productprice ;
         gxTv_SdtProduct_Productimage = sdt.gxTv_SdtProduct_Productimage ;
         gxTv_SdtProduct_Productimage_gxi = sdt.gxTv_SdtProduct_Productimage_gxi ;
         gxTv_SdtProduct_Sellerid = sdt.gxTv_SdtProduct_Sellerid ;
         gxTv_SdtProduct_Sellername = sdt.gxTv_SdtProduct_Sellername ;
         gxTv_SdtProduct_Productcountryid = sdt.gxTv_SdtProduct_Productcountryid ;
         gxTv_SdtProduct_Productcountryname = sdt.gxTv_SdtProduct_Productcountryname ;
         gxTv_SdtProduct_Productcountryflag = sdt.gxTv_SdtProduct_Productcountryflag ;
         gxTv_SdtProduct_Productcountryflag_gxi = sdt.gxTv_SdtProduct_Productcountryflag_gxi ;
         gxTv_SdtProduct_Supplierid = sdt.gxTv_SdtProduct_Supplierid ;
         gxTv_SdtProduct_Suppliername = sdt.gxTv_SdtProduct_Suppliername ;
         gxTv_SdtProduct_Categoryid = sdt.gxTv_SdtProduct_Categoryid ;
         gxTv_SdtProduct_Categoryname = sdt.gxTv_SdtProduct_Categoryname ;
         gxTv_SdtProduct_Mode = sdt.gxTv_SdtProduct_Mode ;
         gxTv_SdtProduct_Initialized = sdt.gxTv_SdtProduct_Initialized ;
         gxTv_SdtProduct_Productid_Z = sdt.gxTv_SdtProduct_Productid_Z ;
         gxTv_SdtProduct_Productname_Z = sdt.gxTv_SdtProduct_Productname_Z ;
         gxTv_SdtProduct_Productdescription_Z = sdt.gxTv_SdtProduct_Productdescription_Z ;
         gxTv_SdtProduct_Productprice_Z = sdt.gxTv_SdtProduct_Productprice_Z ;
         gxTv_SdtProduct_Sellerid_Z = sdt.gxTv_SdtProduct_Sellerid_Z ;
         gxTv_SdtProduct_Sellername_Z = sdt.gxTv_SdtProduct_Sellername_Z ;
         gxTv_SdtProduct_Productcountryid_Z = sdt.gxTv_SdtProduct_Productcountryid_Z ;
         gxTv_SdtProduct_Productcountryname_Z = sdt.gxTv_SdtProduct_Productcountryname_Z ;
         gxTv_SdtProduct_Supplierid_Z = sdt.gxTv_SdtProduct_Supplierid_Z ;
         gxTv_SdtProduct_Suppliername_Z = sdt.gxTv_SdtProduct_Suppliername_Z ;
         gxTv_SdtProduct_Categoryid_Z = sdt.gxTv_SdtProduct_Categoryid_Z ;
         gxTv_SdtProduct_Categoryname_Z = sdt.gxTv_SdtProduct_Categoryname_Z ;
         gxTv_SdtProduct_Productimage_gxi_Z = sdt.gxTv_SdtProduct_Productimage_gxi_Z ;
         gxTv_SdtProduct_Productcountryflag_gxi_Z = sdt.gxTv_SdtProduct_Productcountryflag_gxi_Z ;
         gxTv_SdtProduct_Productcountryflag_gxi_N = sdt.gxTv_SdtProduct_Productcountryflag_gxi_N ;
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
         AddObjectProperty("ProductId", gxTv_SdtProduct_Productid, false, includeNonInitialized);
         AddObjectProperty("ProductName", gxTv_SdtProduct_Productname, false, includeNonInitialized);
         AddObjectProperty("ProductDescription", gxTv_SdtProduct_Productdescription, false, includeNonInitialized);
         AddObjectProperty("ProductPrice", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProduct_Productprice, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ProductImage", gxTv_SdtProduct_Productimage, false, includeNonInitialized);
         AddObjectProperty("SellerId", gxTv_SdtProduct_Sellerid, false, includeNonInitialized);
         AddObjectProperty("SellerName", gxTv_SdtProduct_Sellername, false, includeNonInitialized);
         AddObjectProperty("ProductCountryId", gxTv_SdtProduct_Productcountryid, false, includeNonInitialized);
         AddObjectProperty("ProductCountryName", gxTv_SdtProduct_Productcountryname, false, includeNonInitialized);
         AddObjectProperty("ProductCountryFlag", gxTv_SdtProduct_Productcountryflag, false, includeNonInitialized);
         AddObjectProperty("SupplierId", gxTv_SdtProduct_Supplierid, false, includeNonInitialized);
         AddObjectProperty("SupplierName", gxTv_SdtProduct_Suppliername, false, includeNonInitialized);
         AddObjectProperty("CategoryId", gxTv_SdtProduct_Categoryid, false, includeNonInitialized);
         AddObjectProperty("CategoryName", gxTv_SdtProduct_Categoryname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("ProductImage_GXI", gxTv_SdtProduct_Productimage_gxi, false, includeNonInitialized);
            AddObjectProperty("ProductCountryFlag_GXI", gxTv_SdtProduct_Productcountryflag_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtProduct_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProduct_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProductId_Z", gxTv_SdtProduct_Productid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductName_Z", gxTv_SdtProduct_Productname_Z, false, includeNonInitialized);
            AddObjectProperty("ProductDescription_Z", gxTv_SdtProduct_Productdescription_Z, false, includeNonInitialized);
            AddObjectProperty("ProductPrice_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProduct_Productprice_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SellerId_Z", gxTv_SdtProduct_Sellerid_Z, false, includeNonInitialized);
            AddObjectProperty("SellerName_Z", gxTv_SdtProduct_Sellername_Z, false, includeNonInitialized);
            AddObjectProperty("ProductCountryId_Z", gxTv_SdtProduct_Productcountryid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductCountryName_Z", gxTv_SdtProduct_Productcountryname_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierId_Z", gxTv_SdtProduct_Supplierid_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierName_Z", gxTv_SdtProduct_Suppliername_Z, false, includeNonInitialized);
            AddObjectProperty("CategoryId_Z", gxTv_SdtProduct_Categoryid_Z, false, includeNonInitialized);
            AddObjectProperty("CategoryName_Z", gxTv_SdtProduct_Categoryname_Z, false, includeNonInitialized);
            AddObjectProperty("ProductImage_GXI_Z", gxTv_SdtProduct_Productimage_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("ProductCountryFlag_GXI_Z", gxTv_SdtProduct_Productcountryflag_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("ProductCountryFlag_GXI_N", gxTv_SdtProduct_Productcountryflag_gxi_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProduct sdt )
      {
         if ( sdt.IsDirty("ProductId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productid = sdt.gxTv_SdtProduct_Productid ;
         }
         if ( sdt.IsDirty("ProductName") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productname = sdt.gxTv_SdtProduct_Productname ;
         }
         if ( sdt.IsDirty("ProductDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productdescription = sdt.gxTv_SdtProduct_Productdescription ;
         }
         if ( sdt.IsDirty("ProductPrice") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productprice = sdt.gxTv_SdtProduct_Productprice ;
         }
         if ( sdt.IsDirty("ProductImage") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productimage = sdt.gxTv_SdtProduct_Productimage ;
         }
         if ( sdt.IsDirty("ProductImage") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productimage_gxi = sdt.gxTv_SdtProduct_Productimage_gxi ;
         }
         if ( sdt.IsDirty("SellerId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Sellerid = sdt.gxTv_SdtProduct_Sellerid ;
         }
         if ( sdt.IsDirty("SellerName") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Sellername = sdt.gxTv_SdtProduct_Sellername ;
         }
         if ( sdt.IsDirty("ProductCountryId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productcountryid = sdt.gxTv_SdtProduct_Productcountryid ;
         }
         if ( sdt.IsDirty("ProductCountryName") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productcountryname = sdt.gxTv_SdtProduct_Productcountryname ;
         }
         if ( sdt.IsDirty("ProductCountryFlag") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productcountryflag = sdt.gxTv_SdtProduct_Productcountryflag ;
         }
         if ( sdt.IsDirty("ProductCountryFlag") )
         {
            gxTv_SdtProduct_Productcountryflag_gxi_N = (short)(sdt.gxTv_SdtProduct_Productcountryflag_gxi_N);
            sdtIsNull = 0;
            gxTv_SdtProduct_Productcountryflag_gxi = sdt.gxTv_SdtProduct_Productcountryflag_gxi ;
         }
         if ( sdt.IsDirty("SupplierId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Supplierid = sdt.gxTv_SdtProduct_Supplierid ;
         }
         if ( sdt.IsDirty("SupplierName") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Suppliername = sdt.gxTv_SdtProduct_Suppliername ;
         }
         if ( sdt.IsDirty("CategoryId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Categoryid = sdt.gxTv_SdtProduct_Categoryid ;
         }
         if ( sdt.IsDirty("CategoryName") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Categoryname = sdt.gxTv_SdtProduct_Categoryname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProductId" )]
      [  XmlElement( ElementName = "ProductId"   )]
      public short gxTpr_Productid
      {
         get {
            return gxTv_SdtProduct_Productid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtProduct_Productid != value )
            {
               gxTv_SdtProduct_Mode = "INS";
               this.gxTv_SdtProduct_Productid_Z_SetNull( );
               this.gxTv_SdtProduct_Productname_Z_SetNull( );
               this.gxTv_SdtProduct_Productdescription_Z_SetNull( );
               this.gxTv_SdtProduct_Productprice_Z_SetNull( );
               this.gxTv_SdtProduct_Sellerid_Z_SetNull( );
               this.gxTv_SdtProduct_Sellername_Z_SetNull( );
               this.gxTv_SdtProduct_Productcountryid_Z_SetNull( );
               this.gxTv_SdtProduct_Productcountryname_Z_SetNull( );
               this.gxTv_SdtProduct_Supplierid_Z_SetNull( );
               this.gxTv_SdtProduct_Suppliername_Z_SetNull( );
               this.gxTv_SdtProduct_Categoryid_Z_SetNull( );
               this.gxTv_SdtProduct_Categoryname_Z_SetNull( );
               this.gxTv_SdtProduct_Productimage_gxi_Z_SetNull( );
               this.gxTv_SdtProduct_Productcountryflag_gxi_Z_SetNull( );
            }
            gxTv_SdtProduct_Productid = value;
            SetDirty("Productid");
         }

      }

      [  SoapElement( ElementName = "ProductName" )]
      [  XmlElement( ElementName = "ProductName"   )]
      public string gxTpr_Productname
      {
         get {
            return gxTv_SdtProduct_Productname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productname = value;
            SetDirty("Productname");
         }

      }

      [  SoapElement( ElementName = "ProductDescription" )]
      [  XmlElement( ElementName = "ProductDescription"   )]
      public string gxTpr_Productdescription
      {
         get {
            return gxTv_SdtProduct_Productdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productdescription = value;
            SetDirty("Productdescription");
         }

      }

      [  SoapElement( ElementName = "ProductPrice" )]
      [  XmlElement( ElementName = "ProductPrice"   )]
      public decimal gxTpr_Productprice
      {
         get {
            return gxTv_SdtProduct_Productprice ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productprice = value;
            SetDirty("Productprice");
         }

      }

      [  SoapElement( ElementName = "ProductImage" )]
      [  XmlElement( ElementName = "ProductImage"   )]
      [GxUpload()]
      public string gxTpr_Productimage
      {
         get {
            return gxTv_SdtProduct_Productimage ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productimage = value;
            SetDirty("Productimage");
         }

      }

      [  SoapElement( ElementName = "ProductImage_GXI" )]
      [  XmlElement( ElementName = "ProductImage_GXI"   )]
      public string gxTpr_Productimage_gxi
      {
         get {
            return gxTv_SdtProduct_Productimage_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productimage_gxi = value;
            SetDirty("Productimage_gxi");
         }

      }

      [  SoapElement( ElementName = "SellerId" )]
      [  XmlElement( ElementName = "SellerId"   )]
      public short gxTpr_Sellerid
      {
         get {
            return gxTv_SdtProduct_Sellerid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Sellerid = value;
            SetDirty("Sellerid");
         }

      }

      [  SoapElement( ElementName = "SellerName" )]
      [  XmlElement( ElementName = "SellerName"   )]
      public string gxTpr_Sellername
      {
         get {
            return gxTv_SdtProduct_Sellername ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Sellername = value;
            SetDirty("Sellername");
         }

      }

      [  SoapElement( ElementName = "ProductCountryId" )]
      [  XmlElement( ElementName = "ProductCountryId"   )]
      public short gxTpr_Productcountryid
      {
         get {
            return gxTv_SdtProduct_Productcountryid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productcountryid = value;
            SetDirty("Productcountryid");
         }

      }

      [  SoapElement( ElementName = "ProductCountryName" )]
      [  XmlElement( ElementName = "ProductCountryName"   )]
      public string gxTpr_Productcountryname
      {
         get {
            return gxTv_SdtProduct_Productcountryname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productcountryname = value;
            SetDirty("Productcountryname");
         }

      }

      [  SoapElement( ElementName = "ProductCountryFlag" )]
      [  XmlElement( ElementName = "ProductCountryFlag"   )]
      [GxUpload()]
      public string gxTpr_Productcountryflag
      {
         get {
            return gxTv_SdtProduct_Productcountryflag ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productcountryflag = value;
            SetDirty("Productcountryflag");
         }

      }

      [  SoapElement( ElementName = "ProductCountryFlag_GXI" )]
      [  XmlElement( ElementName = "ProductCountryFlag_GXI"   )]
      public string gxTpr_Productcountryflag_gxi
      {
         get {
            return gxTv_SdtProduct_Productcountryflag_gxi ;
         }

         set {
            gxTv_SdtProduct_Productcountryflag_gxi_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProduct_Productcountryflag_gxi = value;
            SetDirty("Productcountryflag_gxi");
         }

      }

      public void gxTv_SdtProduct_Productcountryflag_gxi_SetNull( )
      {
         gxTv_SdtProduct_Productcountryflag_gxi_N = 1;
         gxTv_SdtProduct_Productcountryflag_gxi = "";
         SetDirty("Productcountryflag_gxi");
         return  ;
      }

      public bool gxTv_SdtProduct_Productcountryflag_gxi_IsNull( )
      {
         return (gxTv_SdtProduct_Productcountryflag_gxi_N==1) ;
      }

      [  SoapElement( ElementName = "SupplierId" )]
      [  XmlElement( ElementName = "SupplierId"   )]
      public short gxTpr_Supplierid
      {
         get {
            return gxTv_SdtProduct_Supplierid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Supplierid = value;
            SetDirty("Supplierid");
         }

      }

      [  SoapElement( ElementName = "SupplierName" )]
      [  XmlElement( ElementName = "SupplierName"   )]
      public string gxTpr_Suppliername
      {
         get {
            return gxTv_SdtProduct_Suppliername ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Suppliername = value;
            SetDirty("Suppliername");
         }

      }

      [  SoapElement( ElementName = "CategoryId" )]
      [  XmlElement( ElementName = "CategoryId"   )]
      public short gxTpr_Categoryid
      {
         get {
            return gxTv_SdtProduct_Categoryid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Categoryid = value;
            SetDirty("Categoryid");
         }

      }

      [  SoapElement( ElementName = "CategoryName" )]
      [  XmlElement( ElementName = "CategoryName"   )]
      public string gxTpr_Categoryname
      {
         get {
            return gxTv_SdtProduct_Categoryname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Categoryname = value;
            SetDirty("Categoryname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProduct_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProduct_Mode_SetNull( )
      {
         gxTv_SdtProduct_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProduct_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProduct_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProduct_Initialized_SetNull( )
      {
         gxTv_SdtProduct_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProduct_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductId_Z" )]
      [  XmlElement( ElementName = "ProductId_Z"   )]
      public short gxTpr_Productid_Z
      {
         get {
            return gxTv_SdtProduct_Productid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productid_Z = value;
            SetDirty("Productid_Z");
         }

      }

      public void gxTv_SdtProduct_Productid_Z_SetNull( )
      {
         gxTv_SdtProduct_Productid_Z = 0;
         SetDirty("Productid_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductName_Z" )]
      [  XmlElement( ElementName = "ProductName_Z"   )]
      public string gxTpr_Productname_Z
      {
         get {
            return gxTv_SdtProduct_Productname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productname_Z = value;
            SetDirty("Productname_Z");
         }

      }

      public void gxTv_SdtProduct_Productname_Z_SetNull( )
      {
         gxTv_SdtProduct_Productname_Z = "";
         SetDirty("Productname_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductDescription_Z" )]
      [  XmlElement( ElementName = "ProductDescription_Z"   )]
      public string gxTpr_Productdescription_Z
      {
         get {
            return gxTv_SdtProduct_Productdescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productdescription_Z = value;
            SetDirty("Productdescription_Z");
         }

      }

      public void gxTv_SdtProduct_Productdescription_Z_SetNull( )
      {
         gxTv_SdtProduct_Productdescription_Z = "";
         SetDirty("Productdescription_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductPrice_Z" )]
      [  XmlElement( ElementName = "ProductPrice_Z"   )]
      public decimal gxTpr_Productprice_Z
      {
         get {
            return gxTv_SdtProduct_Productprice_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productprice_Z = value;
            SetDirty("Productprice_Z");
         }

      }

      public void gxTv_SdtProduct_Productprice_Z_SetNull( )
      {
         gxTv_SdtProduct_Productprice_Z = 0;
         SetDirty("Productprice_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productprice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SellerId_Z" )]
      [  XmlElement( ElementName = "SellerId_Z"   )]
      public short gxTpr_Sellerid_Z
      {
         get {
            return gxTv_SdtProduct_Sellerid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Sellerid_Z = value;
            SetDirty("Sellerid_Z");
         }

      }

      public void gxTv_SdtProduct_Sellerid_Z_SetNull( )
      {
         gxTv_SdtProduct_Sellerid_Z = 0;
         SetDirty("Sellerid_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Sellerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SellerName_Z" )]
      [  XmlElement( ElementName = "SellerName_Z"   )]
      public string gxTpr_Sellername_Z
      {
         get {
            return gxTv_SdtProduct_Sellername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Sellername_Z = value;
            SetDirty("Sellername_Z");
         }

      }

      public void gxTv_SdtProduct_Sellername_Z_SetNull( )
      {
         gxTv_SdtProduct_Sellername_Z = "";
         SetDirty("Sellername_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Sellername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductCountryId_Z" )]
      [  XmlElement( ElementName = "ProductCountryId_Z"   )]
      public short gxTpr_Productcountryid_Z
      {
         get {
            return gxTv_SdtProduct_Productcountryid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productcountryid_Z = value;
            SetDirty("Productcountryid_Z");
         }

      }

      public void gxTv_SdtProduct_Productcountryid_Z_SetNull( )
      {
         gxTv_SdtProduct_Productcountryid_Z = 0;
         SetDirty("Productcountryid_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productcountryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductCountryName_Z" )]
      [  XmlElement( ElementName = "ProductCountryName_Z"   )]
      public string gxTpr_Productcountryname_Z
      {
         get {
            return gxTv_SdtProduct_Productcountryname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productcountryname_Z = value;
            SetDirty("Productcountryname_Z");
         }

      }

      public void gxTv_SdtProduct_Productcountryname_Z_SetNull( )
      {
         gxTv_SdtProduct_Productcountryname_Z = "";
         SetDirty("Productcountryname_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productcountryname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierId_Z" )]
      [  XmlElement( ElementName = "SupplierId_Z"   )]
      public short gxTpr_Supplierid_Z
      {
         get {
            return gxTv_SdtProduct_Supplierid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Supplierid_Z = value;
            SetDirty("Supplierid_Z");
         }

      }

      public void gxTv_SdtProduct_Supplierid_Z_SetNull( )
      {
         gxTv_SdtProduct_Supplierid_Z = 0;
         SetDirty("Supplierid_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Supplierid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierName_Z" )]
      [  XmlElement( ElementName = "SupplierName_Z"   )]
      public string gxTpr_Suppliername_Z
      {
         get {
            return gxTv_SdtProduct_Suppliername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Suppliername_Z = value;
            SetDirty("Suppliername_Z");
         }

      }

      public void gxTv_SdtProduct_Suppliername_Z_SetNull( )
      {
         gxTv_SdtProduct_Suppliername_Z = "";
         SetDirty("Suppliername_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Suppliername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryId_Z" )]
      [  XmlElement( ElementName = "CategoryId_Z"   )]
      public short gxTpr_Categoryid_Z
      {
         get {
            return gxTv_SdtProduct_Categoryid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Categoryid_Z = value;
            SetDirty("Categoryid_Z");
         }

      }

      public void gxTv_SdtProduct_Categoryid_Z_SetNull( )
      {
         gxTv_SdtProduct_Categoryid_Z = 0;
         SetDirty("Categoryid_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Categoryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryName_Z" )]
      [  XmlElement( ElementName = "CategoryName_Z"   )]
      public string gxTpr_Categoryname_Z
      {
         get {
            return gxTv_SdtProduct_Categoryname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Categoryname_Z = value;
            SetDirty("Categoryname_Z");
         }

      }

      public void gxTv_SdtProduct_Categoryname_Z_SetNull( )
      {
         gxTv_SdtProduct_Categoryname_Z = "";
         SetDirty("Categoryname_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Categoryname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductImage_GXI_Z" )]
      [  XmlElement( ElementName = "ProductImage_GXI_Z"   )]
      public string gxTpr_Productimage_gxi_Z
      {
         get {
            return gxTv_SdtProduct_Productimage_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productimage_gxi_Z = value;
            SetDirty("Productimage_gxi_Z");
         }

      }

      public void gxTv_SdtProduct_Productimage_gxi_Z_SetNull( )
      {
         gxTv_SdtProduct_Productimage_gxi_Z = "";
         SetDirty("Productimage_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productimage_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductCountryFlag_GXI_Z" )]
      [  XmlElement( ElementName = "ProductCountryFlag_GXI_Z"   )]
      public string gxTpr_Productcountryflag_gxi_Z
      {
         get {
            return gxTv_SdtProduct_Productcountryflag_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productcountryflag_gxi_Z = value;
            SetDirty("Productcountryflag_gxi_Z");
         }

      }

      public void gxTv_SdtProduct_Productcountryflag_gxi_Z_SetNull( )
      {
         gxTv_SdtProduct_Productcountryflag_gxi_Z = "";
         SetDirty("Productcountryflag_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productcountryflag_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductCountryFlag_GXI_N" )]
      [  XmlElement( ElementName = "ProductCountryFlag_GXI_N"   )]
      public short gxTpr_Productcountryflag_gxi_N
      {
         get {
            return gxTv_SdtProduct_Productcountryflag_gxi_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productcountryflag_gxi_N = value;
            SetDirty("Productcountryflag_gxi_N");
         }

      }

      public void gxTv_SdtProduct_Productcountryflag_gxi_N_SetNull( )
      {
         gxTv_SdtProduct_Productcountryflag_gxi_N = 0;
         SetDirty("Productcountryflag_gxi_N");
         return  ;
      }

      public bool gxTv_SdtProduct_Productcountryflag_gxi_N_IsNull( )
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
         gxTv_SdtProduct_Productname = "";
         gxTv_SdtProduct_Productdescription = "";
         gxTv_SdtProduct_Productimage = "";
         gxTv_SdtProduct_Productimage_gxi = "";
         gxTv_SdtProduct_Sellername = "";
         gxTv_SdtProduct_Productcountryname = "";
         gxTv_SdtProduct_Productcountryflag = "";
         gxTv_SdtProduct_Productcountryflag_gxi = "";
         gxTv_SdtProduct_Suppliername = "";
         gxTv_SdtProduct_Categoryname = "";
         gxTv_SdtProduct_Mode = "";
         gxTv_SdtProduct_Productname_Z = "";
         gxTv_SdtProduct_Productdescription_Z = "";
         gxTv_SdtProduct_Sellername_Z = "";
         gxTv_SdtProduct_Productcountryname_Z = "";
         gxTv_SdtProduct_Suppliername_Z = "";
         gxTv_SdtProduct_Categoryname_Z = "";
         gxTv_SdtProduct_Productimage_gxi_Z = "";
         gxTv_SdtProduct_Productcountryflag_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "product", "GeneXus.Programs.product_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtProduct_Productid ;
      private short sdtIsNull ;
      private short gxTv_SdtProduct_Sellerid ;
      private short gxTv_SdtProduct_Productcountryid ;
      private short gxTv_SdtProduct_Supplierid ;
      private short gxTv_SdtProduct_Categoryid ;
      private short gxTv_SdtProduct_Initialized ;
      private short gxTv_SdtProduct_Productid_Z ;
      private short gxTv_SdtProduct_Sellerid_Z ;
      private short gxTv_SdtProduct_Productcountryid_Z ;
      private short gxTv_SdtProduct_Supplierid_Z ;
      private short gxTv_SdtProduct_Categoryid_Z ;
      private short gxTv_SdtProduct_Productcountryflag_gxi_N ;
      private decimal gxTv_SdtProduct_Productprice ;
      private decimal gxTv_SdtProduct_Productprice_Z ;
      private string gxTv_SdtProduct_Mode ;
      private string gxTv_SdtProduct_Productname ;
      private string gxTv_SdtProduct_Productdescription ;
      private string gxTv_SdtProduct_Productimage_gxi ;
      private string gxTv_SdtProduct_Sellername ;
      private string gxTv_SdtProduct_Productcountryname ;
      private string gxTv_SdtProduct_Productcountryflag_gxi ;
      private string gxTv_SdtProduct_Suppliername ;
      private string gxTv_SdtProduct_Categoryname ;
      private string gxTv_SdtProduct_Productname_Z ;
      private string gxTv_SdtProduct_Productdescription_Z ;
      private string gxTv_SdtProduct_Sellername_Z ;
      private string gxTv_SdtProduct_Productcountryname_Z ;
      private string gxTv_SdtProduct_Suppliername_Z ;
      private string gxTv_SdtProduct_Categoryname_Z ;
      private string gxTv_SdtProduct_Productimage_gxi_Z ;
      private string gxTv_SdtProduct_Productcountryflag_gxi_Z ;
      private string gxTv_SdtProduct_Productimage ;
      private string gxTv_SdtProduct_Productcountryflag ;
   }

   [DataContract(Name = @"Product", Namespace = "ObligatorioShop")]
   [GxJsonSerialization("default")]
   public class SdtProduct_RESTInterface : GxGenericCollectionItem<SdtProduct>
   {
      public SdtProduct_RESTInterface( ) : base()
      {
      }

      public SdtProduct_RESTInterface( SdtProduct psdt ) : base(psdt)
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

      [DataMember( Name = "ProductImage" , Order = 4 )]
      [GxUpload()]
      public string gxTpr_Productimage
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Productimage)) ? PathUtil.RelativeURL( sdt.gxTpr_Productimage) : StringUtil.RTrim( sdt.gxTpr_Productimage_gxi)) ;
         }

         set {
            sdt.gxTpr_Productimage = value;
         }

      }

      [DataMember( Name = "SellerId" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Sellerid
      {
         get {
            return sdt.gxTpr_Sellerid ;
         }

         set {
            sdt.gxTpr_Sellerid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SellerName" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Sellername
      {
         get {
            return sdt.gxTpr_Sellername ;
         }

         set {
            sdt.gxTpr_Sellername = value;
         }

      }

      [DataMember( Name = "ProductCountryId" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Productcountryid
      {
         get {
            return sdt.gxTpr_Productcountryid ;
         }

         set {
            sdt.gxTpr_Productcountryid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProductCountryName" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Productcountryname
      {
         get {
            return sdt.gxTpr_Productcountryname ;
         }

         set {
            sdt.gxTpr_Productcountryname = value;
         }

      }

      [DataMember( Name = "ProductCountryFlag" , Order = 9 )]
      [GxUpload()]
      public string gxTpr_Productcountryflag
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Productcountryflag)) ? PathUtil.RelativeURL( sdt.gxTpr_Productcountryflag) : StringUtil.RTrim( sdt.gxTpr_Productcountryflag_gxi)) ;
         }

         set {
            sdt.gxTpr_Productcountryflag = value;
         }

      }

      [DataMember( Name = "SupplierId" , Order = 10 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Supplierid
      {
         get {
            return sdt.gxTpr_Supplierid ;
         }

         set {
            sdt.gxTpr_Supplierid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SupplierName" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Suppliername
      {
         get {
            return sdt.gxTpr_Suppliername ;
         }

         set {
            sdt.gxTpr_Suppliername = value;
         }

      }

      [DataMember( Name = "CategoryId" , Order = 12 )]
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

      [DataMember( Name = "CategoryName" , Order = 13 )]
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

      public SdtProduct sdt
      {
         get {
            return (SdtProduct)Sdt ;
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
            sdt = new SdtProduct() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 14 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Product", Namespace = "ObligatorioShop")]
   [GxJsonSerialization("default")]
   public class SdtProduct_RESTLInterface : GxGenericCollectionItem<SdtProduct>
   {
      public SdtProduct_RESTLInterface( ) : base()
      {
      }

      public SdtProduct_RESTLInterface( SdtProduct psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProductName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtProduct sdt
      {
         get {
            return (SdtProduct)Sdt ;
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
            sdt = new SdtProduct() ;
         }
      }

   }

}
