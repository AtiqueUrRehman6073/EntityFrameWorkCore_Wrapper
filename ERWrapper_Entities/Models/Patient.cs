using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore_Wrapper.Models;

public partial class Patient
{
    public long PatientAccount { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Mi { get; set; }

    public string? Ssn { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? MaritalStatus { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? HomePhone { get; set; }

    public string? BusinessPhone { get; set; }

    public long? FinancialGuarantor { get; set; }

    public string? EmailAddress { get; set; }

    public string? EligibilityStatus { get; set; }

    public long? LocationCode { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public string? ChartId { get; set; }

    public long? Hl7patientAccount { get; set; }

    public bool? MoveCollection { get; set; }

    public long? PracticeCode { get; set; }

    public bool? ChkBounceBit { get; set; }

    public string? ChkBounceNo { get; set; }

    public DateTime? ChkBounceDate { get; set; }

    public DateTime? ChkBounceEntryDate { get; set; }

    public bool? PatientPaymentPlan { get; set; }

    public bool? PatientStatement { get; set; }

    public string? PatientType { get; set; }

    public string? ScanNo { get; set; }

    public bool? As { get; set; }

    public bool? WebResolve { get; set; }

    public DateTime? WebResolveDate { get; set; }

    public string? PtlWebAppearnceDays { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Deleted { get; set; }

    public bool? PtlStatus { get; set; }

    public DateTime? PtlDate { get; set; }

    public DateTime? ScanDate { get; set; }

    public long? EmployerCode { get; set; }

    public DateTime? SyncDate { get; set; }

    public string? EmerContactName { get; set; }

    public string? EmerContactRel { get; set; }

    public string? EmerContactPh { get; set; }

    public string? GuarRel { get; set; }

    public DateTime? DisabledDate { get; set; }

    public long? LabId { get; set; }

    public long? PharmacyId { get; set; }

    public long? ProviderCode { get; set; }

    public long? AlternateId { get; set; }

    public string? Notes { get; set; }

    public string? CellPhone { get; set; }

    public string? Ext { get; set; }

    public long? ReferringPhysician { get; set; }

    public bool? AddressToGuarantor { get; set; }

    public string? SpecialBillingNote { get; set; }

    public bool? Terminated { get; set; }

    public string? CreatedFrom { get; set; }

    public string? RemNotes { get; set; }

    public bool? RemFlag { get; set; }

    public DateTime? ScanDatePtl { get; set; }

    public string? PageNo { get; set; }

    public bool? StopBrc { get; set; }

    public Guid? Rowguid { get; set; }

    public bool? AddressMissing { get; set; }

    public DateTime? AddressExpiryDate { get; set; }

    public string? Ethnicities { get; set; }

    public string? Race { get; set; }

    public string? Languages { get; set; }

    public string? DeathCause { get; set; }

    public string? SsformularyBenefitPlans { get; set; }

    public string? SchedulerNotes { get; set; }

    public bool? ChkHospice { get; set; }

    public bool? CopayWaived { get; set; }

    public string? DuplicateEmailId { get; set; }

    public bool? CreditCardOnFile { get; set; }

    public bool? PracAddressPtBilling { get; set; }

    public string? AddressLine2 { get; set; }

    public long? PatientGlobalId { get; set; }

    public bool? AllowGlobalSharing { get; set; }

    public bool? StopCalls { get; set; }

    public string? PatientCategory { get; set; }

    public string? AdjusterName { get; set; }

    public string? AdjusterContactNo { get; set; }

    public string? PatientAlertNotes { get; set; }

    public string? PatientAlert { get; set; }

    public string? FamilyName { get; set; }

    public long? FamilyId { get; set; }

    public string? FamiliyIdd { get; set; }

    public bool? AddressToFamily { get; set; }

    public string? Race2 { get; set; }

    public string? MotherFname { get; set; }

    public string? MotherLname { get; set; }

    public string? FatherFname { get; set; }

    public string? FatherLname { get; set; }

    public string? AlternatePhone { get; set; }

    public bool? TerminationNotice { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public DateTime? ConfirmationDate { get; set; }

    public string? PrimaryPhone { get; set; }

    public bool? Invalidphonenumber { get; set; }

    public bool? InvalidPhoneNo { get; set; }

    public string? CommunicationPreferenceType { get; set; }

    public string? CommunicationPreferenceValue { get; set; }

    public string? AddressType { get; set; }

    public string? FatherCell { get; set; }

    public string? MotherCell { get; set; }

    public long? Pharmacy2Id { get; set; }

    public string? PictureAddress { get; set; }

    public string? SpouseCell { get; set; }

    public string? SpouseFname { get; set; }

    public string? SpouseLname { get; set; }

    public DateTime? RegistrationCompleteDate { get; set; }

    public string? AdditionalBrc { get; set; }

    public int? BrcGenerated { get; set; }

    public bool? Exempt { get; set; }

    public string? HomePhoneType { get; set; }

    public string? CellPhoneType { get; set; }

    public string? WorkPhoneType { get; set; }

    public long? Patamendmentid { get; set; }

    public string? PhrEnable { get; set; }

    public string? PhrAll { get; set; }

    public string? PhrNew { get; set; }

    public string? PhrInactive { get; set; }

    public string? MiddleName { get; set; }

    public string? CountyParishCode { get; set; }

    public string? SkypeName { get; set; }

    public DateTime? RecallDate { get; set; }

    public bool? Remindercallimmunization { get; set; }

    public bool? CheckNoemail { get; set; }

    public string? BloodType { get; set; }

    public long? PrimaryCarePhysician { get; set; }

    public bool? IsSelfPay { get; set; }

    public string? AdjusterPhone { get; set; }

    public DateTime? InactivationDate { get; set; }

    public bool? IsConsentAgree { get; set; }

    public bool? IsFinancilAgree { get; set; }

    public string? FamRelation { get; set; }

    public bool? FamilyBit { get; set; }

    public bool? GuarantorBit { get; set; }

    public int? ChronicCare { get; set; }

    public string? RiskLevel { get; set; }

    public string? Country { get; set; }

    public string? AdvanceDirective { get; set; }

    public bool? IsDisable { get; set; }

    public bool? TransBit { get; set; }

    public bool? TransStatus { get; set; }

    public bool? IsCollaboratingPractice { get; set; }

    public string? AccessLevel { get; set; }

    public bool? IsSupervisor { get; set; }

    public string? PsychiatricCaseStatus { get; set; }

    public long? PlanId { get; set; }

    public bool? UndeliverableAddress { get; set; }

    public DateTime? StReturnDate { get; set; }

    public long? PcpCode { get; set; }

    public bool? IsAcoPatient { get; set; }

    public bool? IsValidAddress { get; set; }

    public DateTime? AdmissionDate { get; set; }

    public DateTime? DischargeDate { get; set; }

    public string? Preferredphone { get; set; }

    public bool? BrcChk { get; set; }
}
