package tj.behruz.queuemanagement.presentation.salons

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import tj.behruz.queuemanagement.databinding.ServiveFragmentBinding

class ServiceFragment : Fragment() {

    private lateinit var _binding: ServiveFragmentBinding
    private val binding get() = _binding
    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = ServiveFragmentBinding.inflate(layoutInflater, container, false)
        return binding.root
    }


}