package tj.behruz.queuemanagement.presentation.history

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.core.view.isVisible
import androidx.core.widget.doAfterTextChanged
import androidx.fragment.app.Fragment
import androidx.fragment.app.viewModels
import tj.behruz.queuemanagement.databinding.HistoryFragmentBinding
import tj.behruz.queuemanagement.presentation.extension.hideActionbar

class HistoryFragment : Fragment() {

    private lateinit var _binding: HistoryFragmentBinding
    private val binding get() = _binding
    private val viewModel by viewModels<HistoryViewModel>()
    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = HistoryFragmentBinding.inflate(layoutInflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        hideActionbar()

        viewModel.history.observe(viewLifecycleOwner) {
            with(binding) {
                shimmer.visibility = View.GONE
                shimmer.stopShimmer()
                queueRecyclerView.adapter = HistoryAdapter()
                queueRecyclerView.visibility = View.VISIBLE
            }
        }
        binding.searchInput.doAfterTextChanged { userInput ->
            binding.clearIcon.isVisible = userInput.toString().isNotEmpty()
        }
        binding.clearIcon.setOnClickListener {
            binding.searchInput.setText("")
        }

    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        viewModel.getHistory()
    }


}