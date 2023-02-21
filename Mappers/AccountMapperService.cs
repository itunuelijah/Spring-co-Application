using SpringCoApplication.Dtos;
using System.ComponentModel;

namespace SpringCoApplication.Mappers
{
    public class AccountMapperService
    {
        public CustomerDto FromCustomer(Customer customer)
        {
            var customerDto = new CustomerDto()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email
            };

            return customerDto;
        }

        public Customer FromCustomerDto(CustomerDto customerDto)
        {
            var customer = new Customer()
            {
                Id = customerDto.Id,
                Name = customerDto.Name,
                Email = customerDto.Email
            };

            return customer;
        }


        public DeluxeDto FromDeluxe(Deluxe deluxe)
        {
            var deluxeDto = new DeluxeDto();
            TypeDescriptor.GetProperties(deluxe)
                .OfType<PropertyDescriptor>()
                .ToList()
                .ForEach(x => x.SetValue(deluxeDto, x.GetValue(deluxe)));
            deluxeDto.CustomerDto = FromCustomer(deluxe.Customer);
            deluxeDto.Type = deluxe.GetType().Name;
            return deluxeDto;
        }

        public Deluxe FromDeluxeDto(DeluxeDto deluxeDTO)
        {
            var deluxe = new Deluxe();
            TypeDescriptor.GetProperties(deluxeDTO)
                .OfType<PropertyDescriptor>()
                .ToList()
                .ForEach(x => x.SetValue(deluxe, x.GetValue(deluxeDTO)));
            deluxe.Customer = FromCustomerDto(deluxeDTO.CustomerDto);
            return deluxe;
        }

        public FlexDto FromFlex(Flex flex)
        {
            var flexDTO = new FlexDto();
            TypeDescriptor.GetProperties(flex)
                .OfType<PropertyDescriptor>()
                .ToList()
                .ForEach(x => x.SetValue(flexDTO, x.GetValue(flex)));
            flexDTO.CustomerDto = FromCustomer(flex.Customer);
            flexDTO.Type = flex.GetType().Name;
            return flexDTO;
        }

        public Flex FromFlexDTO(FlexDto flexDto)
        {
            var flex = new Flex();
            TypeDescriptor.GetProperties(flexDto)
                .OfType<PropertyDescriptor>()
                .ToList()
                .ForEach(x => x.SetValue(flex, x.GetValue(flexDto)));
            flex.Customer = FromCustomerDto(flexDto.CustomerDto);
            return flex;
        }

        public PiggyDto FromPiggy(Piggy piggy)
        {
            var piggyDTO = new PiggyDto();
            TypeDescriptor.GetProperties(piggy)
                .OfType<PropertyDescriptor>()
                .ToList()
                .ForEach(x => x.SetValue(piggyDTO, x.GetValue(piggy)));
            piggyDTO.CustomerDto = FromCustomer(piggy.Customer);
            piggyDTO.Type = piggy.GetType().Name;
            return piggyDTO;
        }

        public Piggy FromPiggyDTO(PiggyDto piggyDto)
        {
            var piggy = new Piggy();
            TypeDescriptor.GetProperties(piggyDto)
                .OfType<PropertyDescriptor>()
                .ToList()
                .ForEach(x => x.SetValue(piggy, x.GetValue(piggyDto)));
            piggy.Customer = FromCustomerDto(piggyDto.CustomerDto);
            return piggy;
        }

        public SupaDto FromSupa(Supa supa)
        {
            var supaDto = new SupaDto();
            TypeDescriptor.GetProperties(supa)
                .OfType<PropertyDescriptor>()
                .ToList()
                .ForEach(x => x.SetValue(supaDto, x.GetValue(supa)));
            supaDto.CustomerDto = FromCustomer(supa.Customer);
            supaDto.Type = supa.GetType().Name;
            return supaDto;
        }

        public Supa FromSupaDTO(SupaDto supaDTO)
        {
            var supa = new Supa();
            TypeDescriptor.GetProperties(supaDTO)
                .OfType<PropertyDescriptor>()
                .ToList()
                .ForEach(x => x.SetValue(supa, x.GetValue(supaDTO)));
            supa.Customer = FromCustomerDto(supaDTO.CustomerDto);
            return supa;
        }
        public VivaDto FromViva(Viva viva)
        {
            var vivaDto = new VivaDto();
            TypeDescriptor.GetProperties(viva)
                .OfType<PropertyDescriptor>()
                .ToList()
                .ForEach(x => x.SetValue(vivaDto, x.GetValue(viva)));
            vivaDto.CustomerDto = FromCustomer(viva.Customer);
            vivaDto.Type = viva.GetType().Name;
            return vivaDto;
        }

        public Viva FromVivaDto(VivaDto vivaDto)
        {
            var viva = new Viva();
            TypeDescriptor.GetProperties(vivaDto)
                .OfType<PropertyDescriptor>()
                .ToList()
                .ForEach(x => x.SetValue(viva, x.GetValue(vivaDto)));
            viva.Customer = FromCustomerDto(vivaDto.CustomerDto);
            return viva;
        }
    }
}

    
