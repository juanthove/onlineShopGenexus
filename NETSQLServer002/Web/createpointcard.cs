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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class createpointcard : GXProcedure
   {
      public createpointcard( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public createpointcard( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_CustomerId )
      {
         this.AV8CustomerId = aP0_CustomerId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( short aP0_CustomerId )
      {
         this.AV8CustomerId = aP0_CustomerId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9PointCard.gxTpr_Customerid = AV8CustomerId;
         AV9PointCard.gxTpr_Pointcardpoints = 0;
         AV9PointCard.gxTpr_Pointcardvip = false;
         if ( AV9PointCard.Insert() )
         {
            GX_msglist.addItem("Tarjeta creada correctamente");
         }
         else
         {
            GX_msglist.addItem("Error: ");
            AV13GXV2 = 1;
            AV12GXV1 = AV9PointCard.GetMessages();
            while ( AV13GXV2 <= AV12GXV1.Count )
            {
               AV10message = ((GeneXus.Utils.SdtMessages_Message)AV12GXV1.Item(AV13GXV2));
               GX_msglist.addItem(AV10message.gxTpr_Description);
               AV13GXV2 = (int)(AV13GXV2+1);
            }
         }
         context.CommitDataStores("createpointcard",pr_default);
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
         AV9PointCard = new SdtPointCard(context);
         AV12GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV10message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.createpointcard__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8CustomerId ;
      private int AV13GXV2 ;
      private IGxDataStore dsDefault ;
      private SdtPointCard AV9PointCard ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV12GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV10message ;
      private IDataStoreProvider pr_default ;
   }

   public class createpointcard__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
