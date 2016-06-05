using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.domain
{
    public class SegmentDTO
    {
        public int segmentNummer { get; set; }
        public string feitTypeCode { get; set; }
        public int dataModelNummer { get; set; }
        public FacttypeDTO factType { get; set; }
        public List<SegmentDeelDTO> SegmentDeel { get; set; }

        public int entiteitTypeNummer { get; set; }
        public int attribuutNummer { get; set; }

        public void SetFactType(FacttypeDTO ft)
        {
            if (ft != null)
            {
                this.factType = ft;
                this.feitTypeCode = ft.feitTypeCode;
                this.dataModelNummer = ft.dataModelNummer;
            }
        }

        public void addSegmentDeel(String segmentDeelText)
        {
            SegmentDeelDTO sd = new SegmentDeelDTO();
            sd.dataModelNummer = this.dataModelNummer;
            sd.factType = this.factType;
            sd.feitTypeCode = this.feitTypeCode;            
            sd.segmentNummer = this.segmentNummer;

            if(SegmentDeel == null )
            {
                this.SegmentDeel = new List<SegmentDeelDTO>();
            }

            if(SegmentDeel.Count() == 0)
            {                
                sd.segmentDeelNummer = 1;
            }
            else
            {
                sd.segmentDeelNummer = this.SegmentDeel.Max(i => i.segmentDeelNummer) + 1;     
            }         
 
            sd.segmentDeelTekst = segmentDeelText;

            this.SegmentDeel.Add(sd);
        }
    }
}
