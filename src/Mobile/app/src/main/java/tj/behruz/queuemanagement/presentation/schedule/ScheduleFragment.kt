package tj.behruz.queuemanagement.presentation.schedule

import android.os.Bundle
import android.view.*
import androidx.core.os.bundleOf
import androidx.fragment.app.Fragment
import tj.behruz.queuemanagement.R
import tj.behruz.queuemanagement.databinding.ScheduleFragmentBinding
import tj.behruz.queuemanagement.domain.entity.ScheduleItem
import tj.behruz.queuemanagement.presentation.HEADER
import tj.behruz.queuemanagement.presentation.ITEM
import tj.behruz.queuemanagement.presentation.extension.showActionbar
import tj.behruz.queuemanagement.presentation.feedback.FeedbackBottomSheet

class ScheduleFragment : Fragment() {

    private lateinit var _binding: ScheduleFragmentBinding
    private val binding get() = _binding
    val title by lazy {
        requireArguments().getString("title")
    }

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = ScheduleFragmentBinding.inflate(layoutInflater, container, false)
        return binding.root
    }


    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        setHasOptionsMenu(true)
        val times = listOf("10:00", "13:00", "16:00")
        val category = listOf("Мытие волос", "Стричка")
        showActionbar(title)
        with(binding) {
            rating.text = "Рейтинг  4.6"
        }
        val items = listOf(
            ScheduleItem("Выбирайте дату", HEADER, listOf()),
            ScheduleItem("Выбирайте дату", ITEM, times),
            ScheduleItem("Услуги", HEADER, listOf()),
            ScheduleItem("Услуги", ITEM, category),
        )
        binding.datesRecyclerView.adapter = ScheduleAdapter(items) {}


    }

    override fun onCreateOptionsMenu(menu: Menu, inflater: MenuInflater) {
        inflater.inflate(R.menu.schedule_menu, menu)
    }

    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        return when (item.itemId) {
            R.id.feedback -> {
                val bottomSheet = FeedbackBottomSheet()
                bottomSheet.arguments = bundleOf(FeedbackBottomSheet.TITLE to title)
                bottomSheet.show(childFragmentManager, FeedbackBottomSheet.TAG)
                true
            }
            R.id.favorite -> {
                true
            }
            else -> {
                false
            }
        }

    }


}