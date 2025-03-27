using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayStepsNew : MonoBehaviour
{
    PlayableDirector director;
    public SignalFinder signalFinder; // Ссылка на объект SignalFinder

    void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    /// <summary>
    /// Переходит по таймлайну на время, соответствующее сигналу
    /// </summary>
    public void PlayStepByTrigger(string trigger)
    {
        // Проверка, если сигнал найден в словаре
        if (signalFinder.signalTimes.ContainsKey(trigger))
        {
            float time = signalFinder.signalTimes[trigger];
            director.time = time; // Переход на нужный таймкод
            director.Play(); // Запуск воспроизведения
            Debug.Log($"Сигнал {trigger} найден, переход на время: {time}");
        }
        else
        {
            Debug.LogWarning($"Сигнал с именем {trigger} не найден в словаре.");
        }
    }
}
