using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GPS : MonoBehaviour
{
    public bool HasTurtle = false;
    public bool HasRabbit = false;
    public bool HasPenguin = false;

    bool gpsInit = false;

    LocationInfo currentGPSPosition;

    double detailed_num = 1.0;//기존 좌표는 float형으로 소수점 자리가 비교적 자세히 출력되는 double을 곱하여 자세한 값을 구합니다.

    [HideInInspector] public double latitude;
    [HideInInspector] public double longtitude;

    private void Start()
    {
        InitGPSData();
    }

    int InitGPSData()
    {
        Input.location.Start(0.5f);

        int wait = 1000; // 기본 값

        // Checks if the GPS is enabled by the user (-> Allow location ) 

        if (Input.location.isEnabledByUser)//사용자에 의하여 좌표값을 실행 할 수 있을 경우
        {
            while (Input.location.status == LocationServiceStatus.Initializing && wait > 0)//초기화 진행중이면
            {
                wait--; // 기다리는 시간을 뺀다
            }

            //GPS를 잡는 대기시간

            if (Input.location.status != LocationServiceStatus.Failed)//GPS가 실행중이라면
            {
                gpsInit = true;
                RetrieveGPSData();
            }

            return 1;
        }

        else//GPS가 없는 경우 (GPS가 없는 기기거나 안드로이드 GPS를 설정 하지 않았을 경우
        {
            return 0;
        }
    }

    void RetrieveGPSData()
    {
        currentGPSPosition = Input.location.lastData;//gps를 데이터를 받습니다.

        latitude = currentGPSPosition.latitude * detailed_num;
        longtitude = currentGPSPosition.longitude * detailed_num;
    }

    public void CheckSeoul()
    {
        //37.579864, 126.976934
        if ((latitude >= 37.56 || latitude <= 37.58) && (longtitude >= 126.96 || longtitude <= 126.98))
        {
            HasPenguin = true;
        }
    }

    public void CheckBusan()
    {
        // 35.077493, 129.020686
        if ((latitude >= 34.06 || latitude <= 35.08) || (longtitude >= 129.01 || longtitude <= 129.03))
        {
            HasTurtle = true;
        }
    }

    public void CheckDaejeon()
    {
        // 36.332804, 127.451380
        if ((latitude >= 36.32 || latitude <= 36.34) && (longtitude >= 127.44 || longtitude <= 127.46))
        {
            HasRabbit = true;
        }
    }
}