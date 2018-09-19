using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using Microsoft.VisualBasic.Compatibility;
using System.Runtime.InteropServices;
using System.Reflection;

namespace CIT.MES
{
	sealed class Module1
	{
		//读写器通用函数
		[DllImport("at_rf_reader.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern int Brio_Led_Option(int Cur_Port);
		[DllImport("at_rf_reader.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern int Brio_Beep_Option(int Cur_Port);
		[DllImport("at_rf_reader.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern int Brio_Read_EM_Card(int Cur_Port, ref byte Data);
		[DllImport("at_rf_reader.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern int Brio_Open_Port(ref int Port_Handel, short Port_Name, int Data_Rate);
		[DllImport("at_rf_reader.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern int Brio_Close_Port(int Port_Name);
		[DllImport("at_rf_reader.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern int Brio_Read_Card(int Cur_Port, ref int Data);
		[DllImport("at_rf_reader.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern int Brio_Beep_OP(int Cur_Port, short Beep_On, short Beep_Off, byte Beep_Count);
		
		//UPGRADE_NOTE: Err 已升级到 Err_Renamed�?单击以获得更多信�?“ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"�?
		public static void OpError(int Err_Renamed)
		{
			switch (Err_Renamed)
			{
				case 0:
                    MessageBox.Show("opoK");
					break;
				case - 123:
					MessageBox.Show("ѡ���˴���Ĵ�������");
					break;
				case - 124:
					MessageBox.Show("���봮����Դ����");
					break;
				case - 125:
					MessageBox.Show("设置串口状态错");
					break;
				case - 126:
					MessageBox.Show("申请串口IO缓冲区错误！");
					break;
				case - 127:
					MessageBox.Show("清除串口缓冲区数据错");
					break;
				case - 128:
					MessageBox.Show("设置出口触发事件掩码错误");
					break;
				case - 129:
					MessageBox.Show("���ó�ʱ�޽�ʱ�޴�");
					break;
				case - 130:
					MessageBox.Show("������ڴ���ʱ������");
					break;
				case - 131:
                    MessageBox.Show("û�а�װָ���Ĵ����豸");
					break;
				case - 132:
					MessageBox.Show("获取串口设备控制块错误！");
					break;
				case - 133:
					MessageBox.Show("����Ĵ����豸���������û�ʹ��");
					break;
				case - 134:
					MessageBox.Show("�ͷŴ����豸����");
					break;
				case - 135:
					MessageBox.Show("ѡ��δ�򿪵Ĵ��ھ��");
					break;
				case - 136:
					MessageBox.Show("û�п���ʹ�õĴ����豸��������ȴ�ָ���Ĵ���ͨѶ�˿ں����ԣ�");
					break;
				case - 137:
					MessageBox.Show("读卡起始地址错误");
					break;
				case - 138:
					MessageBox.Show("发送数据错误！");
					break;
				case - 139:
					MessageBox.Show("�?442卡保护位起始地址错误");
					break;
				case - 140:
					MessageBox.Show("接收数据超时错误");
					break;
				case - 141:
					MessageBox.Show("�?442卡保护位长度错误");
					break;
					//Case -142
					//    MsgBox "�d��安装指定的串口设备！"
				case - 143:
					MessageBox.Show("读写器接收数据校验错");
					break;
				case - 144:
					MessageBox.Show("��д������IC���޷�Ӧ����");
					break;
				case - 145:
					MessageBox.Show("读写器中无卡");
					break;
				case - 146:
					MessageBox.Show("发送非法的命令");
					break;
				case - 147:
					MessageBox.Show("发生未知的错误！");
					break;
				case - 148:
					MessageBox.Show("串口缓冲区溢出！");
					break;
				case - 149:
					MessageBox.Show("卡页地址错误");
					break;
				case - 150:
					MessageBox.Show("卡页内地址错误");
					break;
				case - 151:
					MessageBox.Show("�d��据长度错误！");
					break;
				case - 152:
					MessageBox.Show("接收数据校验错！");
					break;
				case - 153:
					MessageBox.Show("操作45D041卡选择错误缓冲区！");
					break;
		
				case - 178:
					MessageBox.Show("ISO14443_REQB_ERROR");
					break;
				case - 179:
					MessageBox.Show("ISO14443_CID_ERROR");
					break;
				case - 180:
					MessageBox.Show("ISO14443_READ_ERROR");
					break;
				case - 181:
					MessageBox.Show("ISO14443_CHECK_ERROR");
					break;
				case - 182:
					MessageBox.Show("ISO14443_PAGE_ERROR");
					break;
				case - 183:
					MessageBox.Show("ISO14443_WRITE_LOCKED_PAGE");
					break;
				case - 184:
					MessageBox.Show("ISO14443_WRITE_ADDR_ERROR");
					break;
				case - 185:
					MessageBox.Show("ISO14443_WRITE_LOW_POWER");
					break;
				default:
					MessageBox.Show("��д������δ֪����");
					break;
			}
		}

	}
}
