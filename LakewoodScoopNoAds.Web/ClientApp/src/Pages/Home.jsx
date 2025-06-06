import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Home = () => {

    const [articles, setArticles] = useState([]);

    useEffect(() => {
        const loadArticles = async () => {
            const { data } = await axios.get('/api/LakewoodScoop/GetArticles')
            setArticles(data);
        }
        loadArticles();
    }, [])

    return (
        <div className="max-w-6xl mx-auto px-4 py-8 grid gap-8 sm:grid-cols-2 lg:grid-cols-3">
            {articles.map((article, index) => (
                <div key={index} className="relative bg-white shadow rounded-xl overflow-hidden">
                    {/* Image with title overlay */}
                    <div className="relative h-56 overflow-hidden">
                        <div className="absolute inset-0 bg-black/50 flex items-end p-4">
                            <h2 className="text-white text-xl font-semibold">
                                <a href={article.articleLink}>
                                    {article.title}
                                </a>
                            </h2>
                        </div>
                        <img
                            src={article.image}
                            alt={article.title}
                            className="w-full h-full object-cover"
                        />
                    </div>
                    {/* Excerpt and comment count */}
                    <div className="p-4">
                        <p className="text-gray-700 text-sm mb-3">{article.excerpt}</p>
                        <div className="text-sm text-gray-500">
                            💬 {article.comments} comment{article.comments !== 1 && "s"}
                        </div>
                    </div>
                </div>
            ))}
        </div>
    );
}

export default Home;