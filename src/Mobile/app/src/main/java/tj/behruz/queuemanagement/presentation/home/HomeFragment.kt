package tj.behruz.queuemanagement.presentation.home

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.appcompat.app.AppCompatActivity
import androidx.fragment.app.Fragment
import tj.behruz.queuemanagement.R
import tj.behruz.queuemanagement.databinding.HomeFragmentBinding
import tj.behruz.queuemanagement.databinding.QueueFragmentBinding
import tj.behruz.queuemanagement.presentation.extension.hideActionbar
import tj.behruz.queuemanagement.presentation.extension.navigateToScreen
import tj.behruz.queuemanagement.presentation.history.HistoryAdapter
import tj.behruz.queuemanagement.presentation.master.MasterFragment
import tj.behruz.queuemanagement.presentation.queue.QueueFragment
import tj.behruz.queuemanagement.presentation.salons.SalonViewPagerAdapter
import tj.behruz.queuemanagement.presentation.salons.ServiceFragment

class HomeFragment : Fragment() {

    private lateinit var _binding: HomeFragmentBinding
    private val binding get() = _binding

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = HomeFragmentBinding.inflate(layoutInflater, container, false)
        return binding.root
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        hideActionbar()
        val categories = listOf("Эверест", "Элегант", "Шарк")
        binding.categoryRV.adapter = HomeCategoryAdapter(categories) {}
        with(binding) {
            allSalons.setOnClickListener {
                navigateToScreen(R.id.action_nav_home_to_allSalonsFragment)
            }
        }
        val viewPagerAdapter = SalonViewPagerAdapter(childFragmentManager)
        viewPagerAdapter.addFragment(QueueFragment(0), "Сегодня")
        viewPagerAdapter.addFragment(QueueFragment(1), "Недельный")
        viewPagerAdapter.addFragment(QueueFragment(2), "Месячный")
        binding.queueRecyclerView.adapter = viewPagerAdapter
        binding.tabLayout.setupWithViewPager(binding.queueRecyclerView)
    }


}