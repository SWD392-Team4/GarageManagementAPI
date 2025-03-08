//using AutoMapper;
//using GarageManagementAPI.Entities.Models;
//using GarageManagementAPI.Repository.Contracts;
//using GarageManagementAPI.Service.Contracts;
//using GarageManagementAPI.Service.Extension;
//using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
//using GarageManagementAPI.Shared.Enums;
//using GarageManagementAPI.Shared.ErrorsConstant.Appointment;
//using GarageManagementAPI.Shared.ErrorsConstant.CarModel;
//using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
//using GarageManagementAPI.Shared.RequestFeatures;
//using GarageManagementAPI.Shared.ResultModel;

//namespace GarageManagementAPI.Service
//{
//    public class AppointmentService : IAppointmentService
//    {
//        private readonly IRepositoryManager _repoManager;
//        private readonly IMapper _mapper;
//        private readonly IDataShaperManager _dataShaper;

//        public AppointmentService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
//        {
//            _repoManager = repoManager;
//            _mapper = mapper;
//            _dataShaper = dataShaper;
//        }

//        public async Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsAsync(AppointmentParameters appointmentParameters, bool trackChanges)
//        {
//            var appointments = await _repoManager.Appointment.GetAppointmentsAsync(appointmentParameters, trackChanges);

//            var appointmentsDto = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);

//            return Result<IEnumerable<AppointmentDto>>.Ok(appointmentsDto, appointments.MetaData);
//        }

//        public async Task<Result> CheckIfCarModelExist(Guid carModelId)
//        {
//            var carModel = await _repoManager.CarModel.GetCarModelAsync(carModelId, false);

//            if (carModel == null)
//                return Result.NotFound([CarModelErrors.GetCarModelNotFoundError(carModelId)]);

//            return Result.Ok();
//        }

//        public async Task<Result> CheckIfGarageExist(Guid garageId)
//        {
//            var workplace = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);

//            if (workplace == null || workplace.WorkplaceType.Equals(WorkplaceType.Warehouse))
//                return Result.NotFound([WorkplaceErrors.GetWorkplaceNotFoundError(garageId)]);

//            return Result.Ok();
//        }

//        public async Task<Result<AppointmentDto>> CreateAppointment(AppointmentDtoForCreate appointmentDtoForCreate)
//        {
//            var carModelExist = await CheckIfCarModelExist(appointmentDtoForCreate.CarModelId);
//            if (!carModelExist.IsSuccess)
//                return Result<AppointmentDto>.NotFound(carModelExist.Errors!);

//            var garageExist = await CheckIfGarageExist(appointmentDtoForCreate.GarageId);
//            if (!garageExist.IsSuccess)
//                return Result<AppointmentDto>.NotFound(garageExist.Errors!);

//            if ((appointmentDtoForCreate.PackageList != null || appointmentDtoForCreate.ProductForSellings != null) && appointmentDtoForCreate.ServiceList != null)
//                return Result<AppointmentDto>.BadRequest([AppointmentErrors.GetInvalidAppointmentError()]);

//            var appointmentType = DetermineAppointmentType(appointmentDtoForCreate);

//            var appointment = _mapper.Map<Appointment>(appointmentDtoForCreate);

//            appointment.CreatedAt = DateTimeOffset.Now.SEAsiaStandardTime();
//            appointment.UpdatedAt = DateTimeOffset.Now.SEAsiaStandardTime();
//            await _repoManager.Appointment.CreateAsync(appointment);
//            await _repoManager.SaveAsync();

//            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
//            return Result<AppointmentDto>.Ok(appointmentDto);
//        }



//        public async Task<Result<AppointmentDto>> GetAppointmentAsync(Guid id, bool trackChanges)
//        {
//            var appointment = await _repoManager.Appointment.GetAppointmentAsync(id, trackChanges);

//            if (appointment is null)
//                return Result<AppointmentDto>.NotFound([AppointmentErrors.GetAppointmentNotFoundError(id)]);

//            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);

//            return Result<AppointmentDto>.Ok(appointmentDto);
//        }

//        private AppointmentType DetermineAppointmentType(AppointmentDtoForCreate appointmentDtoForCreate)
//        {
//            if (appointmentDtoForCreate.ProductForSellings != null)
//                return AppointmentType.SellingProduct;

//            if (appointmentDtoForCreate.PackageList != null)
//                return AppointmentType.ServicePackageBooking;

//            return AppointmentType.ServiceBooking;
//        }
//    }
//}
