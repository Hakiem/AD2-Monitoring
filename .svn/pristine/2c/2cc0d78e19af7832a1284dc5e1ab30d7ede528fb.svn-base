using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class CacheMonitorDictionaryViewModel
    {
        public CacheMonitorDictionaryViewModel()  {}

        public List<MonitorWithStringDates> CustomListFromCachedDictionary { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text, ErrorMessage = "Please enter a valid date in the format yyyy-mm-dd")]
        [Display(Name = "Date From")]
        public string DtFrom { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text, ErrorMessage = "Please enter a valid date in the format yyyy-mm-dd")]
        [Display(Name = "Date To")]
        public string DtTo { get; set; }

        public CacheMonitorDictionaryViewModel(List<MonitorWithStringDates> retrievedDictionaryFromCache)
        {
            CustomListFromCachedDictionary = retrievedDictionaryFromCache;
        }
    }
}