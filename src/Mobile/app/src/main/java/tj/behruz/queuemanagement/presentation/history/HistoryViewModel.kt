package tj.behruz.queuemanagement.presentation.history

import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import kotlinx.coroutines.delay
import kotlinx.coroutines.launch

class HistoryViewModel : ViewModel() {

    private val _history: MutableLiveData<String> = MutableLiveData()
    val history get() = _history

    fun getHistory() = viewModelScope.launch {
        delay(2000)
        _history.postValue("")
    }

}