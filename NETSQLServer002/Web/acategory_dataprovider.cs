using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class acategory_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new acategory_dataprovider().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         GXBCCollection<SdtCategory> aP0_Gxm2rootcol = new GXBCCollection<SdtCategory>()  ;
         execute(out aP0_Gxm2rootcol);
         return GX.GXRuntime.ExitCode ;
      }

      public acategory_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public acategory_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtCategory> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtCategory>( context, "Category", "ObligatorioShop") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtCategory> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtCategory> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtCategory>( context, "Category", "ObligatorioShop") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1category = new SdtCategory(context);
         Gxm2rootcol.Add(Gxm1category, 0);
         Gxm1category.gxTpr_Categoryname = "Ropa";
         Gxm1category = new SdtCategory(context);
         Gxm2rootcol.Add(Gxm1category, 0);
         Gxm1category.gxTpr_Categoryname = "Joyeria";
         Gxm1category = new SdtCategory(context);
         Gxm2rootcol.Add(Gxm1category, 0);
         Gxm1category.gxTpr_Categoryname = "Entretenimiento";
         Gxm1category = new SdtCategory(context);
         Gxm2rootcol.Add(Gxm1category, 0);
         Gxm1category.gxTpr_Categoryname = "Hogar";
         Gxm1category = new SdtCategory(context);
         Gxm2rootcol.Add(Gxm1category, 0);
         Gxm1category.gxTpr_Categoryname = "Salud";
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
         Gxm1category = new SdtCategory(context);
         /* GeneXus formulas. */
      }

      private GXBCCollection<SdtCategory> Gxm2rootcol ;
      private SdtCategory Gxm1category ;
      private GXBCCollection<SdtCategory> aP0_Gxm2rootcol ;
   }

}
