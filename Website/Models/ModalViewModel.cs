using System.Collections;

namespace Website.Models
{
    public class ModalViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public IList Items { get; set; }
    }
}
