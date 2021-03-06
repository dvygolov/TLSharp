using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
    [TLObject(1828732223)]
    public class TLPhoneCallAccepted : TLAbsPhoneCall
    {
        public override int Constructor
        {
            get
            {
                return 1828732223;
            }
        }

        public long id { get; set; }
        public long access_hash { get; set; }
        public int date { get; set; }
        public int admin_id { get; set; }
        public int participant_id { get; set; }
        public byte[] g_b { get; set; }
        public TLPhoneCallProtocol protocol { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            id = br.ReadInt64();
            access_hash = br.ReadInt64();
            date = br.ReadInt32();
            admin_id = br.ReadInt32();
            participant_id = br.ReadInt32();
            g_b = BytesUtil.Deserialize(br);
            protocol = (TLPhoneCallProtocol)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(id);
            bw.Write(access_hash);
            bw.Write(date);
            bw.Write(admin_id);
            bw.Write(participant_id);
            BytesUtil.Serialize(g_b, bw);
            ObjectUtils.SerializeObject(protocol, bw);

        }
    }
}
