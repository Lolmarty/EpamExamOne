using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace EpamExam
{
    public class RozetkaFilterHome //http://rozetka.com.ua/notebooks/c80004/filter/
    {
        public const string UrlAddress = @"http://rozetka.com.ua/notebooks/c80004/filter/";

        public RozetkaFilterHome(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            NamedEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {Named.Netbooks, cbFilterNamedNetbooks},
                {Named.ForNotComplex, cbFilterNamedForNotComplex},
                {Named.ForWork, cbFilterNamedForWork},
                {Named.ForBusiness, cbFilterNamedForBusiness},
                {Named.Multimedia, cbFilterNamedMultimedia},
                {Named.Gamers, cbFilterNamedGamers},
                {Named.Thin, cbFilterNamedThin},
                {Named.Transformers, cbFilterNamedTransformers},
            };
            ProducerEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {Producer.Acer, cbFilterProducerAcer},
                {Producer.Apple, cbFilterProducerApple},
                {Producer.Asus, cbFilterProducerAsus},
                {Producer.Dell, cbFilterProducerDell},
                {Producer.Fuji, cbFilterProducerFuji},
                {Producer.Giga, cbFilterProducerGiga},
                {Producer.HP, cbFilterProducerHP},
                {Producer.Lenovo, cbFilterProducerLenovo},
                {Producer.MSI, cbFilterProducerMSI},
                {Producer.Panas, cbFilterProducerPanas},
                {Producer.Tosh, cbFilterProducerTosh},
            };
            
            ScreenDiagEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {ScreenDiag.NineTenInch, cbFilterScreenDiagNineTenInch},
                {ScreenDiag.ElevenTwelveInch, cbFilterScreenDiagElevenTwelveInch},
                {ScreenDiag.ThirteenInch, cbFilterScreenDiagThirteenInch},
                {ScreenDiag.FourteenFifteenInch, cbFilterScreenDiagFourteenFifteenInch},
                {ScreenDiag.SixteenSeventeenInch, cbFilterScreenDiagSixteenSeventeenInch},
                {ScreenDiag.EighteenTwentyInch, cbFilterScreenDiagEighteenTwentyInch},
            };

            ScreenResolEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {ScreenResol.SR1366x768, cbFilterScreenResol1366x768},
                {ScreenResol.SR1440x900, cbFilterScreenResol1440x900},
                {ScreenResol.SR1600x900, cbFilterScreenResol1600x900},
                {ScreenResol.SRFullHD, cbFilterScreenResolFullHD},
                {ScreenResol.SRMoreThanFullHD, cbFilterScreenResolMoreThanFullHD},
            };
            
            ScreenTypeEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {ScreenType.IPS, cbFilterScreenTypeIPS},
                {ScreenType.Retina, cbFilterScreenTypeRetina},
                {ScreenType.IGZO, cbFilterScreenTypeIGZO},
            };
            ScreenCoverEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {ScreenCover.Gloss, cbFilterScreenCoverGloss},
                {ScreenCover.Matte, cbFilterScreenCoverMatte},
            };
            ScreenSensorEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {ScreenSensor.Yes, cbFilterScreenSensorYes},
                {ScreenSensor.No, cbFilterScreenSensorNo},
            };
            ProcessorEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {Processor.Inteli7, cbFilterProcessorInteli7},
                {Processor.Inteli5, cbFilterProcessorInteli5},
                {Processor.Inteli3, cbFilterProcessorInteli3},
                {Processor.IntelM, cbFilterProcessorIntelM},
                {Processor.IntelPentium, cbFilterProcessorIntelPentium},
                {Processor.IntelCeleron, cbFilterProcessorIntelCeleron},
                {Processor.IntelAtom, cbFilterProcessorIntelAtom},
                {Processor.AMDFX, cbFilterProcessorAMDFX},
                {Processor.AMDE, cbFilterProcessorAMDE},
                {Processor.AMDA10, cbFilterProcessorAMDA10},
                {Processor.AMDA8, cbFilterProcessorAMDA8},
                {Processor.AMDA6, cbFilterProcessorAMDA6},
                {Processor.AMDA4, cbFilterProcessorAMDA4},
            };
            RAMEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {RAM.LessThanFourGb, cbFilterRAMLessThanFourGb},
                {RAM.FourSixGb, cbFilterRAMFourSixGb},
                {RAM.EightTenGb, cbFilterRAMEightTenGb},
                {RAM.MoreThanTwelveGb, cbFilterRAMMoreThanTwelveGb},
            };
            GPUTypeEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {GPUType.Integrated, cbFilterGPUTypeIntegrated},
                {GPUType.AMDFirePro, cbFilterGPUTypeAMDFirePro},
                {GPUType.AMDRadeon, cbFilterGPUTypeAMDRadeon},
                {GPUType.NVidiaGeForce, cbFilterGPUTypeNVidiaGeForce},
                {GPUType.NVidiaQuadro, cbFilterGPUTypeNVidiaQuadro},
            };
            GPUMemoryCapacityEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {GPUMemoryCapacity.OneGb, cbFilterGPUMemoryCapacityOneGb},
                {GPUMemoryCapacity.TwoGb, cbFilterGPUMemoryCapacityTwoGb},
                {GPUMemoryCapacity.MoreThanTwoGb, cbFilterGPUMemoryCapacityMoreThanTwoGb},
            };
            StorageTypeEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {StorageType.HDD, cbFilterStorageTypeHDD},
                {StorageType.SSD, cbFilterStorageTypeSSD},
                {StorageType.HDDSSD, cbFilterStorageTypeHDDSSD},
                {StorageType.EMMC, cbFilterStorageTypeEMMC},
                {StorageType.HDDeMMC, cbFilterStorageTypeHDDeMMC},
            };
            StorageVolumeEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {StorageVolume.LessThanHalfTb, cbFilterStorageVolumeLessThanHalfTb},
                {StorageVolume.HalfThreeQuartTb, cbFilterStorageVolumeHalfThreeQuartTb},
                {StorageVolume.ThreeQuartOneTb, cbFilterStorageVolumeThreeQuartOneTb},
                {StorageVolume.OneTwoTb, cbFilterStorageVolumeOneTwoTb},
                {StorageVolume.MoreThanTwoTb, cbFilterStorageVolumeMoreThanTwoTb},
            };
            OpticalDriveEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {OpticalDrive.BR, cbFilterOpticalDriveBR},
                {OpticalDrive.DVD, cbFilterOpticalDriveDVD},
                {OpticalDrive.No, cbFilterOpticalDriveNo},
            };
            OSEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {OS.Win10, cbFilterOSWin10},
                {OS.Win8, cbFilterOSWin8},
                {OS.Win7Or8Pro, cbFilterOSWin7Or8Pro},
                {OS.Mac, cbFilterOSMac},
                {OS.Linux, cbFilterOSLinux},
                {OS.No, cbFilterOSNo},
            };
            UAKeysEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {UAKeys.Yes, cbFilterUAKeysYes},
                {UAKeys.No, cbFilterUAKeysNo},
            };
            WeightEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {Weight.LessThanOneKg, cbFilterWeightLessThanOneKg},
                {Weight.OneOneAndHalfKg, cbFilterWeightOneOneAndHalfKg},
                {Weight.OneAndHalfTwoKg, cbFilterWeightOneAndHalfTwoKg},
                {Weight.MoreThanTwoKg, cbFilterWeightMoreThanTwoKg},
                {Weight.TwoAndHalfThreeKg, cbFilterWeightTwoAndHalfThreeKg},
                {Weight.MoreThanThreeKg, cbFilterWeightMoreThanThreeKg},
            };
            ColorEnumToCheckboxDictionary = new Dictionary<Enum, IWebElement>()
            {
                {Color.Black, cbFilterColorBlack},
                {Color.Blue, cbFilterColorBlue},
                {Color.Brown, cbFilterColorBrown},
                {Color.Gold, cbFilterColorGold},
                {Color.Grey, cbFilterColorGrey},
                {Color.Pink, cbFilterColorPink},
                {Color.Red, cbFilterColorRed},
                {Color.Silver, cbFilterColorSilver},
                {Color.White, cbFilterColorWhite},
                {Color.Yellow, cbFilterColorYellow},
            };
            
            FilterEnumToCheckboxDictionary = new Dictionary<Enum, Dictionary<Enum, IWebElement>>()
            {
                {Filters.Named, NamedEnumToCheckboxDictionary},
                {Filters.Producer, ProducerEnumToCheckboxDictionary},
                {Filters.ScreenDiag, ScreenDiagEnumToCheckboxDictionary},
                {Filters.ScreenResol, ScreenResolEnumToCheckboxDictionary},
                {Filters.ScreenType, ScreenTypeEnumToCheckboxDictionary},
                {Filters.ScreenCover, ScreenCoverEnumToCheckboxDictionary},
                {Filters.ScreenSensor, ScreenSensorEnumToCheckboxDictionary},
                {Filters.Processor, ProcessorEnumToCheckboxDictionary},
                {Filters.RAM, RAMEnumToCheckboxDictionary},
                {Filters.GPUType, GPUTypeEnumToCheckboxDictionary},
                {Filters.GPUMemoryCapacity, GPUMemoryCapacityEnumToCheckboxDictionary},
                {Filters.StorageType, StorageTypeEnumToCheckboxDictionary},
                {Filters.StorageVolume, StorageVolumeEnumToCheckboxDictionary},
                {Filters.OpticalDrive, OpticalDriveEnumToCheckboxDictionary},
                {Filters.OS, OSEnumToCheckboxDictionary},
                {Filters.UAKeys, UAKeysEnumToCheckboxDictionary},
                {Filters.Weight, WeightEnumToCheckboxDictionary},
                {Filters.Color, ColorEnumToCheckboxDictionary},
            };

        }

        public Dictionary<Enum, Dictionary<Enum, IWebElement>> FilterEnumToCheckboxDictionary;

        //named filters
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_named_filters\"]/li[1]/label")] //Netbooks
        public IWebElement cbFilterNamedNetbooks { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_named_filters\"]/li[2]/label")] //ForNotComplex
        public IWebElement cbFilterNamedForNotComplex { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_named_filters\"]/li[3]/label")] //ForWork
        public IWebElement cbFilterNamedForWork { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_named_filters\"]/li[4]/label")] //ForBusiness
        public IWebElement cbFilterNamedForBusiness { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_named_filters\"]/li[5]/label")] //Multimedia
        public IWebElement cbFilterNamedMultimedia { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_named_filters\"]/li[6]/label")] //Gamers
        public IWebElement cbFilterNamedGamers { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_named_filters\"]/li[7]/label")] //Thin
        public IWebElement cbFilterNamedThin { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_named_filters\"]/li[8]/label")] //Transformers
        public IWebElement cbFilterNamedTransformers { get; set; }

        public Dictionary<Enum, IWebElement> NamedEnumToCheckboxDictionary;

        //producer filters
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_producer\"]/li[1]/label")] // Acer
        public IWebElement cbFilterProducerAcer { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_producer\"]/li[2]/label")] // Apple
        public IWebElement cbFilterProducerApple { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_producer\"]/li[3]/label")] // Asus
        public IWebElement cbFilterProducerAsus { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_producer\"]/li[4]/label")] // Dell
        public IWebElement cbFilterProducerDell { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_producer\"]/li[5]/label")] // Fujitsu
        public IWebElement cbFilterProducerFuji { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_producer\"]/li[6]/label")] // Gigabyte
        public IWebElement cbFilterProducerGiga { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_producer\"]/li[7]/label")] // HP
        public IWebElement cbFilterProducerHP { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_producer\"]/li[8]/label")] // Lenovo
        public IWebElement cbFilterProducerLenovo { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_producer\"]/li[9]/label")] // MSI
        public IWebElement cbFilterProducerMSI { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_producer\"]/li[10]/label")] // Panasonic
        public IWebElement cbFilterProducerPanas { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_producer\"]/li[11]/label")] // Toshiba
        public IWebElement cbFilterProducerTosh { get; set; }

        public Dictionary<Enum, IWebElement> ProducerEnumToCheckboxDictionary;


        //price filters ___ strange stuff, it doesn't want to work with names like that
        [FindsBy(How = How.Id, Using = "price[min]")]
        public IWebElement tbFilterPriceMin { get; set; }

        [FindsBy(How = How.Id, Using = "price[max]")]
        public IWebElement tbFilterPriceMax { get; set; }

        [FindsBy(How = How.Id, Using = "submitprice")]
        public IWebElement tbFilterPriceSubmit { get; set; }


        //screen diagonals
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20861\"]/li[1]/label")] // 9"-10"
        public IWebElement cbFilterScreenDiagNineTenInch { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20861\"]/li[2]/label")] // 11"-12.5"
        public IWebElement cbFilterScreenDiagElevenTwelveInch { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20861\"]/li[3]/label")] // 13"
        public IWebElement cbFilterScreenDiagThirteenInch { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20861\"]/li[4]/label")] // 14"-15.6"
        public IWebElement cbFilterScreenDiagFourteenFifteenInch { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20861\"]/li[5]/label")] // 16"-17"
        public IWebElement cbFilterScreenDiagSixteenSeventeenInch { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20861\"]/li[6]/label")] // 18"-20"
        public IWebElement cbFilterScreenDiagEighteenTwentyInch { get; set; }

        public Dictionary<Enum, IWebElement> ScreenDiagEnumToCheckboxDictionary;


        //screen resolutions
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_25800\"]/li[1]/label")] // 1366x768
        public IWebElement cbFilterScreenResol1366x768 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_25800\"]/li[2]/label")] // 1440x900
        public IWebElement cbFilterScreenResol1440x900 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_25800\"]/li[3]/label")] // 1600x900
        public IWebElement cbFilterScreenResol1600x900 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_25800\"]/li[4]/label")] // Full HD
        public IWebElement cbFilterScreenResolFullHD { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_25800\"]/li[5]/label")] // >Full HD
        public IWebElement cbFilterScreenResolMoreThanFullHD { get; set; }

        public Dictionary<Enum, IWebElement> ScreenResolEnumToCheckboxDictionary;


        //screen type
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_36519\"]/li[1]/label")] // IPS
        public IWebElement cbFilterScreenTypeIPS { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_36519\"]/li[2]/label")] // Retina
        public IWebElement cbFilterScreenTypeRetina { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_36519\"]/li[3]/label")] // IGZO
        public IWebElement cbFilterScreenTypeIGZO { get; set; }

        public Dictionary<Enum, IWebElement> ScreenTypeEnumToCheckboxDictionary;


        //screen surface cover
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_23541\"]/li[1]/label")] // Gloss
        public IWebElement cbFilterScreenCoverGloss { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_23541\"]/li[2]/label")] // Matte
        public IWebElement cbFilterScreenCoverMatte { get; set; }

        public Dictionary<Enum, IWebElement> ScreenCoverEnumToCheckboxDictionary;


        //touchscreen functionality
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_26413\"]/li[1]/label")] // Yes (touchscreen included)
        public IWebElement cbFilterScreenSensorYes { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_26413\"]/li[2]/label")] // No (touchscreen excluded)
        public IWebElement cbFilterScreenSensorNo { get; set; }

        public Dictionary<Enum, IWebElement> ScreenSensorEnumToCheckboxDictionary;


        //processors
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_processor\"]/li[1]/label")] // Intel i7
        public IWebElement cbFilterProcessorInteli7 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_processor\"]/li[2]/label")] // Intel i5
        public IWebElement cbFilterProcessorInteli5 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_processor\"]/li[3]/label")] // Intel i3
        public IWebElement cbFilterProcessorInteli3 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_processor\"]/li[4]/label")] // Intel M
        public IWebElement cbFilterProcessorIntelM { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_processor\"]/li[5]/label")] // Intel Pentium
        public IWebElement cbFilterProcessorIntelPentium { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_processor\"]/li[6]/label")] // Intel Celeron
        public IWebElement cbFilterProcessorIntelCeleron { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_processor\"]/li[7]/label")] // Intel Atom
        public IWebElement cbFilterProcessorIntelAtom { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_processor\"]/li[8]/label")] // AMD FX
        public IWebElement cbFilterProcessorAMDFX { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_processor\"]/li[9]/label")] // AMD E
        public IWebElement cbFilterProcessorAMDE { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_processor\"]/li[10]/label")] // AMD A10 
        public IWebElement cbFilterProcessorAMDA10 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_processor\"]/li[11]/label")] // AMD A8
        public IWebElement cbFilterProcessorAMDA8 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_processor\"]/li[12]/label")] // AMD A6
        public IWebElement cbFilterProcessorAMDA6 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_processor\"]/li[13]/label")] // AMD A4
        public IWebElement cbFilterProcessorAMDA4 { get; set; }

        public Dictionary<Enum, IWebElement> ProcessorEnumToCheckboxDictionary;


        //RAM capacity
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20863\"]/li[1]/label")] // <4Gb
        public IWebElement cbFilterRAMLessThanFourGb { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20863\"]/li[2]/label")] // 4-6Gb
        public IWebElement cbFilterRAMFourSixGb { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20863\"]/li[3]/label")] // 8-10Gb
        public IWebElement cbFilterRAMEightTenGb { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20863\"]/li[4]/label")] // >12Gb
        public IWebElement cbFilterRAMMoreThanTwelveGb { get; set; }

        public Dictionary<Enum, IWebElement> RAMEnumToCheckboxDictionary;


        //GPU type
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20881\"]/li[1]/label")] // Integrated
        public IWebElement cbFilterGPUTypeIntegrated { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20881\"]/li[2]/label")] // AMD FirePro
        public IWebElement cbFilterGPUTypeAMDFirePro { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20881\"]/li[3]/label")] // AMD Radeon
        public IWebElement cbFilterGPUTypeAMDRadeon { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20881\"]/li[4]/label")] // nVidia GeForce
        public IWebElement cbFilterGPUTypeNVidiaGeForce { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20881\"]/li[5]/label")] // nVidia Quadro
        public IWebElement cbFilterGPUTypeNVidiaQuadro { get; set; }

        public Dictionary<Enum, IWebElement> GPUTypeEnumToCheckboxDictionary;


        //GPU memory capacity
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_28042\"]/li[1]/label")] // 1Gb
        public IWebElement cbFilterGPUMemoryCapacityOneGb { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_28042\"]/li[2]/label")] // 2Gb
        public IWebElement cbFilterGPUMemoryCapacityTwoGb { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_28042\"]/li[3]/label")] // >2Gb
        public IWebElement cbFilterGPUMemoryCapacityMoreThanTwoGb { get; set; }

        public Dictionary<Enum, IWebElement> GPUMemoryCapacityEnumToCheckboxDictionary;


        //storage type
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_36514\"]/li[1]/label")] // HDD
        public IWebElement cbFilterStorageTypeHDD { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_36514\"]/li[2]/label")] // SSD
        public IWebElement cbFilterStorageTypeSSD { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_36514\"]/li[3]/label")] // HDD + SSD
        public IWebElement cbFilterStorageTypeHDDSSD { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_36514\"]/li[4]/label")] // eMMC
        public IWebElement cbFilterStorageTypeEMMC { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_36514\"]/li[5]/label")] // HDD + eMMC
        public IWebElement cbFilterStorageTypeHDDeMMC { get; set; }

        public Dictionary<Enum, IWebElement> StorageTypeEnumToCheckboxDictionary;


        //storage volume
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20882\"]/li[1]/label")] // <500Gb
        public IWebElement cbFilterStorageVolumeLessThanHalfTb { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20882\"]/li[2]/label")] // 500Gb - 750Gb
        public IWebElement cbFilterStorageVolumeHalfThreeQuartTb { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20882\"]/li[3]/label")] // 750Gb - 1Tb
        public IWebElement cbFilterStorageVolumeThreeQuartOneTb { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20882\"]/li[4]/label")] // 1Tb - 2Tb
        public IWebElement cbFilterStorageVolumeOneTwoTb { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20882\"]/li[5]/label")] // >2Tb
        public IWebElement cbFilterStorageVolumeMoreThanTwoTb { get; set; }

        public Dictionary<Enum, IWebElement> StorageVolumeEnumToCheckboxDictionary;


        //optical drive
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20868\"]/li[1]/label")] // Blu-Ray
        public IWebElement cbFilterOpticalDriveBR { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20868\"]/li[2]/label")] // DVD
        public IWebElement cbFilterOpticalDriveDVD { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20868\"]/li[3]/label")] // No (optical drive excluded)
        public IWebElement cbFilterOpticalDriveNo { get; set; }

        public Dictionary<Enum, IWebElement> OpticalDriveEnumToCheckboxDictionary;


        //OS
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20886\"]/li[1]/label")] // Win10
        public IWebElement cbFilterOSWin10 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20886\"]/li[2]/label")] // Win8.x
        public IWebElement cbFilterOSWin8 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20886\"]/li[3]/label")] // Win7/8.x Professional
        public IWebElement cbFilterOSWin7Or8Pro { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20886\"]/li[4]/label")] // Mac OS
        public IWebElement cbFilterOSMac { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20886\"]/li[5]/label")] // Linux
        public IWebElement cbFilterOSLinux { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20886\"]/li[6]/label")] // No (OS excluded)
        public IWebElement cbFilterOSNo { get; set; }

        public Dictionary<Enum, IWebElement> OSEnumToCheckboxDictionary;


        //Ukrainian key layout 
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_56017\"]/li[1]/label")] // Yes (Ukrainian key layout included)
        public IWebElement cbFilterUAKeysYes { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_56017\"]/li[2]/label")] // No (Ukrainian key layout excluded)
        public IWebElement cbFilterUAKeysNo { get; set; }

        public Dictionary<Enum, IWebElement> UAKeysEnumToCheckboxDictionary;


        //weight
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20884\"]/li[1]/label")] // <1kg
        public IWebElement cbFilterWeightLessThanOneKg { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20884\"]/li[2]/label")] // 1 - 1.5kg
        public IWebElement cbFilterWeightOneOneAndHalfKg { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20884\"]/li[3]/label")] // 1.5 - 2kg
        public IWebElement cbFilterWeightOneAndHalfTwoKg { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20884\"]/li[4]/label")] // >2kg
        public IWebElement cbFilterWeightMoreThanTwoKg { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20884\"]/li[5]/label")] // 2.5 - 3kg
        public IWebElement cbFilterWeightTwoAndHalfThreeKg { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_20884\"]/li[6]/label")] // >3kg
        public IWebElement cbFilterWeightMoreThanThreeKg { get; set; }

        public Dictionary<Enum, IWebElement> WeightEnumToCheckboxDictionary;


        //color
        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_21737\"]/li[1]/label")] // Black
        public IWebElement cbFilterColorBlack { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_21737\"]/li[2]/label")] // Blue
        public IWebElement cbFilterColorBlue { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_21737\"]/li[3]/label")] // Brown
        public IWebElement cbFilterColorBrown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_21737\"]/li[4]/label")] // Gold
        public IWebElement cbFilterColorGold { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_21737\"]/li[5]/label")] // Grey
        public IWebElement cbFilterColorGrey { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_21737\"]/li[6]/label")] // Pink
        public IWebElement cbFilterColorPink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_21737\"]/li[7]/label")] // Red
        public IWebElement cbFilterColorRed { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_21737\"]/li[8]/label")] // Silver
        public IWebElement cbFilterColorSilver { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_21737\"]/li[9]/label")] // White
        public IWebElement cbFilterColorWhite { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sort_21737\"]/li[10]/label")] // Yellow
        public IWebElement cbFilterColorYellow { get; set; }

        public Dictionary<Enum, IWebElement> ColorEnumToCheckboxDictionary;

        
        //goods container
        [FindsBy(How = How.XPath, Using = "//*[@id=\"block_with_goods\"]")]
        public IWebElement contGoods { get; set; }

        
        //loader pane
        [FindsBy(How = How.Name, Using = "more_goods")]
        public IWebElement MoreGoodsPane { get; set; }
    }
}
