using System;
using System.Collections.Generic;
using EntityFrameWorkCore_Wrapper.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_Wrapper.Context;

public partial class DemoContext : DbContext
{
    public DemoContext()
    {
    }

    public DemoContext(DbContextOptions<DemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Patient> Patients { get; set; }

    //public virtual DbSet<Patient1> Patients1 { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Dev-Test;Initial Catalog=MTBC-SYNCH;User ID=EDI;Password=edi@mtbc;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientAccount);

            entity.ToTable("Patient", tb =>
                {
                    tb.HasTrigger("TR_Patient_SYNC_DATE_INSERTED");
                    tb.HasTrigger("TR_Patient_SYNC_DATE_UPDATED");
                    tb.HasTrigger("pat_account");
                    tb.HasTrigger("tr_patient_U");
                    tb.HasTrigger("trigger2");
                });

            entity.HasIndex(e => e.ChartId, "IX_CHART");

            entity.HasIndex(e => new { e.PracticeCode, e.PatientType }, "IX_pat_type");

            entity.HasIndex(e => new { e.FirstName, e.LastName }, "MYindex");

            entity.HasIndex(e => new { e.FirstName, e.LastName }, "Mindex");

            entity.HasIndex(e => new { e.FirstName, e.LastName }, "P_Ind");

            entity.HasIndex(e => new { e.PracticeCode, e.PatientAccount, e.Deleted, e.DateOfBirth, e.LastName, e.FirstName }, "_dta_index_Patient_6_1017770683__K23_K40_K1_K3_K2_4_5_6_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21_22_30_31_36_37_38_39_41");

            entity.HasIndex(e => e.PracticeCode, "idx_comparision_pracitce");

            entity.HasIndex(e => new { e.PracticeCode, e.DateOfBirth }, "idx_patient_practice_code_name");

            entity.HasIndex(e => e.PatientAccount, "ix_01_23");

            entity.HasIndex(e => new { e.Ssn, e.PracticeCode }, "ix_patSSN");

            entity.HasIndex(e => e.LastName, "pindex");

            entity.HasIndex(e => e.LastName, "ti");

            entity.HasIndex(e => e.LastName, "tnn");

            entity.Property(e => e.PatientAccount)
                .ValueGeneratedNever()
                .HasColumnName("Patient_Account");
            entity.Property(e => e.AccessLevel)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Access_Level");
            entity.Property(e => e.AdditionalBrc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ADDITIONAL_BRC");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.AddressExpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("Address_Expiry_Date");
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Address_Line2");
            entity.Property(e => e.AddressMissing).HasColumnName("Address_Missing");
            entity.Property(e => e.AddressToFamily).HasColumnName("Address_To_Family");
            entity.Property(e => e.AddressToGuarantor).HasColumnName("Address_To_Guarantor");
            entity.Property(e => e.AddressType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Address_Type");
            entity.Property(e => e.AdjusterContactNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Adjuster_ContactNo");
            entity.Property(e => e.AdjusterName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Adjuster_Name");
            entity.Property(e => e.AdjusterPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Adjuster_Phone");
            entity.Property(e => e.AdmissionDate)
                .HasColumnType("datetime")
                .HasColumnName("Admission_Date");
            entity.Property(e => e.AdvanceDirective)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Advance_Directive");
            entity.Property(e => e.AllowGlobalSharing).HasColumnName("Allow_Global_Sharing");
            entity.Property(e => e.AlternateId).HasColumnName("alternate_id");
            entity.Property(e => e.AlternatePhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ALTERNATE_PHONE");
            entity.Property(e => e.As).HasColumnName("as");
            entity.Property(e => e.BloodType)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Blood_Type");
            entity.Property(e => e.BrcChk).HasColumnName("BRC_CHK");
            entity.Property(e => e.BrcGenerated).HasColumnName("brc_generated");
            entity.Property(e => e.BusinessPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Business_Phone");
            entity.Property(e => e.CellPhone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cell_phone");
            entity.Property(e => e.CellPhoneType)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("CELL_PHONE_TYPE");
            entity.Property(e => e.ChartId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Chart_Id");
            entity.Property(e => e.CheckNoemail).HasColumnName("check_noemail");
            entity.Property(e => e.ChkBounceBit).HasColumnName("CHK_Bounce_Bit");
            entity.Property(e => e.ChkBounceDate)
                .HasColumnType("datetime")
                .HasColumnName("CHK_Bounce_Date");
            entity.Property(e => e.ChkBounceEntryDate)
                .HasColumnType("datetime")
                .HasColumnName("CHK_Bounce_Entry_Date");
            entity.Property(e => e.ChkBounceNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CHK_Bounce_No");
            entity.Property(e => e.ChkHospice).HasColumnName("chk_Hospice");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CommunicationPreferenceType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CommunicationPreferenceValue)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationDate)
                .HasColumnType("datetime")
                .HasColumnName("Confirmation Date");
            entity.Property(e => e.CopayWaived).HasColumnName("Copay_Waived");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CountyParishCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CountyParish_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Created_By");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.CreatedFrom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_FROM");
            entity.Property(e => e.CreditCardOnFile).HasColumnName("Credit_Card_on_File");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("Date_Of_Birth");
            entity.Property(e => e.DeathCause)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.DisabledDate)
                .HasColumnType("datetime")
                .HasColumnName("disabled_date");
            entity.Property(e => e.DischargeDate)
                .HasColumnType("datetime")
                .HasColumnName("Discharge_Date");
            entity.Property(e => e.DuplicateEmailId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Duplicate_Email_Id");
            entity.Property(e => e.EffectiveDate)
                .HasColumnType("datetime")
                .HasColumnName("Effective Date");
            entity.Property(e => e.EligibilityStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('U')")
                .IsFixedLength()
                .HasColumnName("Eligibility_Status");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Email_Address");
            entity.Property(e => e.EmerContactName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emer_contact_name");
            entity.Property(e => e.EmerContactPh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("emer_contact_ph");
            entity.Property(e => e.EmerContactRel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emer_contact_rel");
            entity.Property(e => e.EmployerCode).HasColumnName("EMPLOYER_CODE");
            entity.Property(e => e.Ethnicities)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ETHNICITIES");
            entity.Property(e => e.Exempt).HasColumnName("EXEMPT");
            entity.Property(e => e.ExpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("Expiry_Date");
            entity.Property(e => e.Ext)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ext");
            entity.Property(e => e.FamRelation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Fam_Relation");
            entity.Property(e => e.FamiliyIdd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("familiy_IDD");
            entity.Property(e => e.FamilyId).HasColumnName("Family_id");
            entity.Property(e => e.FamilyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Family_Name");
            entity.Property(e => e.FatherCell)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Father_Cell");
            entity.Property(e => e.FatherFname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Father_FName");
            entity.Property(e => e.FatherLname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Father_LName");
            entity.Property(e => e.FinancialGuarantor).HasColumnName("Financial_Guarantor");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.Gender)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.GuarRel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("guar_rel");
            entity.Property(e => e.Hl7patientAccount).HasColumnName("HL7Patient_Account");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Home_Phone");
            entity.Property(e => e.HomePhoneType)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("HOME_PHONE_TYPE");
            entity.Property(e => e.InactivationDate)
                .HasColumnType("datetime")
                .HasColumnName("Inactivation_Date");
            entity.Property(e => e.InvalidPhoneNo).HasColumnName("INVALID_PHONE_NO");
            entity.Property(e => e.Invalidphonenumber).HasColumnName("invalidphonenumber");
            entity.Property(e => e.IsAcoPatient).HasColumnName("IS_ACO_PATIENT");
            entity.Property(e => e.IsCollaboratingPractice).HasColumnName("IS_COLLABORATING_PRACTICE");
            entity.Property(e => e.IsConsentAgree).HasColumnName("IS_CONSENT_AGREE");
            entity.Property(e => e.IsFinancilAgree).HasColumnName("IS_FINANCIL_AGREE");
            entity.Property(e => e.IsSelfPay).HasColumnName("Is_Self_Pay");
            entity.Property(e => e.IsValidAddress)
                .HasDefaultValueSql("((0))")
                .HasColumnName("IS_VALID_ADDRESS");
            entity.Property(e => e.LabId).HasColumnName("lab_id");
            entity.Property(e => e.Languages)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("languages");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.LocationCode).HasColumnName("Location_Code");
            entity.Property(e => e.MaritalStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Marital_Status");
            entity.Property(e => e.Mi)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MI");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MIDDLE_NAME");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Modified_By");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Modified_Date");
            entity.Property(e => e.MotherCell)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Mother_Cell");
            entity.Property(e => e.MotherFname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Mother_FName");
            entity.Property(e => e.MotherLname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Mother_LName");
            entity.Property(e => e.MoveCollection).HasColumnName("Move_Collection");
            entity.Property(e => e.Notes)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.PageNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Page_no");
            entity.Property(e => e.Patamendmentid).HasColumnName("PATAMENDMENTID");
            entity.Property(e => e.PatientAlert)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Patient_Alert");
            entity.Property(e => e.PatientAlertNotes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Patient_Alert_Notes");
            entity.Property(e => e.PatientCategory)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Patient_Category");
            entity.Property(e => e.PatientGlobalId).HasColumnName("Patient_GlobalId");
            entity.Property(e => e.PatientPaymentPlan).HasColumnName("Patient_Payment_Plan");
            entity.Property(e => e.PatientStatement).HasColumnName("Patient_Statement");
            entity.Property(e => e.PatientType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Patient_Type");
            entity.Property(e => e.PcpCode).HasColumnName("PCP_Code");
            entity.Property(e => e.Pharmacy2Id).HasColumnName("pharmacy2_id");
            entity.Property(e => e.PharmacyId).HasColumnName("pharmacy_id");
            entity.Property(e => e.PhrAll)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PHR_All");
            entity.Property(e => e.PhrEnable)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PHR_Enable");
            entity.Property(e => e.PhrInactive)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PHR_Inactive");
            entity.Property(e => e.PhrNew)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PHR_New");
            entity.Property(e => e.PictureAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Picture_Address");
            entity.Property(e => e.PlanId).HasColumnName("Plan_id");
            entity.Property(e => e.PracAddressPtBilling).HasColumnName("Prac_Address_PT_Billing");
            entity.Property(e => e.PracticeCode).HasColumnName("Practice_Code");
            entity.Property(e => e.Preferredphone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("PREFERREDPHONE");
            entity.Property(e => e.PrimaryCarePhysician).HasColumnName("Primary_Care_Physician");
            entity.Property(e => e.PrimaryPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PRIMARY_PHONE");
            entity.Property(e => e.ProviderCode).HasColumnName("provider_code");
            entity.Property(e => e.PsychiatricCaseStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PSYCHIATRIC_CASE_STATUS");
            entity.Property(e => e.PtlDate)
                .HasColumnType("datetime")
                .HasColumnName("PTL_Date");
            entity.Property(e => e.PtlStatus).HasColumnName("PTL_STATUS");
            entity.Property(e => e.PtlWebAppearnceDays)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("PTL_Web_Appearnce_Days");
            entity.Property(e => e.Race)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("race");
            entity.Property(e => e.Race2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("race2");
            entity.Property(e => e.RecallDate)
                .HasColumnType("datetime")
                .HasColumnName("Recall_Date");
            entity.Property(e => e.ReferringPhysician).HasColumnName("Referring_Physician");
            entity.Property(e => e.RegistrationCompleteDate)
                .HasColumnType("datetime")
                .HasColumnName("REGISTRATION_COMPLETE_DATE");
            entity.Property(e => e.RemFlag).HasColumnName("REM_FLAG");
            entity.Property(e => e.RemNotes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("REM_NOTES");
            entity.Property(e => e.Remindercallimmunization).HasColumnName("REMINDERCALLIMMUNIZATION");
            entity.Property(e => e.RiskLevel)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Risk_Level");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.ScanDate)
                .HasDefaultValueSql("(' ')")
                .HasColumnType("datetime")
                .HasColumnName("Scan_Date");
            entity.Property(e => e.ScanDatePtl)
                .HasColumnType("datetime")
                .HasColumnName("Scan_Date_Ptl");
            entity.Property(e => e.ScanNo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Scan_No");
            entity.Property(e => e.SchedulerNotes)
                .HasMaxLength(3000)
                .IsUnicode(false)
                .HasColumnName("scheduler_notes");
            entity.Property(e => e.SkypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Skype_Name");
            entity.Property(e => e.SpecialBillingNote)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Special_Billing_Note");
            entity.Property(e => e.SpouseCell)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SPOUSE_Cell");
            entity.Property(e => e.SpouseFname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SPOUSE_FName");
            entity.Property(e => e.SpouseLname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SPOUSE_LName");
            entity.Property(e => e.SsformularyBenefitPlans)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("SSFormulary_Benefit_Plans");
            entity.Property(e => e.Ssn)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SSN");
            entity.Property(e => e.StReturnDate)
                .HasColumnType("datetime")
                .HasColumnName("St_Return_Date");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StopBrc).HasColumnName("stop_brc");
            entity.Property(e => e.StopCalls).HasColumnName("Stop_Calls");
            entity.Property(e => e.SyncDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Sync_Date");
            entity.Property(e => e.TerminationNotice).HasColumnName("Termination Notice");
            entity.Property(e => e.TransBit).HasColumnName("Trans_bit");
            entity.Property(e => e.TransStatus).HasColumnName("Trans_Status");
            entity.Property(e => e.UndeliverableAddress).HasColumnName("Undeliverable_Address");
            entity.Property(e => e.WebResolve).HasColumnName("Web_Resolve");
            entity.Property(e => e.WebResolveDate)
                .HasColumnType("datetime")
                .HasColumnName("Web_Resolve_Date");
            entity.Property(e => e.WorkPhoneType)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("WORK_PHONE_TYPE");
            entity.Property(e => e.Zip)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("ZIP");
        });

        //modelBuilder.Entity<Patient1>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToTable("PATIENT", "ISB\\faisalmahmood");

        //    entity.Property(e => e.AdditionalBrc)
        //        .HasMaxLength(1)
        //        .IsUnicode(false)
        //        .IsFixedLength()
        //        .HasColumnName("ADDITIONAL_BRC");
        //    entity.Property(e => e.Address)
        //        .HasMaxLength(500)
        //        .IsUnicode(false);
        //    entity.Property(e => e.AddressExpiryDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("ADDRESS_EXPIRY_DATE");
        //    entity.Property(e => e.AddressLine2)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("Address_Line2");
        //    entity.Property(e => e.AddressMissing).HasColumnName("ADDRESS_MISSING");
        //    entity.Property(e => e.AddressToGuarantor).HasColumnName("Address_To_Guarantor");
        //    entity.Property(e => e.AddressType)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("Address_Type");
        //    entity.Property(e => e.AdjusterName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("Adjuster_Name");
        //    entity.Property(e => e.AdjusterPhone)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("Adjuster_Phone");
        //    entity.Property(e => e.AllowGlobalSharing).HasColumnName("Allow_Global_Sharing");
        //    entity.Property(e => e.AlternateId).HasColumnName("alternate_id");
        //    entity.Property(e => e.AlternatePhone)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("ALTERNATE_PHONE");
        //    entity.Property(e => e.As).HasColumnName("as");
        //    entity.Property(e => e.BloodType)
        //        .HasMaxLength(8)
        //        .IsUnicode(false)
        //        .HasColumnName("Blood_Type");
        //    entity.Property(e => e.BrcGenerated).HasColumnName("brc_generated");
        //    entity.Property(e => e.BusinessPhone)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("Business_Phone");
        //    entity.Property(e => e.CellPhone)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("cell_phone");
        //    entity.Property(e => e.CellPhoneType)
        //        .HasMaxLength(8)
        //        .IsUnicode(false)
        //        .HasColumnName("CELL_PHONE_TYPE");
        //    entity.Property(e => e.ChartId)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("Chart_Id");
        //    entity.Property(e => e.CheckNoemail).HasColumnName("check_noemail");
        //    entity.Property(e => e.ChkBounceBit).HasColumnName("CHK_Bounce_Bit");
        //    entity.Property(e => e.ChkBounceDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("CHK_Bounce_Date");
        //    entity.Property(e => e.ChkBounceEntryDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("CHK_Bounce_Entry_Date");
        //    entity.Property(e => e.ChkBounceNo)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("CHK_Bounce_No");
        //    entity.Property(e => e.ChkHospice).HasColumnName("chk_Hospice");
        //    entity.Property(e => e.City)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.CommunicationPreferenceType)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);
        //    entity.Property(e => e.CommunicationPreferenceValue)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.ConfirmationDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("Confirmation Date");
        //    entity.Property(e => e.CopayWaived).HasColumnName("Copay_Waived");
        //    entity.Property(e => e.CountyParishCode)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("CountyParish_code");
        //    entity.Property(e => e.CreatedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("Created_By");
        //    entity.Property(e => e.CreatedDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("Created_Date");
        //    entity.Property(e => e.CreatedFrom)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("CREATED_FROM");
        //    entity.Property(e => e.CreditCardOnFile).HasColumnName("Credit_Card_on_File");
        //    entity.Property(e => e.DateOfBirth)
        //        .HasColumnType("datetime")
        //        .HasColumnName("Date_Of_Birth");
        //    entity.Property(e => e.DeathCause)
        //        .HasMaxLength(5000)
        //        .IsUnicode(false);
        //    entity.Property(e => e.DisabledDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("disabled_date");
        //    entity.Property(e => e.DuplicateEmailId)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("DUPLICATE_EMAIL_ID");
        //    entity.Property(e => e.EffectiveDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("Effective Date");
        //    entity.Property(e => e.EligibilityStatus)
        //        .HasMaxLength(1)
        //        .IsUnicode(false)
        //        .IsFixedLength()
        //        .HasColumnName("Eligibility_Status");
        //    entity.Property(e => e.EmailAddress)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("Email_Address");
        //    entity.Property(e => e.EmerContactName)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("emer_contact_name");
        //    entity.Property(e => e.EmerContactPh)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("emer_contact_ph");
        //    entity.Property(e => e.EmerContactRel)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("emer_contact_rel");
        //    entity.Property(e => e.EmployerCode).HasColumnName("EMPLOYER_CODE");
        //    entity.Property(e => e.Ethnicities)
        //        .HasMaxLength(500)
        //        .IsUnicode(false)
        //        .HasColumnName("ETHNICITIES");
        //    entity.Property(e => e.Exempt).HasColumnName("EXEMPT");
        //    entity.Property(e => e.ExpiryDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("Expiry_Date");
        //    entity.Property(e => e.Ext)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("ext");
        //    entity.Property(e => e.FatherCell)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("Father_Cell");
        //    entity.Property(e => e.FatherFname)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("Father_FName");
        //    entity.Property(e => e.FatherLname)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("Father_LName");
        //    entity.Property(e => e.FinancialGuarantor).HasColumnName("Financial_Guarantor");
        //    entity.Property(e => e.FirstName)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("First_Name");
        //    entity.Property(e => e.Gender)
        //        .HasMaxLength(15)
        //        .IsUnicode(false);
        //    entity.Property(e => e.GuarRel)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("guar_rel");
        //    entity.Property(e => e.Hl7patientAccount).HasColumnName("HL7Patient_Account");
        //    entity.Property(e => e.HomePhone)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("Home_Phone");
        //    entity.Property(e => e.HomePhoneType)
        //        .HasMaxLength(8)
        //        .IsUnicode(false)
        //        .HasColumnName("HOME_PHONE_TYPE");
        //    entity.Property(e => e.InactivationDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("Inactivation_Date");
        //    entity.Property(e => e.InvalidPhoneNo).HasColumnName("INVALID_PHONE_NO");
        //    entity.Property(e => e.Invalidphonenumber).HasColumnName("invalidphonenumber");
        //    entity.Property(e => e.IsConsentAgree).HasColumnName("IS_CONSENT_AGREE");
        //    entity.Property(e => e.IsFinancilAgree).HasColumnName("IS_FINANCIL_AGREE");
        //    entity.Property(e => e.IsSelfPay).HasColumnName("Is_Self_Pay");
        //    entity.Property(e => e.LabId).HasColumnName("lab_id");
        //    entity.Property(e => e.Languages)
        //        .HasMaxLength(500)
        //        .IsUnicode(false)
        //        .HasColumnName("languages");
        //    entity.Property(e => e.LastName)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("Last_Name");
        //    entity.Property(e => e.LocationCode).HasColumnName("Location_Code");
        //    entity.Property(e => e.MaritalStatus)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("Marital_Status");
        //    entity.Property(e => e.Mi)
        //        .HasMaxLength(1)
        //        .IsUnicode(false)
        //        .IsFixedLength()
        //        .HasColumnName("MI");
        //    entity.Property(e => e.MiddleName)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("MIDDLE_NAME");
        //    entity.Property(e => e.ModifiedBy)
        //        .HasMaxLength(60)
        //        .IsUnicode(false)
        //        .HasColumnName("Modified_By");
        //    entity.Property(e => e.ModifiedDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("Modified_Date");
        //    entity.Property(e => e.MotherCell)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("Mother_Cell");
        //    entity.Property(e => e.MotherFname)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("Mother_FName");
        //    entity.Property(e => e.MotherLname)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("Mother_LName");
        //    entity.Property(e => e.MoveCollection).HasColumnName("Move_Collection");
        //    entity.Property(e => e.Notes)
        //        .HasMaxLength(5000)
        //        .IsUnicode(false)
        //        .HasColumnName("notes");
        //    entity.Property(e => e.PageNo)
        //        .HasMaxLength(15)
        //        .IsUnicode(false)
        //        .HasColumnName("PAGE_NO");
        //    entity.Property(e => e.Patamendmentid).HasColumnName("PATAMENDMENTID");
        //    entity.Property(e => e.PatientAccount).HasColumnName("Patient_Account");
        //    entity.Property(e => e.PatientAlert)
        //        .HasMaxLength(500)
        //        .IsUnicode(false)
        //        .HasColumnName("PATIENT_ALERT");
        //    entity.Property(e => e.PatientCategory)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("Patient_Category");
        //    entity.Property(e => e.PatientGlobalId).HasColumnName("Patient_GlobalId");
        //    entity.Property(e => e.PatientPaymentPlan).HasColumnName("Patient_Payment_Plan");
        //    entity.Property(e => e.PatientStatement).HasColumnName("Patient_Statement");
        //    entity.Property(e => e.PatientType)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("Patient_Type");
        //    entity.Property(e => e.Pharmacy2Id).HasColumnName("pharmacy2_id");
        //    entity.Property(e => e.PharmacyId).HasColumnName("pharmacy_id");
        //    entity.Property(e => e.PhrAll)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("PHR_All");
        //    entity.Property(e => e.PhrEnable)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("PHR_Enable");
        //    entity.Property(e => e.PhrInactive)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("PHR_Inactive");
        //    entity.Property(e => e.PhrNew)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("PHR_New");
        //    entity.Property(e => e.PictureAddress)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("Picture_Address");
        //    entity.Property(e => e.PracAddressPtBilling).HasColumnName("PRAC_ADDRESS_PT_BILLING");
        //    entity.Property(e => e.PracticeCode).HasColumnName("Practice_Code");
        //    entity.Property(e => e.PrimaryCarePhysician).HasColumnName("Primary_Care_Physician");
        //    entity.Property(e => e.PrimaryPhone)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("PRIMARY_PHONE");
        //    entity.Property(e => e.ProviderCode).HasColumnName("provider_code");
        //    entity.Property(e => e.PtlDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("PTL_Date");
        //    entity.Property(e => e.PtlStatus).HasColumnName("PTL_STATUS");
        //    entity.Property(e => e.PtlWebAppearnceDays)
        //        .HasMaxLength(10)
        //        .IsFixedLength()
        //        .HasColumnName("PTL_Web_Appearnce_Days");
        //    entity.Property(e => e.Race)
        //        .HasMaxLength(500)
        //        .IsUnicode(false)
        //        .HasColumnName("race");
        //    entity.Property(e => e.Race2)
        //        .HasMaxLength(500)
        //        .IsUnicode(false)
        //        .HasColumnName("RACE2");
        //    entity.Property(e => e.RecallDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("Recall_Date");
        //    entity.Property(e => e.ReferringPhysician).HasColumnName("Referring_Physician");
        //    entity.Property(e => e.RegistrationCompleteDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("REGISTRATION_COMPLETE_DATE");
        //    entity.Property(e => e.RemFlag).HasColumnName("REM_FLAG");
        //    entity.Property(e => e.RemNotes)
        //        .HasMaxLength(500)
        //        .IsUnicode(false)
        //        .HasColumnName("REM_NOTES");
        //    entity.Property(e => e.Remindercallimmunization).HasColumnName("REMINDERCALLIMMUNIZATION");
        //    entity.Property(e => e.Rowguid).HasColumnName("rowguid");
        //    entity.Property(e => e.ScanDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("Scan_Date");
        //    entity.Property(e => e.ScanDatePtl)
        //        .HasColumnType("datetime")
        //        .HasColumnName("SCAN_DATE_PTL");
        //    entity.Property(e => e.ScanNo)
        //        .HasMaxLength(25)
        //        .IsUnicode(false)
        //        .HasColumnName("Scan_No");
        //    entity.Property(e => e.SchedulerNotes)
        //        .HasMaxLength(3000)
        //        .IsUnicode(false)
        //        .HasColumnName("scheduler_notes");
        //    entity.Property(e => e.SkypeName)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("Skype_Name");
        //    entity.Property(e => e.SpecialBillingNote)
        //        .HasMaxLength(120)
        //        .IsUnicode(false)
        //        .HasColumnName("Special_Billing_Note");
        //    entity.Property(e => e.SpouseCell)
        //        .HasMaxLength(10)
        //        .IsUnicode(false)
        //        .HasColumnName("SPOUSE_Cell");
        //    entity.Property(e => e.SpouseFname)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("SPOUSE_FName");
        //    entity.Property(e => e.SpouseLname)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("SPOUSE_LName");
        //    entity.Property(e => e.SsformularyBenefitPlans)
        //        .HasMaxLength(1000)
        //        .IsUnicode(false)
        //        .HasColumnName("SSFormulary_Benefit_Plans");
        //    entity.Property(e => e.Ssn)
        //        .HasMaxLength(9)
        //        .IsUnicode(false)
        //        .IsFixedLength()
        //        .HasColumnName("SSN");
        //    entity.Property(e => e.State)
        //        .HasMaxLength(2)
        //        .IsUnicode(false)
        //        .IsFixedLength();
        //    entity.Property(e => e.StopBrc).HasColumnName("STOP_BRC");
        //    entity.Property(e => e.StopCalls).HasColumnName("STOP_CALLS");
        //    entity.Property(e => e.SyncDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("Sync_Date");
        //    entity.Property(e => e.TerminationNotice).HasColumnName("Termination Notice");
        //    entity.Property(e => e.WebResolve).HasColumnName("Web_Resolve");
        //    entity.Property(e => e.WebResolveDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("Web_Resolve_Date");
        //    entity.Property(e => e.WorkPhoneType)
        //        .HasMaxLength(8)
        //        .IsUnicode(false)
        //        .HasColumnName("WORK_PHONE_TYPE");
        //    entity.Property(e => e.Zip)
        //        .HasMaxLength(9)
        //        .IsUnicode(false)
        //        .HasColumnName("ZIP");
        //});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
