namespace APBDkolokwium.ModelsDTOs;

public class appointmentDTO
{
    public DateTime date{get;set;}
    public PatientDTO patient{get;set;}
    public DoctorDTO doctor{get;set;}
    public appointmentServicesDTO appointmentServices{get;set;}
}