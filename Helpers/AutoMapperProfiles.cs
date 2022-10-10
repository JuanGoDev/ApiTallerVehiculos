namespace TallerVehiculos.Helpers
{
    using AutoMapper;
    using TallerVehiculos.DTOs;
    using TallerVehiculos.Entidades;

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Vehiculo, VehiculoDTO>().ReverseMap();
            CreateMap<VehiculoCreacionDTO, Vehiculo>();

            CreateMap<TipoVehiculo, TipoVehiculoDTO>().ReverseMap();
            CreateMap<TipoVehiculoCreacionDTO, TipoVehiculo>();

            CreateMap<TipoDocumento, TipoDocumentoDTO>().ReverseMap();
            CreateMap<TipoDocumentoCreacionDTO, TipoDocumento>();

            CreateMap<Procedimiento, ProcedimientoDTO>().ReverseMap();
            CreateMap<ProcedimientoCreacionDTO, Procedimiento>();

            CreateMap<Marca, MarcaDTO>().ReverseMap();
            CreateMap<MarcaCreacionDTO, Marca>();

            CreateMap<ImagenVehiculo, ImagenVehiculoDTO>().ReverseMap();
            CreateMap<ImagenVehiculoCreacionDTO, ImagenVehiculo>();

            CreateMap<Historial, HistorialDTO>().ReverseMap();
            CreateMap<HistorialCreacionDTO, Historial>();

            CreateMap<DetalleHistorial, DetalleHistorialDTO>().ReverseMap();
            CreateMap<DetalleHistorialCreacionDTO, DetalleHistorial>();
        }
    }
}