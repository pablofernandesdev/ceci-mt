using CeciMT.Domain.DTO.Commons;
using CeciMT.Domain.DTO.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeciMT.Domain.Interfaces.Service
{
    public interface INotificationService
    {
        Task<ResultResponse> SendAsync(NotificationSendDTO obj);
    }
}
