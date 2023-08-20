using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.DAL
{
    public class InforjobDAL:DBConnection
    {
        public List<InforjobBEL> ReadInforjob()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from ttcv", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<InforjobBEL> lstInfo = new List<InforjobBEL>();
            TypeoemDAL loai = new TypeoemDAL();
            PositionDAL chuc = new PositionDAL();
            DepartmentDAL phong = new DepartmentDAL();
            while (reader.Read())
            {
                InforjobBEL info = new InforjobBEL();
                info.Manv = int.Parse(reader["manv"].ToString());
                info.Ngvaolam = reader["ngvaolam"].ToString();
                info.Loai = loai.ReadType(int.Parse(reader["id_loainv"].ToString()));
                info.Chucvu = chuc.ReadPosition(int.Parse(reader["id_chucvu"].ToString()));
                info.Congviec = reader["congviec"].ToString();
                info.Phong = phong.ReadDepartment(int.Parse(reader["id_phong"].ToString()));
                info.Muclg = float.Parse(reader["muclg"].ToString());
                info.Hso = int.Parse(reader["hso"].ToString());
                info.Tknh = int.Parse(reader["tknh"].ToString());
                info.Nghang = reader["nghang"].ToString();
                lstInfo.Add(info);
            }

            conn.Close();
            return lstInfo;

        }
        public void EditInforjob(InforjobBEL info)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update ttcv set ngvaolam=@ngvaolam,id_loainv=@id_loainv," +
                "id_chucvu=@id_chucvu,congviec=@congviec,id_phong=@id_phong,muclg=@muclg,hso=@hso,tknh=@tknh,nghang=@nghang where manv= @manv", conn);
            cmd.Parameters.Add(new SqlParameter("@manv", info.Manv));
            cmd.Parameters.Add(new SqlParameter("@ngvaolam", info.Ngvaolam));
            cmd.Parameters.Add(new SqlParameter("@id_loainv", info.Loai.Maloai));
            cmd.Parameters.Add(new SqlParameter("@id_chucvu", info.Chucvu.Mach));
            cmd.Parameters.Add(new SqlParameter("@congviec", info.Congviec));
            cmd.Parameters.Add(new SqlParameter("@id_phong", info.Phong.Maphong));
            cmd.Parameters.Add(new SqlParameter("@muclg", info.Muclg));
            cmd.Parameters.Add(new SqlParameter("@hso", info.Hso));
            cmd.Parameters.Add(new SqlParameter("@tknh", info.Tknh));
            cmd.Parameters.Add(new SqlParameter("@nghang", info.Nghang));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteInforjob(InforjobBEL info)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from ttcv where manv = @manv", conn);
            cmd.Parameters.Add(new SqlParameter("@manv", info.Manv));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void NewInforjob(InforjobBEL info)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into ttcv values (@manv, @ngvaolam, @id_loainv,@id_chucvu," +
                "@congviec,@id_phong,@muclg,@hso,@tknh,@nghang)", conn);
            cmd.Parameters.Add(new SqlParameter("@manv", info.Manv));
            cmd.Parameters.Add(new SqlParameter("@ngvaolam", info.Ngvaolam));
            cmd.Parameters.Add(new SqlParameter("@id_loainv", info.Loai.Maloai));
            cmd.Parameters.Add(new SqlParameter("@id_chucvu", info.Chucvu.Mach));
            cmd.Parameters.Add(new SqlParameter("@congviec", info.Congviec));
            cmd.Parameters.Add(new SqlParameter("@id_phong", info.Phong.Maphong));
            cmd.Parameters.Add(new SqlParameter("@muclg", info.Muclg));
            cmd.Parameters.Add(new SqlParameter("@hso", info.Hso));
            cmd.Parameters.Add(new SqlParameter("@tknh", info.Tknh));
            cmd.Parameters.Add(new SqlParameter("@nghang", info.Nghang));

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
