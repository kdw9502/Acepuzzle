#if !defined(__CM_ERRORS_H__)
#define __CM_ERRORS_H__

/****************************************************************************
 *	error codes.
 */
#define CM_E_SUCCESS				0			// 성공
#define CM_E_ERROR				-1			// 기타에러
#define CM_E_SHORTBUF			-2			// 버퍼가 작음

//#define M_E_BADFD				-2			// 잘못된 식별자
//#define M_E_BADFILENAME			-3			// 잘못된 파일 이름
//#define M_E_BADSEEKPOS			-4			// 잘못된 파일 위치
//#define M_E_EXIST				-5			// 해당 리소스가 이미 존재함
//#define M_E_BADFORMAT			-6			// 잘못된 포맷
//#define M_E_INPROGRESS			-7			// 오퍼레이션 수행중
//#define M_E_INUSE				-8			// 현재 사용중이거나 이미 사용중
//#define M_E_INVALID				-9			// 매개변수가 잘못되었음
//#define M_E_ISCONN				-10			// 이미 연결이 설정되어 있음
//
//#define M_E_LONGNAME			-11			// 제한길이 초과
//#define M_E_NOENT				-12			// 내용 없음
//#define M_E_NOSPACE				-13			// 남은 공간이 없음
//#define M_E_NOTCONN				-14			// 연결이 설정되어 있지 않음
//#define M_E_NOTEMPTY			-15			// 비어있지 않음
//#define M_E_NOTSUP				-16			// 해당 서비스를 지원하지 않음
//#define M_E_NOMEMORY			-17			// 메모리 부족
//#define M_E_SHORTBUF			-18			// 버퍼가 작음
//#define M_E_WOULDBLOCK			-19			// WOULDBLOCK 발생
//#define M_E_TIMEOUT				-20			// 타임아웃
//
//#define M_E_DATABIG				-21			// 데이터가 너무 큼
//#define M_E_BADRECID			-22			// 잘못된 레코드 식별자
//#define M_E_EOF					-23			// 파일의 끝
//#define M_E_ACCESS				-24			// 접근에러
//#define M_E_INVALIDHANDLE		-25			// 부적절한 핸들값
//#define M_E_INVALIDSYSOP		-26			// 부적절한 System Operation
//#define M_E_NOTCHANGE			-27			//
//#define M_E_NOTEXIST			-28			// 존재하지 않는 것
//#define M_E_UNLOCK				-29			// Lock이 해제됨
//#define M_E_LOCK				-30			// Lock을 설정할 수 없는 리소스
//
//#define M_E_HASNOUID			-31			// UID가 존재하지 않는 리소스
//#define M_E_NOLIMIT				-32			// Max값이 없음
//#define M_E_ALREADYEXISTEVENT	-33			// 이미 정의된 이벤트
//#define M_E_PLTEXIT				-34			// 플랫폼 종료
//#define M_E_INSUFSPACE			-35			// 메모리가 모자람
//#define M_E_ACCESSDENY			-36			// 접근이 거부됨
//#define M_E_DUPNAME				-37			// 같은 이름의 파일이 이미 존재함
//#define M_E_INVALIDSTATUS		-38			//
//#define M_E_NORES				-39			//
//#define M_E_PLOCK				-40			//
//
//#define M_E_GLOCK				-41			//
//#define M_E_INCORRECTPASSWORD	-42			//
//#define M_E_INVALIDRESGROUP		-43			//
//#define M_E_INVALIDTERMRES		-44			//
//
//#define	M_E_NOTFITSIZE			-45			// Annunciator에 사용자가 설정한 아이콘의 크기가 맞지 않는 경우
//
//#define M_E_NOTSUPPORTGLOCK		-46			// 그룹 lock을 지원하지 않음
//#define M_E_NOTSUPPORTLOCK		-47			// lock을 지원하지 않음
//
//#define M_E_NOTSUPPORTCBELL		-48			//캐릭벨 기능을 지원안함
//#define M_E_INVALIDFORMAT 		-49			//지원하지 않는 포맷임
//#define M_E_TOOMANYPARAM 		-50			//단말이 지원하는 캐릭벨 착신번호마다 많은 매개 변수가 전달됨
//#define M_E_NOTSCALE			-51			// 이미지 디코딩시 Scale을 지원하지 않는 경우
//
//#define M_E_NETCLOSE			-52			// 비정상적으로 네트워크 연결이 종료된 경우
//#define M_E_SOCKETCLOSE			-53			// 비정상적으로 소켓 연결이 종료된 경우
//
//#define	M_E_NOFRAME				-54			// 해당 프레임이 존재하지 않을 때
//#define M_E_NOTSUPPORTPLOCK		-55			// 개별 락 지원하지 않음
//
//#define M_E_NOTACTIVE			-56			// 디바이스가 활성화되지 않음
//
//#define M_E_NETMODECHANGE		-57			// WCDMA에서 CDMA로 모드 변경
//
//#define M_E_INVALIDSOURCE		-58			//잘못된 볼륨 소스
//
//#define M_E_NOTRESIZE			-59			// 이미지를 Resize 못하는 경우
//
//#define M_E_DEVCLOSE			-60			// IO 장치가 close 된 경우
//
//#define M_E_OEMERROR			-61			// OEM의 사정에 의해 WIPI 어플리케이션의 특정 동작이 중지되는 경우
//
//#define M_E_NOTSUPPORTTYPE		-62			// 해당 타입을 지원하지 않음
//
//#define M_E_NOTFOUND			-63			// 찾을 수 없음
//
//#define M_E_GETPROV				-64			// PROV Agent에서 데이터를 가져오지 못한 경우
//
//#define M_E_INVALIDDATA			-65			// 데이터가 잘못됨.
//
//#define M_E_MAXCOUNT			-66			// 최대값을 벗어남.
//
//#define M_E_NODEVICE			-67			// 장치가 장착되지 않은 경우
//
//#define M_E_INUSE_BY_MSASSITED	-68			// LBS가 MS Assisted 방식으로 사용 중인 경우
//
//#define M_E_INUSE_BY_MSBASED	-69			// LBS가 MS Based 방식으로 사용 중인 경우
//
//#define M_E_INUSE_BY_CELLBASED	-70			// LBS가 Cell Based 방식으로 사용 중인 경우
//
//#define M_E_NODELETE			-71			// 삭제 불가능
//
//#define M_E_NOTSUPPORTMETHOD	-72			// 지원하지 않는 메소드
//
//#define M_E_EXPIREDDATA			-73			// MP3 파일 재생시 expire된 경우
//
//#define M_E_AUTHENTICATE		-74			// Authentication Error
//
//#define M_E_NETMODEREADY		-75			// WCDMA에서 CDMA로 모드 변경이 완료되어 재접속 가능한 경우
//
//#define M_E_UNCOMPRESS			-76			// 압축 해제 실패
//
//#define M_E_BAD_DCF_INFORM		-77			// DCF Header 틀림
//
//#define M_E_DATE_EXPIRED		-78			// 만료기한 지남
//
//#define M_E_DEVICE_NOT_REGISTERED -79		// 단말이 망에 등록되지 않았음
//
//#define M_E_INVALID_OWNERSHIP	-80			// DCF의 소유자와 단말의 MIN 번호가 다름
//
//#define M_E_BAD_DOMAIN			-81			// DCF가 단말기에서 실행할 수 있는 Domain이 아님

#endif	// !__CM_ERRORS_H__
