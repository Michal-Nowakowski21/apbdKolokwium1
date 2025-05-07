using APBDkolokwium.ModelsDTOs;

namespace APBDkolokwium.Services;

public interface IDbService
{

    Task <appointmentDTO> getAppointment(int id);
}