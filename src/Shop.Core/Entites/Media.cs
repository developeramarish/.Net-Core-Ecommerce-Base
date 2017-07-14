using Shop.Core.BaseObjects;
using Shop.Core.Enums;
using Shop.Core.Interfaces;

namespace Shop.Core.Entites
{
    public class Media : LifetimeBase, IReferenceable<Media>
    {
        private MediaType _mediaType;
        private string _url;
        private int _index;

        public int MediaId { get; set; }
        public string MediaReference { get; set; }

        public MediaType MediaType
        {
            get => _mediaType;
            set
            {
                if (_mediaType == value) return;

                IsDirty = true;
                _mediaType = value;
            }
        }
        public string Url
        {
            get => _url;
            set
            {
                if (_url == value) return;

                IsDirty = true;
                _url = value;
            }
        }
        public int Index
        {
            get => _index;
            set
            {
                if (_index == value) return;

                _index = value;
                IsDirty = true;
            }
        }

        public Media()
        {
            MediaId = 0;
            MediaReference = string.Empty;

            MediaType = MediaType.Unknown;
            Index = 0;
        }

        public Media CreateReference(IReferenceGenerator referenceGenerator)
        {
            MediaReference = referenceGenerator.CreateReference(Constants.Constants.ReferenceLength);

            return this;
        }
    }
}