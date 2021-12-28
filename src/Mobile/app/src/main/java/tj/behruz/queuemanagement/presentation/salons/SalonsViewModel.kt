package tj.behruz.queuemanagement.presentation.salons

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import kotlinx.coroutines.delay
import kotlinx.coroutines.launch
import tj.behruz.queuemanagement.R
import tj.behruz.queuemanagement.domain.entity.Salon

class SalonsViewModel : ViewModel() {

    private val salons: MutableLiveData<List<Salon>> = MutableLiveData()
    fun getSalon(): LiveData<List<Salon>> {
        viewModelScope.launch {
            val salon = listOf(
                Salon("Эверест", R.drawable.everest, 5.0),
                Salon("Люкс", R.drawable.test, 4.0),
                Salon("Милорд", R.drawable.test2, 5.0),
                Salon("Amore Beauty", R.drawable.test5, 5.0),
            )
            delay(1000)
            salons.postValue(salon)
        }

        return salons
    }

}