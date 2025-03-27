using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline; // Обязательно добавьте этот импорт

public class SignalFinder : MonoBehaviour
{
    public TimelineAsset timeLine; // Таймлайн для поиска эмиттеров

    // Словарь для хранения имен и таймкодов SignalEmitter
    public Dictionary<string, float> signalTimes = new Dictionary<string, float>();

    // Start вызывается перед первым кадром
    // Start вызывается перед первым кадром
    void Start()
    {
        // Получаем первый трек (если у вас несколько, измените индекс)
        TrackAsset track = timeLine.GetRootTrack(1);

        int mCount = track.GetMarkerCount(); // Получаем количество маркеров на треке

        // Перебираем все маркеры в треке
        for (int i = 0; i < mCount; i++)
        {
            IMarker marker = track.GetMarker(i); // Получаем маркер по индексу

            // Проверяем, является ли маркер SignalEmitter
            var signal = marker as SignalEmitter;

            if (signal != null) // Если маркер — это SignalEmitter
            {
                // Добавляем имя сигнала и таймкод в словарь
                signalTimes[signal.name] = (float)marker.time;
            }
        }

        // Выводим содержимое словаря в консоль
        foreach (KeyValuePair<string, float> kvp in signalTimes)
        {
            Debug.Log("Сигнал: " + kvp.Key + ", Таймкод: " + kvp.Value);
        }
    }
}
