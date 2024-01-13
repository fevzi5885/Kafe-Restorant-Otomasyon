using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactLİst()
        {
            var values = _contactService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact()
            {
                FooterDescription = createContactDto.FooterDescription,
                Location = createContactDto.Location,
                Mail=createContactDto.Mail,
                Phone= createContactDto.Phone,
                FooterTitle = createContactDto.FooterTitle,
                OpenDays=createContactDto.OpenDays,
                OpenDaysDescription=createContactDto.OpenDaysDescription,
                OpenHours = createContactDto.OpenHours
            };
            _contactService.TAdd(contact);
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetByID(id);
            _contactService.TDelete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact()
            {
               ContactID = updateContactDto.ContactID,
               FooterDescription=updateContactDto.FooterDescription,
               Location = updateContactDto.Location,
               Mail=updateContactDto.Mail,
               Phone=updateContactDto.Phone,
               FooterTitle = updateContactDto.FooterTitle,
               OpenHours=updateContactDto.OpenHours,
               OpenDaysDescription = updateContactDto.OpenDaysDescription,
               OpenDays = updateContactDto.OpenDays
            };
            _contactService.TUpdate(contact);
            return Ok("Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _contactService.TGetByID(id);
            return Ok(value);
        }
    }
}

