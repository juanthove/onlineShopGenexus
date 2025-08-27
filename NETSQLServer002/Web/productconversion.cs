using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class productconversion : GXProcedure
   {
      public productconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", false);
      }

      public productconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cmdBuffer=" SET IDENTITY_INSERT [GXA0004] ON "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor PRODUCTCON2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1CountryId = PRODUCTCON2_A1CountryId[0];
            A4CategoryId = PRODUCTCON2_A4CategoryId[0];
            A24SupplierId = PRODUCTCON2_A24SupplierId[0];
            A6SellerId = PRODUCTCON2_A6SellerId[0];
            A13ProductPrice = PRODUCTCON2_A13ProductPrice[0];
            A12ProductDescription = PRODUCTCON2_A12ProductDescription[0];
            A11ProductName = PRODUCTCON2_A11ProductName[0];
            A10ProductId = PRODUCTCON2_A10ProductId[0];
            A40000ProductImage_GXI = PRODUCTCON2_A40000ProductImage_GXI[0];
            A14ProductImage = PRODUCTCON2_A14ProductImage[0];
            A1CountryId = PRODUCTCON2_A1CountryId[0];
            /*
               INSERT RECORD ON TABLE GXA0004

            */
            AV2ProductId = A10ProductId;
            AV3ProductName = A11ProductName;
            AV4ProductDescription = A12ProductDescription;
            AV5ProductPrice = A13ProductPrice;
            AV6ProductImage = A14ProductImage;
            AV7ProductImage_GXI = A40000ProductImage_GXI;
            AV7ProductImage_GXI = A40000ProductImage_GXI;
            AV8SellerId = A6SellerId;
            AV9SupplierId = A24SupplierId;
            AV10CategoryId = A4CategoryId;
            if ( PRODUCTCON2_n1CountryId[0] )
            {
               AV11ProductCountryId = 0;
            }
            else
            {
               AV11ProductCountryId = A1CountryId;
            }
            /* Using cursor PRODUCTCON3 */
            pr_default.execute(1, new Object[] {AV2ProductId, AV3ProductName, AV4ProductDescription, AV5ProductPrice, AV6ProductImage, AV7ProductImage_GXI, AV8SellerId, AV9SupplierId, AV10CategoryId, AV11ProductCountryId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0004");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cmdBuffer=" SET IDENTITY_INSERT [GXA0004] OFF "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         cmdBuffer = "";
         PRODUCTCON2_A1CountryId = new short[1] ;
         PRODUCTCON2_A4CategoryId = new short[1] ;
         PRODUCTCON2_A24SupplierId = new short[1] ;
         PRODUCTCON2_A6SellerId = new short[1] ;
         PRODUCTCON2_A13ProductPrice = new decimal[1] ;
         PRODUCTCON2_A12ProductDescription = new string[] {""} ;
         PRODUCTCON2_A11ProductName = new string[] {""} ;
         PRODUCTCON2_A10ProductId = new short[1] ;
         PRODUCTCON2_A40000ProductImage_GXI = new string[] {""} ;
         PRODUCTCON2_A14ProductImage = new string[] {""} ;
         A12ProductDescription = "";
         A11ProductName = "";
         A40000ProductImage_GXI = "";
         A14ProductImage = "";
         AV3ProductName = "";
         AV4ProductDescription = "";
         AV6ProductImage = "";
         AV7ProductImage_GXI = "";
         PRODUCTCON2_n1CountryId = new bool[] {false} ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productconversion__default(),
            new Object[][] {
                new Object[] {
               PRODUCTCON2_A1CountryId, PRODUCTCON2_A4CategoryId, PRODUCTCON2_A24SupplierId, PRODUCTCON2_A6SellerId, PRODUCTCON2_A13ProductPrice, PRODUCTCON2_A12ProductDescription, PRODUCTCON2_A11ProductName, PRODUCTCON2_A10ProductId, PRODUCTCON2_A40000ProductImage_GXI, PRODUCTCON2_A14ProductImage
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A1CountryId ;
      private short A4CategoryId ;
      private short A24SupplierId ;
      private short A6SellerId ;
      private short A10ProductId ;
      private short AV2ProductId ;
      private short AV8SellerId ;
      private short AV9SupplierId ;
      private short AV10CategoryId ;
      private short AV11ProductCountryId ;
      private int GIGXA0004 ;
      private decimal A13ProductPrice ;
      private decimal AV5ProductPrice ;
      private string cmdBuffer ;
      private string Gx_emsg ;
      private string A12ProductDescription ;
      private string A11ProductName ;
      private string A40000ProductImage_GXI ;
      private string AV3ProductName ;
      private string AV4ProductDescription ;
      private string AV7ProductImage_GXI ;
      private string A14ProductImage ;
      private string AV6ProductImage ;
      private IGxDataStore dsDefault ;
      private GxCommand RGZ ;
      private IDataStoreProvider pr_default ;
      private short[] PRODUCTCON2_A1CountryId ;
      private short[] PRODUCTCON2_A4CategoryId ;
      private short[] PRODUCTCON2_A24SupplierId ;
      private short[] PRODUCTCON2_A6SellerId ;
      private decimal[] PRODUCTCON2_A13ProductPrice ;
      private string[] PRODUCTCON2_A12ProductDescription ;
      private string[] PRODUCTCON2_A11ProductName ;
      private short[] PRODUCTCON2_A10ProductId ;
      private string[] PRODUCTCON2_A40000ProductImage_GXI ;
      private string[] PRODUCTCON2_A14ProductImage ;
      private bool[] PRODUCTCON2_n1CountryId ;
   }

   public class productconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmPRODUCTCON2;
          prmPRODUCTCON2 = new Object[] {
          };
          Object[] prmPRODUCTCON3;
          prmPRODUCTCON3 = new Object[] {
          new ParDef("@AV2ProductId",GXType.Int16,4,0) ,
          new ParDef("@AV3ProductName",GXType.VarChar,40,0) ,
          new ParDef("@AV4ProductDescription",GXType.VarChar,200,0) ,
          new ParDef("@AV5ProductPrice",GXType.Decimal,18,2) ,
          new ParDef("@AV6ProductImage",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@AV7ProductImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="GXA0004", Fld="ProductImage"} ,
          new ParDef("@AV8SellerId",GXType.Int16,4,0) ,
          new ParDef("@AV9SupplierId",GXType.Int16,4,0) ,
          new ParDef("@AV10CategoryId",GXType.Int16,4,0) ,
          new ParDef("@AV11ProductCountryId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("PRODUCTCON2", "SELECT T2.[CountryId], T1.[CategoryId], T1.[SupplierId], T1.[SellerId], T1.[ProductPrice], T1.[ProductDescription], T1.[ProductName], T1.[ProductId], T1.[ProductImage_GXI], T1.[ProductImage] FROM ([Product] T1 INNER JOIN [Seller] T2 ON T2.[SellerId] = T1.[SellerId]) ORDER BY T1.[ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmPRODUCTCON2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("PRODUCTCON3", "INSERT INTO [GXA0004]([ProductId], [ProductName], [ProductDescription], [ProductPrice], [ProductImage], [ProductImage_GXI], [SellerId], [SupplierId], [CategoryId], [ProductCountryId]) VALUES(@AV2ProductId, @AV3ProductName, @AV4ProductDescription, @AV5ProductPrice, @AV6ProductImage, @AV7ProductImage_GXI, @AV8SellerId, @AV9SupplierId, @AV10CategoryId, @AV11ProductCountryId)", GxErrorMask.GX_NOMASK,prmPRODUCTCON3)
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(9));
                return;
       }
    }

 }

}
