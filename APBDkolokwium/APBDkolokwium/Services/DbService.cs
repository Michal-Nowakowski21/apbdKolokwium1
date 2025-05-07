using System.Data.SqlTypes;
using APBDkolokwium.ModelsDTOs;
using Microsoft.AspNetCore.Mvc;

namespace APBDkolokwium.Services;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
public class DbService : IDbService
{
    private readonly IConfiguration _configuration;

    public DbService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    private readonly string _connectionString =
        "Server=localhost\\SQLEXPRESS;Database=APBDKolokwium1;Trusted_Connection=True;TrustServerCertificate=True;";
    public async Task<appointmentDTO> getAppointment(int id)
    {
        
        string command = "SELECT a.date,p.first_Name,p.last_Name,p.date_Of_Birth,d.doctor_Id,d.pwz,ss.name,s.service_fee FROM Appointment a join Patient p on a.patient_id = p.patient_id join Doctor d on a.doctor_id = d.doctor_id join Appointment_Service s on a.appoitment_id =s.appoitment_id join Service ss on s.service_id =ss.service_id   WHERE a.appoitment_id = @id";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(command, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var appointment = new appointmentDTO()
                        {
                            date = reader.GetDateTime(0),
                            patient = new PatientDTO(){
                                firstName = reader.GetString(1),
                                lastName = reader.GetString(2),
                                dateOfBirth = reader.GetDateTime(3),
                            },
                            doctor = new DoctorDTO(){
                                doctorId = reader.GetInt32(4),
                                pwz=reader.GetString(5),
                            },
                            appointmentServices = new appointmentServicesDTO(){
                                name=reader.GetString(6),
                                serviceFee=reader.GetDecimal(7),
                            }
                                
                                
                            
                        };
                        return appointment;

                    }
                }
            }
        }
        return null;
    }
}
   
    
