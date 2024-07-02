using System.Collections.Generic;

namespace GD
{
    [System.Serializable]
    public class TeamMember
    {
        public string Name;
        public List<DepartmentRole> role = new();
    }

    [System.Serializable]
    public class DepartmentRole
    {
        public DepartmentType Department;
        public RoleType Role;
    }

    [System.Serializable]
    public enum DepartmentType
    {
        GameDesign,
        Art,
        Programming,
        SoundDesign,
        QualityAssurance,
        Production,
        Marketing
    }

    [System.Serializable]
    public enum RoleType
    {
        // Game Design
        GD_LeadDesigner,

        GD_LevelDesigner,
        GD_Writer,
        GD_SystemDesigner,

        // Art
        ART_ConceptArtist,

        ART_3DModeler,
        ART_Animator,
        ART_TextureArtist,

        // Programming
        PROG_GameplayProgrammer,

        PROG_UXProgrammer,
        PROG_NetworkProgrammer,
        PROG_EngineProgrammer,

        // Sound Design
        SND_Composer,

        SND_SoundEffectsDesigner,
        SND_AudioEngineer,
        SND_VoiceOverDirector,

        // Quality Assurance
        QA_TestEngineer,

        QA_TestAnalyst,
        QA_TestLead,
        QA_AutomationEngineer,

        // Production
        PROD_Producer,

        PROD_AssociateProducer,
        PROD_ProductionAssistant,
        PROD_ScrumMaster,

        // Marketing
        MKT_MarketingStrategist,

        MKT_CommunityManager,
        MKT_PublicRelationsManager,
        MKT_BrandManager
    }

    /*
    [Flags]
    public enum RoleType
    {
        AIProgrammer = 1 << 0, // 1
        Animator = 1 << 1, // 2
        ArtDirector = 1 << 2, // 4
        AudioEngineer = 1 << 3, // 8
        CharacterArtist = 1 << 4, // 16
        CinematicArtist = 1 << 5, // 32
        ConceptArtist = 1 << 6, // 64
        ContentDesigner = 1 << 7, // 128
        EnvironmentArtist = 1 << 8, // 256
        GameDesigner = 1 << 9, // 512
        GameDirector = 1 << 10, // 1024
        GameProducer = 1 << 11, // 2048
        GameplayProgrammer = 1 << 12, // 4096
        GraphicsProgrammer = 1 << 13, // 8192
        InterfaceDesigner = 1 << 14, // 16384
        LevelDesigner = 1 << 15, // 32768
        LocalizationManager = 1 << 16, // 65536
        NarrativeDesigner = 1 << 17, // 131072
        NetworkProgrammer = 1 << 18, // 262144
        ParticleEffectsArtist = 1 << 19, // 524288
        QATester = 1 << 20, // 1048576
        RiggingArtist = 1 << 21, // 2097152
        ScriptWriter = 1 << 22, // 4194304
        SoundDesigner = 1 << 23, // 8388608
        SystemsDesigner = 1 << 24, // 16777216
        TechnicalArtist = 1 << 25, // 33554432
        TechnicalDirector = 1 << 26, // 67108864
        UIUXDesigner = 1 << 27, // 134217728
        VFXArtist = 1 << 28, // 268435456
        VoiceActor = 1 << 29, // 536870912
        Writer = 1 << 30  // 1073741824

        //SINCE enums are INTs we can only have 32 roles MAX!
    }
    */
}