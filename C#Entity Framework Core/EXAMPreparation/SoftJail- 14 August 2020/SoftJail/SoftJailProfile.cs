using System.Linq;
using SoftJail.DataProcessor.ExportDto;

namespace SoftJail
{
    using AutoMapper;
    using Data.Models;
    using DataProcessor.ImportDto;


    public class SoftJailProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {
            this.CreateMap<ImportDepatmentCellDto, Cell>();

            this.CreateMap<ImportPrisonerMailDto, Mail>();

            this.CreateMap<Mail, ExportPrisonerMailsDto>()
                .ForMember(d => d.Description,
                    opt => opt.MapFrom(s => string.Join("", s.Description.Reverse())));
            this.CreateMap<Prisoner, ExportPrisonerDto>()
                .ForMember(d => d.IncarcerationDate,
                    opt => opt.MapFrom(s => s.IncarcerationDate.ToString("yyyy-MM-dd")))
                .ForMember(d => d.Mails,
                    opt => opt.MapFrom(s => s.Mails));

        }
    }
}
