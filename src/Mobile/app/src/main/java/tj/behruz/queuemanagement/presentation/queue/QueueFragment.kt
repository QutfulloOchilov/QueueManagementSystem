package tj.behruz.queuemanagement.presentation.queue

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.core.view.isVisible
import androidx.fragment.app.Fragment
import tj.behruz.queuemanagement.databinding.QueueFragmentBinding
import java.text.SimpleDateFormat
import java.util.*

class QueueFragment(val position: Int) : Fragment() {

    private lateinit var binding: QueueFragmentBinding


    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        binding = QueueFragmentBinding.inflate(layoutInflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        if (position == 0) {
            val currentDate = SimpleDateFormat.getDateInstance().format(Date())
            binding.welcomeCv.isVisible = true
            binding.currentDay.text = currentDate
        }
        binding.queueRv.adapter = QueueAdapter()
    }


}