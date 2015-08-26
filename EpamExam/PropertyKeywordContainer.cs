using System;
using System.Collections.Generic;

namespace EpamExam
{
    public enum Filters
    {
        Named,
        Producer,
        ScreenDiag,
        ScreenResol,
        ScreenType,
        ScreenCover,
        ScreenSensor,
        Processor,
        RAM,
        GPUType,
        GPUMemoryCapacity,
        StorageType,
        StorageVolume,
        OpticalDrive,
        OS,
        UAKeys,
        Weight,
        Color,
    }
    public enum Named
    {
        Netbooks,
        ForNotComplex,
        ForWork,
        ForBusiness,
        Multimedia,
        Gamers,
        Thin,
        Transformers,
    }
    public enum Producer
    {
        Acer,
        Apple,
        Asus,
        Dell,
        Fuji,
        Giga,
        HP,
        Lenovo,
        MSI,
        Panas,
        Tosh,
    }
    public enum ScreenDiag
    {
        NineTenInch,
        ElevenTwelveInch,
        ThirteenInch,
        FourteenFifteenInch,
        SixteenSeventeenInch,
        EighteenTwentyInch,
    }
    public enum ScreenResol
    {
        SR1366x768,
        SR1440x900,
        SR1600x900,
        SRFullHD,
        SRMoreThanFullHD,
    }
    public enum ScreenType
    {
        IPS,
        Retina,
        IGZO,
    }
    public enum ScreenCover
    {
        Gloss,
        Matte,
    }
    public enum ScreenSensor
    {
        Yes,
        No,
    }
    public enum Processor
    {
        Inteli7,
        Inteli5,
        Inteli3,
        IntelM,
        IntelPentium,
        IntelCeleron,
        IntelAtom,
        AMDFX,
        AMDE,
        AMDA10,
        AMDA8,
        AMDA6,
        AMDA4,
    }
    public enum RAM
    {
        LessThanFourGb,
        FourSixGb,
        EightTenGb,
        MoreThanTwelveGb,
    }
    public enum GPUType
    {
        Integrated,
        AMDFirePro,
        AMDRadeon,
        NVidiaGeForce,
        NVidiaQuadro,
    }
    public enum GPUMemoryCapacity
    {
        OneGb,
        TwoGb,
        MoreThanTwoGb,
    }
    public enum StorageType
    {
        HDD,
        SSD,
        HDDSSD,
        EMMC,
        HDDeMMC,
    }
    public enum StorageVolume
    {
        LessThanHalfTb,
        HalfThreeQuartTb,
        ThreeQuartOneTb,
        OneTwoTb,
        MoreThanTwoTb,
    }
    public enum OpticalDrive
    {
        BR,
        DVD,
        No,
    }
    public enum OS
    {
        Win10,
        Win8,
        Win7Or8Pro,
        Mac,
        Linux,
        No,
    }
    public enum UAKeys
    {
        Yes,
        No,
    }
    public enum Weight
    {
        LessThanOneKg,
        OneOneAndHalfKg,
        OneAndHalfTwoKg,
        MoreThanTwoKg,
        TwoAndHalfThreeKg,
        MoreThanThreeKg,
    }
    public enum Color
    {
        Black,
        Blue,
        Brown,
        Gold,
        Grey,
        Pink,
        Red,
        Silver,
        White,
        Yellow,
    }

    class PropertyKeywordContainer
    {
        public static Dictionary<Enum, string[]> FilterKeywordPairs = new Dictionary<Enum, string[]>()
        {
            {Filters.Named, new string[] {}},
            {Filters.Producer, new string[] {}},
            {Filters.ScreenDiag, new string[] {"Экран", "Краткие характеристики"}},
            {Filters.ScreenResol, new string[] {"Экран", "Краткие характеристики"}},
            {Filters.ScreenType, new string[] {"Экран", "Краткие характеристики"}},
            {Filters.ScreenCover, new string[] {"Экран", "Краткие характеристики"}},
            {Filters.ScreenSensor, new string[] {"Экран", "Краткие характеристики"}},
            {Filters.Processor, new string[] {"Процессор", "Краткие характеристики"}},
            {Filters.RAM, new string[] {"Объем оперативной памяти"}},
            {Filters.GPUType, new string[] {"Графический адаптер", "Краткие характеристики"}},
            {Filters.GPUMemoryCapacity, new string[] {"Графический адаптер"}},
            {Filters.StorageType, new string[] {"Объём накопителя", "Краткие характеристики"}},
            {Filters.StorageVolume, new string[] {"Объём накопителя"}},
            {Filters.OpticalDrive, new string[] {"Оптический привод"}},
            {Filters.OS, new string[] {"Операционная система", "Краткие характеристики"}},
            {Filters.UAKeys, new string[] {"Украинская раскладка клавиатуры"}},
            {Filters.Weight, new string[] {"Вес", "Краткие характеристики"}},
            {Filters.Color, new string[] {"Цвет"}}
        };

        public static Dictionary<Enum,string> NamedEnumDict = new Dictionary<Enum,string>
        {
            {Named.Netbooks,"Нетбуки"},
            {Named.ForNotComplex,"Для несложных задач"},
            {Named.ForWork,"Для работы и учёбы"},
            {Named.ForBusiness,"Для бизнеса"},
            {Named.Multimedia,"Мультимедийные центры"},
            {Named.Gamers,"Геймерские ноутбуки"},
            {Named.Thin,"Тонкие и лёгкие"},
            {Named.Transformers,"Трансформеры"},
        };  //useful?

        public static Dictionary<Enum,string> ProducerEnumDict = new Dictionary<Enum,string>
        {
            {Producer.Acer,"Acer"},
            {Producer.Apple,"Apple"},
            {Producer.Asus,"Asus"},
            {Producer.Dell,"Dell"},
            {Producer.Fuji,"Fujitsu"},
            {Producer.Giga,"Gigabyte"},
            {Producer.HP,"HP"},
            {Producer.Lenovo,"Lenovo"},
            {Producer.MSI,"MSI"},
            {Producer.Panas,"Panasonic"},
            {Producer.Tosh,"Toshiba"},
        };  // CONTAINS

        public static Dictionary<Enum,Range> ScreenDiagEnumDict = new Dictionary<Enum,Range>
        {
            {ScreenDiag.NineTenInch, new Range(9, 10)},
            {ScreenDiag.ElevenTwelveInch, new Range(11, 12.5)},
            {ScreenDiag.ThirteenInch, new Range(13, 14)},
            {ScreenDiag.FourteenFifteenInch, new Range(14, 15.6)},
            {ScreenDiag.SixteenSeventeenInch, new Range(16, 17)},
            {ScreenDiag.EighteenTwentyInch, new Range(18, 20)},
        };  // IN RANGE IN INCHES

        public static string ScreenDiagCapruteSeq = @"(\d{2}\.{0,1}\d{0,1})";

        public static Dictionary<Enum,string[]> ScreenResolEnumDict = new Dictionary<Enum,string[]>
        {
            {ScreenResol.SR1366x768, new string[] {"1366x768"}},
            {ScreenResol.SR1440x900, new string[] {"1440x900"}},
            {ScreenResol.SR1600x900, new string[] {"1600x900"}},
            {ScreenResol.SRFullHD, new string[] {"1920x1080", "Full HD"}},
            {ScreenResol.SRMoreThanFullHD, new string[] {"Больше Full HD", "2304x1440","2560x1440","WQHD","2880x1800"}}, 
        };  // OR
        
        public static Dictionary<Enum,string[]> ScreenTypeEnumDict = new Dictionary<Enum,string[]>
        {
            {ScreenType.IPS, new string[]{"IPS"}},
            {ScreenType.Retina, new string[]{"Retina"}},
            {ScreenType.IGZO, new string[]{"IGZO"}},
        };  // CONTAINS (or not if something else)

        public static Dictionary<Enum,string[]> ScreenCoverEnumDict = new Dictionary<Enum,string[]>
        {
            {ScreenCover.Gloss, new string[]{"Глянцевое","глянцевый"}},
            {ScreenCover.Matte, new string[]{"Матовое","матовый"}},
        };  // CONTAINS

        public static Dictionary<Enum,string[]> ScreenSensorEnumDict = new Dictionary<Enum,string[]>
        {
            {ScreenSensor.Yes, new string[]{"touch", "Touch", "сенсорный"}},
            {ScreenSensor.No, new string[]{""}},
            //and not
        };  // CONTAINS OR

        public static Dictionary<Enum,string[]> ProcessorEnumDict = new Dictionary<Enum,string[]>
        {
            
            {Processor.Inteli7,new string[] {"Intel Core i7", "Intel i7"}},
            {Processor.Inteli5,new string[] {"Intel Core i5", "Intel i5"}},
            {Processor.Inteli3,new string[] {"Intel Core i3", "Intel i3"}},
            {Processor.IntelM,new string[] {"Intel Core M", "Intel M"}},
            {Processor.IntelPentium,new string[] {"Intel Pentium"}},
            {Processor.IntelCeleron,new string[] {"Intel Celeron"}},
            {Processor.IntelAtom,new string[] {"Intel Atom"}},
            {Processor.AMDFX,new string[] {"AMD FX", "FX"}},
            {Processor.AMDE,new string[] {"AMD E", "E"}},
            {Processor.AMDA10,new string[] {"AMD A10", "A10"}},
            {Processor.AMDA8,new string[] {"AMD A8", "A8"}},
            {Processor.AMDA6,new string[] {"AMD A6", "A6"}},
            {Processor.AMDA4,new string[] {"AMD A4", "A4"}},
        };  // CONTAINS OR

        public static Dictionary<Enum,Range> RAMEnumDict = new Dictionary<Enum,Range>
        {
            
            {RAM.LessThanFourGb, new Range(Double.MinValue, 4)},
            {RAM.FourSixGb, new Range(4, 6)},
            {RAM.EightTenGb, new Range(8, 10)},
            {RAM.MoreThanTwelveGb, new Range(12, Double.MaxValue)},
        };  // IN RANGE IN GIGABYTES

        public static string RAMCapruteSeq = @"(\d{1,2}) ГБ";


        public static Dictionary<Enum,string[]> GPUTypeEnumDict = new Dictionary<Enum,string[]>
        {
            
            {GPUType.Integrated, new string[] {"нтегр","Intel HD Graphics","Интегрированный"}},
            {GPUType.AMDFirePro, new string[] {"AMD FirePro", "FirePro"}},
            {GPUType.AMDRadeon, new string[] {"AMD Radeon", "Radeon"}},
            {GPUType.NVidiaGeForce, new string[] {"nVidia GeForce", "GeForce"}},
            {GPUType.NVidiaQuadro, new string[] {"nVidia Quadro", "Quadro"}},
        };  // CONTAINS

        public static Dictionary<Enum,Range> GPUMemoryCapacityEnumDict = new Dictionary<Enum,Range>
        {
            
            {GPUMemoryCapacity.OneGb, new Range(0, 1)},
            {GPUMemoryCapacity.TwoGb, new Range(1, 2)},
            {GPUMemoryCapacity.MoreThanTwoGb, new Range(2, Double.MaxValue)},
        }; // IN RANGE now
        public static string GPUMemoryCapacityCapruteSeq = @"(\d{1,2}) ГБ";

        public static Dictionary<Enum,string[]> StorageTypeEnumDict = new Dictionary<Enum,string[]>
        {
            {StorageType.HDD, new string[] {"HDD"}},
            {StorageType.SSD, new string[] {"SSD"}},
            {StorageType.HDDSSD, new string[] {"+", "SS"}},
            {StorageType.EMMC, new string[] {"eMMC"}},
            {StorageType.HDDeMMC, new string[] {"+", "eMMC"}},
        };  // AND

        public static Dictionary<Enum,Range> StorageVolumeEnumDict = new Dictionary<Enum,Range>
        {
            {StorageVolume.LessThanHalfTb, new Range(Double.MinValue, 0.5)},
            {StorageVolume.HalfThreeQuartTb, new Range(0.5, 0.75)},
            {StorageVolume.ThreeQuartOneTb, new Range(0.75, 1)},
            {StorageVolume.OneTwoTb, new Range(1, 2)},
            {StorageVolume.MoreThanTwoTb, new Range(2, Double.MaxValue)},
        };  // IN RANGE IN TERABYTES
        public static string StorageVolumeGigabyteCapruteSeq = @"(\d{1,3}) ГБ";
        public static string StorageVolumeTerabyteCapruteSeq = @"(\d{1,2}) ТБ";

        public static Dictionary<Enum,string[]> OpticalDriveEnumDict = new Dictionary<Enum,string[]>
        {
            {OpticalDrive.BR, new string[]{"Blu-Ray"}},
            {OpticalDrive.DVD, new string[]{"DVD"}},
            {OpticalDrive.No, new string[]{"Отсутствует"}},
        };  // CONTAINS

        public static Dictionary<Enum,string[]> OSEnumDict = new Dictionary<Enum,string[]>
        {
            
            {OS.Win10, new string[] {"Windows 10"}},
            {OS.Win8, new string[] {"Windows 8"}},
            {OS.Win7Or8Pro, new string[] {"Windows 7 Professional", "Windows 7 Pro", "Windows 8 Pro", "Windows 8.1 Pro"}},
            {OS.Mac, new string[] {"OS X"}},
            {OS.Linux, new string[] {"Linpus", "Linux"}},
            {OS.No, new string[] {"DOS", "Без ОС", "без ОС"}},
        };  // OR

        public static Dictionary<Enum,string[]> UAKeysEnumDict = new Dictionary<Enum,string[]>
        {
            {UAKeys.Yes, new string[]{"Есть"}},
            {UAKeys.No, new string[]{"Нет"}},
        };  // CONTAINS OR

        public static Dictionary<Enum,Range> WeightEnumDict = new Dictionary<Enum,Range>
        {
            {Weight.LessThanOneKg, new Range(Double.MinValue, 1)},
            {Weight.OneOneAndHalfKg, new Range(1, 1.5)},
            {Weight.OneAndHalfTwoKg, new Range(1.5, 2)},
            {Weight.MoreThanTwoKg, new Range(2, 2.5)},
            {Weight.TwoAndHalfThreeKg, new Range(2.5, 3)},
            {Weight.MoreThanThreeKg, new Range(3, Double.MaxValue)},
        };  //IN RANGE
        public static string WeightCapruteSeq = @"(\d{1,2}\.{0,1}\d{0,2}) кг";

        public static Dictionary<Enum,string[]> ColorEnumDict = new Dictionary<Enum,string[]>
        {
            
            {Color.Black, new string[] {"Black"}},
            {Color.Blue, new string[] {"Blue"}},
            {Color.Brown, new string[] {"Brown"}},
            {Color.Gold, new string[] {"Gold"}},
            {Color.Grey, new string[] {"Grey"}},
            {Color.Pink, new string[] {"Pink"}},
            {Color.Red, new string[] {"Red"}},
            {Color.Silver, new string[] {"Silver"}},
            {Color.White, new string[] {"White"}},
            {Color.Yellow, new string[] {"Yellow"}},
        };  // CONTAINS OR
    }

    public class Range
    {
        public double Left;
        public double Right;

        public Range(double left, double right)
        {
            if (left <= right)
            {
                Left = left;
                Right = right;
            }
            else throw new ArgumentException("Left boundary must be less than or equal to right boundary");
        }

        public bool Has(double value)
        {
            return (Left <= value && value <= Right);
        }

        public override string ToString()
        {
            return "[" + Left.ToString() + ";" + Right.ToString() + "]";
        }
    }
}