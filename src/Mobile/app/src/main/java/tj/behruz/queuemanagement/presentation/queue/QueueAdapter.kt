package tj.behruz.queuemanagement.presentation.queue

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import tj.behruz.queuemanagement.databinding.QueueItemBinding

class QueueAdapter() : RecyclerView.Adapter<QueueAdapter.QueueItemViewHolder>() {
    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): QueueItemViewHolder {
        val binding = QueueItemBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return QueueItemViewHolder(binding)
    }

    override fun onBindViewHolder(holder: QueueItemViewHolder, position: Int) {

    }

    override fun getItemCount() = 8

    inner class QueueItemViewHolder(val binding: QueueItemBinding) :
        RecyclerView.ViewHolder(binding.root) {

    }


}