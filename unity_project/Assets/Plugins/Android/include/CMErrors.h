#if !defined(__CM_ERRORS_H__)
#define __CM_ERRORS_H__

/****************************************************************************
 *	error codes.
 */
#define CM_E_SUCCESS				0			// ����
#define CM_E_ERROR				-1			// ��Ÿ����
#define CM_E_SHORTBUF			-2			// ���۰� ����

//#define M_E_BADFD				-2			// �߸��� �ĺ���
//#define M_E_BADFILENAME			-3			// �߸��� ���� �̸�
//#define M_E_BADSEEKPOS			-4			// �߸��� ���� ��ġ
//#define M_E_EXIST				-5			// �ش� ���ҽ��� �̹� ������
//#define M_E_BADFORMAT			-6			// �߸��� ����
//#define M_E_INPROGRESS			-7			// ���۷��̼� ������
//#define M_E_INUSE				-8			// ���� ������̰ų� �̹� �����
//#define M_E_INVALID				-9			// �Ű������� �߸��Ǿ���
//#define M_E_ISCONN				-10			// �̹� ������ �����Ǿ� ����
//
//#define M_E_LONGNAME			-11			// ���ѱ��� �ʰ�
//#define M_E_NOENT				-12			// ���� ����
//#define M_E_NOSPACE				-13			// ���� ������ ����
//#define M_E_NOTCONN				-14			// ������ �����Ǿ� ���� ����
//#define M_E_NOTEMPTY			-15			// ������� ����
//#define M_E_NOTSUP				-16			// �ش� ���񽺸� �������� ����
//#define M_E_NOMEMORY			-17			// �޸� ����
//#define M_E_SHORTBUF			-18			// ���۰� ����
//#define M_E_WOULDBLOCK			-19			// WOULDBLOCK �߻�
//#define M_E_TIMEOUT				-20			// Ÿ�Ӿƿ�
//
//#define M_E_DATABIG				-21			// �����Ͱ� �ʹ� ŭ
//#define M_E_BADRECID			-22			// �߸��� ���ڵ� �ĺ���
//#define M_E_EOF					-23			// ������ ��
//#define M_E_ACCESS				-24			// ���ٿ���
//#define M_E_INVALIDHANDLE		-25			// �������� �ڵ鰪
//#define M_E_INVALIDSYSOP		-26			// �������� System Operation
//#define M_E_NOTCHANGE			-27			//
//#define M_E_NOTEXIST			-28			// �������� �ʴ� ��
//#define M_E_UNLOCK				-29			// Lock�� ������
//#define M_E_LOCK				-30			// Lock�� ������ �� ���� ���ҽ�
//
//#define M_E_HASNOUID			-31			// UID�� �������� �ʴ� ���ҽ�
//#define M_E_NOLIMIT				-32			// Max���� ����
//#define M_E_ALREADYEXISTEVENT	-33			// �̹� ���ǵ� �̺�Ʈ
//#define M_E_PLTEXIT				-34			// �÷��� ����
//#define M_E_INSUFSPACE			-35			// �޸𸮰� ���ڶ�
//#define M_E_ACCESSDENY			-36			// ������ �źε�
//#define M_E_DUPNAME				-37			// ���� �̸��� ������ �̹� ������
//#define M_E_INVALIDSTATUS		-38			//
//#define M_E_NORES				-39			//
//#define M_E_PLOCK				-40			//
//
//#define M_E_GLOCK				-41			//
//#define M_E_INCORRECTPASSWORD	-42			//
//#define M_E_INVALIDRESGROUP		-43			//
//#define M_E_INVALIDTERMRES		-44			//
//
//#define	M_E_NOTFITSIZE			-45			// Annunciator�� ����ڰ� ������ �������� ũ�Ⱑ ���� �ʴ� ���
//
//#define M_E_NOTSUPPORTGLOCK		-46			// �׷� lock�� �������� ����
//#define M_E_NOTSUPPORTLOCK		-47			// lock�� �������� ����
//
//#define M_E_NOTSUPPORTCBELL		-48			//ĳ���� ����� ��������
//#define M_E_INVALIDFORMAT 		-49			//�������� �ʴ� ������
//#define M_E_TOOMANYPARAM 		-50			//�ܸ��� �����ϴ� ĳ���� ���Ź�ȣ���� ���� �Ű� ������ ���޵�
//#define M_E_NOTSCALE			-51			// �̹��� ���ڵ��� Scale�� �������� �ʴ� ���
//
//#define M_E_NETCLOSE			-52			// ������������ ��Ʈ��ũ ������ ����� ���
//#define M_E_SOCKETCLOSE			-53			// ������������ ���� ������ ����� ���
//
//#define	M_E_NOFRAME				-54			// �ش� �������� �������� ���� ��
//#define M_E_NOTSUPPORTPLOCK		-55			// ���� �� �������� ����
//
//#define M_E_NOTACTIVE			-56			// ����̽��� Ȱ��ȭ���� ����
//
//#define M_E_NETMODECHANGE		-57			// WCDMA���� CDMA�� ��� ����
//
//#define M_E_INVALIDSOURCE		-58			//�߸��� ���� �ҽ�
//
//#define M_E_NOTRESIZE			-59			// �̹����� Resize ���ϴ� ���
//
//#define M_E_DEVCLOSE			-60			// IO ��ġ�� close �� ���
//
//#define M_E_OEMERROR			-61			// OEM�� ������ ���� WIPI ���ø����̼��� Ư�� ������ �����Ǵ� ���
//
//#define M_E_NOTSUPPORTTYPE		-62			// �ش� Ÿ���� �������� ����
//
//#define M_E_NOTFOUND			-63			// ã�� �� ����
//
//#define M_E_GETPROV				-64			// PROV Agent���� �����͸� �������� ���� ���
//
//#define M_E_INVALIDDATA			-65			// �����Ͱ� �߸���.
//
//#define M_E_MAXCOUNT			-66			// �ִ밪�� ���.
//
//#define M_E_NODEVICE			-67			// ��ġ�� �������� ���� ���
//
//#define M_E_INUSE_BY_MSASSITED	-68			// LBS�� MS Assisted ������� ��� ���� ���
//
//#define M_E_INUSE_BY_MSBASED	-69			// LBS�� MS Based ������� ��� ���� ���
//
//#define M_E_INUSE_BY_CELLBASED	-70			// LBS�� Cell Based ������� ��� ���� ���
//
//#define M_E_NODELETE			-71			// ���� �Ұ���
//
//#define M_E_NOTSUPPORTMETHOD	-72			// �������� �ʴ� �޼ҵ�
//
//#define M_E_EXPIREDDATA			-73			// MP3 ���� ����� expire�� ���
//
//#define M_E_AUTHENTICATE		-74			// Authentication Error
//
//#define M_E_NETMODEREADY		-75			// WCDMA���� CDMA�� ��� ������ �Ϸ�Ǿ� ������ ������ ���
//
//#define M_E_UNCOMPRESS			-76			// ���� ���� ����
//
//#define M_E_BAD_DCF_INFORM		-77			// DCF Header Ʋ��
//
//#define M_E_DATE_EXPIRED		-78			// ������� ����
//
//#define M_E_DEVICE_NOT_REGISTERED -79		// �ܸ��� ���� ��ϵ��� �ʾ���
//
//#define M_E_INVALID_OWNERSHIP	-80			// DCF�� �����ڿ� �ܸ��� MIN ��ȣ�� �ٸ�
//
//#define M_E_BAD_DOMAIN			-81			// DCF�� �ܸ��⿡�� ������ �� �ִ� Domain�� �ƴ�

#endif	// !__CM_ERRORS_H__
