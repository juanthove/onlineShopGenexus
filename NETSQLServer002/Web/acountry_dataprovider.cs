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
   public class acountry_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new acountry_dataprovider().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         GXBCCollection<SdtCountry> aP0_Gxm2rootcol = new GXBCCollection<SdtCountry>()  ;
         execute(out aP0_Gxm2rootcol);
         return GX.GXRuntime.ExitCode ;
      }

      public acountry_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public acountry_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtCountry> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtCountry>( context, "Country", "ObligatorioShop") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtCountry> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtCountry> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtCountry>( context, "Country", "ObligatorioShop") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryname = "Uruguay";
         Gxm1country.gxTpr_Countryflag = "Resources/Uruguay_Flag.png";
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryname = "Brasil";
         Gxm1country.gxTpr_Countryflag = "Resources/Brazil_Flag.png";
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryname = "Argentina";
         Gxm1country.gxTpr_Countryflag = "Resources/Argentine_Flag.png";
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryname = "Mexico";
         Gxm1country.gxTpr_Countryflag = "Resources/Mexico_Flag.png";
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryname = "China";
         Gxm1country.gxTpr_Countryflag = "Resources/China_Flag.png";
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryname = "Estados Unidos";
         Gxm1country.gxTpr_Countryflag = "Resources/UnitedStates_Flag.png";
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
         Gxm1country = new SdtCountry(context);
         /* GeneXus formulas. */
      }

      private GXBCCollection<SdtCountry> Gxm2rootcol ;
      private SdtCountry Gxm1country ;
      private GXBCCollection<SdtCountry> aP0_Gxm2rootcol ;
   }

}
