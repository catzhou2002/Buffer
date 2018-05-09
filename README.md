# Buffer
一个简单的缓存类
## 和h2

>this is quotesasdf
asdfadsf

*asfdafafd
*adsffdsasdf


    class ComApi
    {

        [DllImport("libarcsoft_fsdk_face_detection.dll", EntryPoint = "AFD_FSDK_InitialFaceEngine", CallingConvention = CallingConvention.Cdecl)]
        public static extern int AFD_FSDK_InitialFaceEngine(string appId, string sdkKey, IntPtr pMem, int lMemSize, ref IntPtr pEngine, int iOrientPriority, int nScale, int nMaxFaceNum);
        [DllImport("libarcsoft_fsdk_face_detection.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int AFD_FSDK_StillImageFaceDetection(IntPtr pEngine, IntPtr pImgData, ref IntPtr pFaceRes);

        [DllImport("libarcsoft_fsdk_face_detection.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int AFD_FSDK_UninitialFaceEngine(IntPtr pEngine);
    }
