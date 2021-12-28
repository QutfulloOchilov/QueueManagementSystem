package tj.behruz.queuemanagement.presentation.favorite

import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import kotlinx.coroutines.delay
import kotlinx.coroutines.launch

class FavoriteViewModel : ViewModel() {

    private val _favorites: MutableLiveData<Int> = MutableLiveData()
    val favorite get() = _favorites

    fun getFavorites() = viewModelScope.launch {
        delay(1000)
        _favorites.postValue(1)
    }

}